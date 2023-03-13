namespace Rabbit.Domain
{
    public interface IQueryableRepository<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// 通过指定的id查询第一条或默认的实体，不存在时返回NULL
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(int id);
        /// <summary>
        /// 通过指定的id查询第一条或默认的实体，并加载关联实体对象，不存在时返回NULL 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        Task<TEntity> IncludingFirstOrDefaultAsync(int id, params Expression<Func<TEntity, object>>[] propertySelectors);
        /// <summary>
        /// 通过指定条件查询第一条或默认的实体，不存在时返回NULL
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// 通过指定条件查询第一条或默认的实体，并加载关联实体对象，不存在时返回NULL 
        /// 用法示例：IncludingFirstOrDefaultAsync(f => f.Id == id, f => f.Specifications, f => f.Images)
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <param name="propertySelectors">加载对象</param>
        /// <returns></returns>
        Task<TEntity> IncludingFirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] propertySelectors);
        /// <summary>
        /// 通过指定条件统计记录数量
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// 获取实体Linq表达式
        /// </summary>
        /// <param name="propertySelectors">指定包含(Include)的实体对象</param>
        /// <returns></returns>
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] propertySelectors);
        /// <summary>
        /// 获取实体查询的所有记录列表
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllListAsync();
        /// <summary>
        /// 获取实体查询条件结果记录列表
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression);
    }
}
