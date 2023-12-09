//存储仓库
using System;

public enum InventoryLocation
{
    Player,
    Chest,
    Count
}

public enum Enums
{
    None,

    /**
     * 浇水
     */
    Watering
}


/**
 * 使用的用具
 */
public enum ItemType
{
    [ItemTypeDesc("种子")]
    Seed,

    //货物
    [ItemTypeDesc("货物")]
    Commodity,
    //浇水工具
    [ItemTypeDesc("浇水工具")]
    WateringTool,
    //挖掘工具
    [ItemTypeDesc("挖掘工具")]
    HoeingTool,
    //砍伐工具
    [ItemTypeDesc("砍伐工具")]
    ChoppingTool,
    //击打工具
    [ItemTypeDesc("击打工具")]
    BreakingTool,
    //收割工具
    [ItemTypeDesc("收割工具")]
    ReapingTool,
    
    //收集工具
    [ItemTypeDesc("收集工具")]
    CollectingTool,
    //收获的
    [ItemTypeDesc("收获的")]
    ReapableScenary,
    //家具
    [ItemTypeDesc("家具")]
    Furniture,
    none,
    count


}


[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class ItemTypeDesc : Attribute { 
    public string Description { get; }

    public ItemTypeDesc(string description)
    {
        Description = description;
    }

    
}

