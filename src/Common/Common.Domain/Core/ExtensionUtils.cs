using System.ComponentModel;

namespace Common.Domain.Core
{
    public static class ExtensionUtils
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ?
                descriptionAttributes[0].Description :
                Enum.GetName(enumValue.GetType(), enumValue);
        }
    }
}
