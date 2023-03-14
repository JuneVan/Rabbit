using Rabbit.Catalog.AggregateModels.SpecificationAggregate;

namespace Rabbit.Catalog.AggregateModels.ProductAggregate
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Product : FullAuditedAggregateRoot
    {
        /// <summary>
        /// 获取名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 设置名称
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "商品名称不能为空。");
            Name = name;
        }
        /// <summary>
        /// 获取商品封面图片
        /// </summary>
        public string Cover { get; private set; }
        public void SetCover(string cover)
        {
            Cover = cover;
        }
        /// <summary>
        /// 获取分类Id
        /// </summary>
        public int CategoryId { get; private set; }
        /// <summary>
        /// 设置分类Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetCategoryId(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId), "分类Id无效。");
            CategoryId = categoryId;
        }
        /// <summary>
        /// 获取品牌Id
        /// </summary>
        public int BrandId { get; private set; }
        /// <summary>
        /// 设置品牌Id
        /// </summary>
        /// <param name="brandId"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetBrandId(int brandId)
        {
            if (brandId <= 0) throw new ArgumentOutOfRangeException(nameof(brandId), "品牌Id无效。");
            BrandId = brandId;
        }
        /// <summary>
        /// 获取单位Id
        /// </summary>
        public int UnitId { get; private set; }
        /// <summary>
        /// 设置单位Id
        /// </summary>
        /// <param name="unitId"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetUnitId(int unitId)
        {
            if (unitId <= 0) throw new ArgumentOutOfRangeException(nameof(unitId), "单位Id无效。");
            UnitId = unitId;
        }
      

        /// <summary>
        /// 获取Meta关键词
        /// </summary>
        public string MetaKeywords { get; private set; }
        /// <summary>
        /// 获取Meta描述
        /// </summary>
        public string MetaDescription { get; private set; }
        /// <summary>
        /// 获取Meta标题
        /// </summary>
        public string MetaTitle { get; private set; }
        /// <summary>
        /// 设置Meta数据
        /// </summary>
        /// <param name="metaKeywords"></param>
        /// <param name="metaDescription"></param>
        /// <param name="metaTitle"></param>
        public void SetMeta(string metaKeywords, string metaDescription, string metaTitle)
        {
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
            MetaTitle = metaTitle;
        }

        /// <summary>
        /// 获取是否包邮
        /// </summary>
        public bool IsFreeShipping { get; private set; }
        /// <summary>
        /// 设置是否包邮
        /// </summary>
        /// <param name="isFreeShipping"></param>
        public void SetIsFressShipping(bool isFreeShipping)
        {
            IsFreeShipping = isFreeShipping;
        }
        /// <summary>
        /// 获取是否允许退货
        /// </summary>
        public bool IsAllowReturn { get; private set; }
        /// <summary>
        /// 设置是否允许退货
        /// </summary>
        /// <param name="isAllowReturn"></param>
        public void SetIsAllowReturn(bool isAllowReturn)
        {
            IsAllowReturn = isAllowReturn;
        }
        /// <summary>
        /// 获取是否允许换货
        /// </summary>
        public bool IsAllowExchange { get; private set; }
        /// <summary>
        /// 设置是否允许换货
        /// </summary>
        /// <param name="isAllowExchange"></param>
        public void SetIsAllowExchange(bool isAllowExchange)
        {
            IsAllowExchange = isAllowExchange;
        }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduction { get; private set; }
        public void SetIntroduction(string introduction)
        {
            Introduction = introduction;
        }

        /// <summary>
        /// 获取属性列表
        /// </summary>
        public IReadOnlyCollection<ProductAttribute> Attributes => _attributes.AsReadOnly();
        private List<ProductAttribute> _attributes = new();
        /// <summary>
        /// 添加属性信息
        /// </summary>
        /// <param name="attributeId"></param>
        /// <param name="attributeOptionId"></param>
        /// <param name="attributeValue"></param>
        public void AddAttribute(int attributeId, int? attributeOptionId, string attributeValue)
        {
            _attributes.Add(new ProductAttribute(attributeId, attributeOptionId, attributeValue));
        }
        /// <summary>
        /// 更新属性信息
        /// </summary>
        /// <param name="productAttributeId"></param>
        /// <param name="attributeOptionId"></param>
        /// <param name="attributeValue"></param>
        public void UpdateAttribute(int productAttributeId, int? attributeOptionId, string attributeValue)
        {
            var attribute = _attributes.FirstOrDefault(x => x.Id == productAttributeId);
            if (attribute == null)
                throw new ArgumentException("商品属性信息不存在。");
            attribute.SetAttributeOptionId(attributeOptionId);
            attribute.SetAttributeValue(attributeValue);
        }
        /// <summary>
        /// 移除属性信息
        /// </summary>
        /// <param name="productAttributeId">商品属性id</param>
        public void RemoveAttribute(int productAttributeId)
        {
            var attribute = _attributes.FirstOrDefault(x => x.Id == productAttributeId);
            if (attribute != null)
                _attributes.Remove(attribute);
        }
        /// <summary>
        /// 获取图片列表
        /// </summary>
        public IReadOnlyCollection<ProductPicture> Pictures => _pictures.AsReadOnly();
        private List<ProductPicture> _pictures = new();
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="displayOrder"></param>
        public void AddPicture(string url, int displayOrder)
        {
            _pictures.Add(new ProductPicture(url, displayOrder));
        }
        /// <summary>
        /// 更新图片
        /// </summary>
        /// <param name="productPictureId"></param>
        /// <param name="displayOrder"></param>
        public void UpdatePicture(int productPictureId, int displayOrder)
        {
            var picture = _pictures.FirstOrDefault(x => x.Id == productPictureId);
            if (picture != null)
                picture.SetDisplayOrder(displayOrder);
        }
        /// <summary>
        /// 移除图片
        /// </summary>
        /// <param name="productPictureId"></param>
        public void RemovePicture(int productPictureId)
        {
            var picture = _pictures.FirstOrDefault(x => x.Id == productPictureId);
            if (picture != null)
                _pictures.Remove(picture);
        }

    }
}
