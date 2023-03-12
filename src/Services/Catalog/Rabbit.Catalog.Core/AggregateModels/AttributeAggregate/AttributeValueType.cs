namespace Rabbit.Catalog.AggregateModels.AttributeAggregate
{
    /// <summary>
    /// 属性值类型
    /// </summary>
    public enum AttributeValueType
    {
        /// <summary>
        /// 选项
        /// </summary>
        [Description("选项")]
        Option = 0,
        /// <summary>
        /// 自定义文本
        /// </summary>
        [Description("自定义文本")]
        CustomText = 10,
        /// <summary>
        /// 自定义HTML文本
        /// </summary>
        [Description("自定义HTML文本")]
        CustomHtmlText = 20,
        /// <summary>
        /// 超链接
        /// </summary>
        [Description("超链接")]
        Hyperlink = 30
    }
}
