namespace Rabbit.EntityFrameworkCore
{
    public abstract class EfCoreDbContext<TDbContext> : DbContext
        where TDbContext : DbContext
    {
        private readonly LoggerFactory _loggerFactory = new(new[] {
            new DebugLoggerProvider()
        });
        public EfCoreDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options)
        {
            Identifier = serviceProvider.GetService<IIdentifier>();
            EntityChangeEventHelper = serviceProvider.GetService<IEntityEventHelper>();
        }
        protected virtual string Schema { get; }
        protected virtual IIdentifier Identifier { get; }
        protected virtual IEntityEventHelper EntityChangeEventHelper { get; private set; }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditedEntity();
            PublishEntityEvents();
            int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken); ;
            return result;
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditedEntity();
            PublishEntityEvents();
            int result = base.SaveChanges(acceptAllChangesOnSuccess);
            return result;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (Schema != null)
                modelBuilder.Model.SetDefaultSchema(Schema);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TDbContext).Assembly);
            modelBuilder.ApplyFilterDeletedEntity();
        }

        #region Utilities
        /// <summary>
        /// 实体事件通知
        /// </summary>
        private void PublishEntityEvents()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries().ToList())
            {
                EntityChangeEventHelper?.PublishEntityChangeEvent(entry.Entity);
                switch (entry.State)
                {
                    case EntityState.Added:
                        EntityChangeEventHelper?.PublishEntityCreatedEvent(entry.Entity);
                        break;
                    case EntityState.Modified:
                        EntityChangeEventHelper?.PublishUpdatedEvent(entry.Entity);
                        break;
                    case EntityState.Deleted:
                        EntityChangeEventHelper?.PublishEntityDeletedEvent(entry.Entity);
                        break;
                }
            }
        }

        /// <summary>
        /// 设置数据默认值
        /// </summary>
        private void ApplyAuditedEntity()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.ApplyCreationAuditedEntity(Identifier.UserId);
                        break;
                    case EntityState.Modified:
                        entry.ApplyModificationAuditedEntity(Identifier.UserId);
                        break;
                    case EntityState.Deleted:
                        entry.ApplyDeletionAuditedEntity(Identifier.UserId);
                        break;
                }
            }
        }

        #endregion

    }
}