namespace CongestionTaxCalculator.Infrastructure.Const
{
    public static class DefaultConst
    {
        public const int TakeCount = 10;
        public const int DayCountToBeforeHoliday = 10; // for example i set this may is dynamic
        public const int OneMin = 60;


        public const string Failure = "Operation Failure";
        public const string Success = "Operation Success";
        public const string NotFound = "NotFound! Operation Failure";

      




        //public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        //{

        //    var attribute = (value.GetType().GetField(value.ToString()) ?? throw new InvalidOperationException())
        //        .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

        //    if (attribute == null)
        //        return value.ToString();

        //    var propValue = attribute.GetType().GetProperty(property.ToString())?.GetValue(attribute, null);
        //    return propValue?.ToString();
        //}
    }
}
