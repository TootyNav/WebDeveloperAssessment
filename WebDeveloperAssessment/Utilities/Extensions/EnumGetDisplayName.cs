using System.ComponentModel.DataAnnotations;

namespace WebDeveloperAssessment.Utilities.Extensions
{
    public static class EnumGetDisplayName
    {
        public static string GetDisplayName(this Enum target)
        {
            var attributes = target.GetType().GetMember(target.ToString())
                .First()
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>();

            foreach (var attribute in attributes)
                return attribute.GetName();

            return target.ToString();
        }
    }
}
