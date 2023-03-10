namespace Rabbit.Data.EntityFrameworkCore
{
    public abstract class EFCoreDbContext<TDbContext> : DbContext
        where TDbContext : DbContext
    {
        private readonly LoggerFactory _loggerFactory = new(new[] {
            new DebugLoggerProvider()
        });
        public EFCoreDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options)
        {
            Identifier = serviceProvider.GetService<IIdentifier>();
            EventHelper = serviceProvider.GetService<IAggregateRootChangedEventHandler>();
            EventBus = serviceProvider.GetService<IEventBus>();
        }
        protected virtual string Schema { get; }
        protected virtual IIdentifier Identifier { get; }
        protected virtual IAggregateRootChangedEventHandler EventHelper { get; private set; }
        protected virtual IEventBus EventBus { get; private set; }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditedEntity();
            PublishEvents();
            int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken); ;
            return result;
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditedEntity();
            PublishEvents();
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
        /// 发布事件
        /// </summary>
        private void PublishEvents()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries().ToList())
            {
                if (entry.Entity is IAggregateRoot aggregateRoot)
                {
                    EventHelper?.SendChangeEventAsync(entry.Entity);
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            EventHelper?.SendCreatedEventAsync(entry.Entity);
                            break;
                        case EntityState.Modified:
                            EventHelper?.SendUpdatedEventAsync(entry.Entity);
                            break;
                        case EntityState.Deleted:
                            EventHelper?.SendDeletedEventAsync(entry.Entity);
                            break;
                    }

                    var domainEvents = aggregateRoot.DomainEvents;
                    foreach (var domainEvent in domainEvents)
                        EventBus?.SendAsync(domainEvent);
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