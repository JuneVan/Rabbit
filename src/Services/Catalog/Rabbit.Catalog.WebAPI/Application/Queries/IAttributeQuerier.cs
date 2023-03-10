namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public interface IAttributeQuerier
    {
        Task<AttributeModel> GetAttributeByIdAsync(int id);
        Task<PagedResultDto<AttributeListModel>> GetAttributesAsync(GetAttributesInput input);
    }
}
