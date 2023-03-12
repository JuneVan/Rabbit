namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public interface IAttributeQuerier
    {
        Task<BasicAttributeModel> GetBasicAttributeByIdAsync(int id);
        Task<SalesAttributeModel> GetSalesAttributeByIdAsync(int id);
        Task<PagedResultDto<AttributeListModel>> GetAttributesAsync(GetAttributesInput input);
    }
}
