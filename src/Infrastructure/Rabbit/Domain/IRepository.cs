namespace Rabbit.Domain
{
    public interface IRepository<TAggregateRoot>: IQueryableRepository<TAggregateRoot>
       where TAggregateRoot : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        /// <summary>
        /// 添加实体记录
        /// </summary>
        /// <param name="entity"></param>
        Task<TAggregateRoot> InsertAsync(TAggregateRoot entity);
        /// <summary>
        /// 添加实体记录并返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> InsertAndGetIdAsync(TAggregateRoot entity);
        /// <summary>
        /// 添加或更新实体实体记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TAggregateRoot> InsertOrUpdateAsync(TAggregateRoot entity);
        /// <summary>
        /// 更新实体记录
        /// </summary>
        /// <param name="entity"></param>
        Task<TAggregateRoot> UpdateAsync(TAggregateRoot entity);
        /// <summary>
        /// 删除实体记录
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(TAggregateRoot entity);

        /// <summary>
        /// 通过指定的id删除实体记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
        

    }
}
