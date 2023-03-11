using System.ComponentModel;

namespace Rabbit.Catalog.AggregateModels.AttributeAggregate
{
    public enum AttributeType
    {
        [Description("基础属性")]
        Basic,
        [Description("销售属性")]
        Sales,


    }
}
