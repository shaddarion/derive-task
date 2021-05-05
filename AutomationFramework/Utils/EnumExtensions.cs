using System;
using System.Linq;
using System.Runtime.Serialization;

namespace AutomationFramework.Utils
{
    public class EnumExtensions
    {
        public static string GetEnumMemberAttributeValue(Type enumType, object enumItem)
        {
            var memberInfo = enumType.GetMember(enumItem.ToString());
            var attribute = memberInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();

            return attribute?.Value;
        }
    }
}
