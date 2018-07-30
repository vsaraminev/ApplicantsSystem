namespace ApplicantsSystem.Web.Infrastructure
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public static class TemDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataSuccessMessageKey] = message;
        }
    }
}
