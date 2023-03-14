namespace Rabbit.Catalog.AggregateModels.SpecificationAggregate
{
    public class Specification : FullAuditedAggregateRoot
    {
        /// <summary>
        /// 获取规格名称
        /// </summary>
        public string Name { get; private set; }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "规格名称不能为空。");
            Name = name;
        }
        /// <summary>
        /// 获取SKU
        /// </summary>
        public string SKU { get; private set; }
        public void SetSKU(string sku)
        {
            SKU = sku;
        }
        /// <summary>
        /// 获取市场价
        /// </summary>
        public decimal MarketPrice { get; private set; }
        public void SetMarketPrice(decimal marketPrice)
        {
            if (marketPrice < 0) throw new ArgumentOutOfRangeException(nameof(marketPrice), "市场价不能为负数。");
            if (marketPrice < SalesPrice) throw new ArgumentOutOfRangeException(nameof(marketPrice), "市场价不能低于售价。");
            MarketPrice = marketPrice;
        }
        /// <summary>
        /// 获取售价
        /// </summary>
        public decimal SalesPrice { get; private set; }
        public void SetSalesPrice(decimal salesPrice)
        {
            if (salesPrice < 0) throw new ArgumentOutOfRangeException(nameof(salesPrice), "售价不能为负数。");
            if (MarketPrice < salesPrice) throw new ArgumentOutOfRangeException(nameof(salesPrice), "售价不能超过市场价。");
            SalesPrice = salesPrice;
        }
        /// <summary>
        /// 获取是否上架
        /// </summary>
        public bool IsPublish { get; private set; }
        public void Publish()
        {
            IsPublish = true;
        }
        public void UpPublish()
        {
            IsPublish = false;
        }
        /// <summary>
        /// 获取库存数量
        /// </summary>
        public int Stock { get; private set; }
        public void SetStock(int stock)
        {
            if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock), "库存数量不能为负数。");
            Stock = stock;
        }
        /// <summary>
        /// 获取封面
        /// </summary>
        public string Cover { get; private set; }
        /// <summary>
        /// 设置封面
        /// </summary>
        /// <param name="cover"></param>
        public void SetCover(string cover)
        {
            Cover = cover;
        }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int ProductId { get; private set; }
        public void SetProductId(int productId)
        {
            if (productId < 0) throw new ArgumentOutOfRangeException(nameof(productId), "商品Id无效。");
            ProductId = productId;
        }
        /// <summary>
        /// 获取属性列表
        /// </summary>
        public IReadOnlyCollection<SpecificationAttribute> Attributes => _attributes.AsReadOnly();
        private List<SpecificationAttribute> _attributes = new();
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="attributeId"></param>
        /// <param name="attributeOptionId"></param>
        /// <param name="attribtueValue"></param>
        public void AddAttribute(int attributeId, int? attributeOptionId, string attribtueValue)
        {
            _attributes.Add(new SpecificationAttribute(attributeId, attributeOptionId, attribtueValue));
        }
        /// <summary>
        /// 更新属性
        /// </summary>
        /// <param name="specificationAttributeId"></param>
        /// <param name="attributeValue"></param>
        public void UpdateAttribute(int specificationAttributeId, string attributeValue)
        {
            var attribute = _attributes.FirstOrDefault(x => x.Id == specificationAttributeId);
            if (attribute != null)
                attribute.SetAttributeValue(attributeValue);
        }
        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="specificationAttributeId"></param>
        public void RemoveAttribute(int specificationAttributeId)
        {
            var attribute = _attributes.FirstOrDefault(x => x.Id == specificationAttributeId);
            if (attribute != null)
                _attributes.Remove(attribute);
        }

        /// <summary>
        /// 获取图片列表
        /// </summary>
        public IReadOnlyCollection<SpecificationPicture> Pictures => _pictures.AsReadOnly();
        private List<SpecificationPicture> _pictures = new();
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="displayOrder"></param>
        public void AddPicture(string url, int displayOrder)
        {
            _pictures.Add(new SpecificationPicture(url, displayOrder));
        }
        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="specificationPictureId"></param>
        /// <param name="displayOrder"></param>
        public void UpdatePicture(int specificationPictureId, int displayOrder)
        {
            var picture = _pictures.FirstOrDefault(x => x.Id == specificationPictureId);
            if (picture != null)
                picture.SetDisplayOrder(displayOrder);
        }
        /// <summary>
        /// 移除图片
        /// </summary>
        /// <param name="specificationPictureId"></param>
        public void RemovePicture(int specificationPictureId)
        {
            var picture = _pictures.FirstOrDefault(x => x.Id == specificationPictureId);
            if (picture != null)
                _pictures.Remove(picture);
        }
    }
}
