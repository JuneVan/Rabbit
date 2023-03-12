namespace Rabbit.Catalog.AggregateModels.AttributeAggregate
{
    public enum AttributeControlType : sbyte
    {
        /// <summary>
        /// 下拉列表
        /// </summary>
        [Description("下拉列表")]
        DropdownList = 1,

        /// <summary>
        /// 单选项
        /// </summary>
        [Description("单选项")]
        RadioList = 2,

        /// <summary>
        /// 复选框
        /// </summary>
        [Description("复选框")]
        Checkboxes = 3,

        /// <summary>
        /// 文本框
        /// </summary>
        [Description("文本框")]
        TextBox = 4,

        /// <summary>
        /// 多行文本框
        /// </summary>
        [Description("多行文本框")]
        MultilineTextbox = 10,

        /// <summary>
        /// 日期选择器
        /// </summary>
        [Description("日期选择器")] 
        Datepicker = 20,

        /// <summary>
        /// 文件上传
        /// </summary>
        [Description("文件上传")] 
        FileUpload = 30,

        /// <summary>
        /// 颜色选择器
        /// </summary>
        [Description("颜色选择器")] 
        ColorSquares = 40,

        /// <summary>
        /// 图像选择器
        /// </summary>
        [Description("图像选择器")] 
        ImageSquares = 45 

    }
}
