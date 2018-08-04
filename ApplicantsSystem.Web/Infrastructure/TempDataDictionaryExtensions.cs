namespace ApplicantsSystem.Web.Infrastructure
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDataSuccessMessageKey] = message;
        }
    }
}
