using System.Runtime.Serialization;

namespace ApplicationFramework.Enums
{
    public enum NavigationCategories
    {
        [EnumMember(Value = "Women")]
        Women,
        [EnumMember(Value = "Dresses")]
        Dresses,
        [EnumMember(Value = "T-shorts")]
        Tshirts
    }
}
