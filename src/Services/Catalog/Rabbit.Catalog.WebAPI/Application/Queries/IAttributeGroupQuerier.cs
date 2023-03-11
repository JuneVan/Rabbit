namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public interface IAttributeGroupQuerier
    {
        Task<AttributeGroupModel> GetAttributeGroupByIdAsync(int id);
        Task<PagedResultDto<AttributeGroupListModel>> GetAttributeGroupsAsync(GetAttributeGroupsInput input);
    }
}
