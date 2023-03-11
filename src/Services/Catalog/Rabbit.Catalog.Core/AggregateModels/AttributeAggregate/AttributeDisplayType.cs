namespace Rabbit.Catalog.AggregateModels.AttributeAggregate
{
    public enum AttributeDisplayType : sbyte
    {
        /// <summary>
        /// 单选框
        /// </summary>
        [Description("单选框")]
        Radio = 1,
        /// <summary>
        /// 复选框
        /// </summary>
        [Description("复选框")]
        Checkbox,
        /// <summary>
        /// 输入框
        /// </summary>
        [Description("输入框")]
        Input,
        /// <summary>
        /// 计数器
        /// </summary>
        [Description("计数器")]
        InputNumber = 4,
        /// <summary>
        /// 选择框
        /// </summary>
        [Description("选择框")]
        Select,
        /// <summary>
        /// 开关
        /// </summary>
        [Description("开关")]
        Switch,
        /// <summary>
        /// 日期选择器
        /// </summary>
        [Description("日期选择器")]
        DatePicker,
        /// <summary>
        /// 上传文件
        /// </summary>
        [Description("上传文件")]
        Upload = 8

    }
}
