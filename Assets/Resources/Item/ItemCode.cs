

public static class Convert
{
    public static ItemCode String2Enum(string name)
    {
        ItemCode item = (ItemCode)System.Enum.Parse(typeof(ItemCode), name);
        return item;
    }
}

public enum ItemCode 
{
    Module_1,
    Module_2,
    Module_3,
    Module_4,
    Module_5,


}




