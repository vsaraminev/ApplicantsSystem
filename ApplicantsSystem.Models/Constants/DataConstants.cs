namespace ApplicantsSystem.Models.Constants
{
    public class DataConstants
    {
        public const string UserFirstName = "First Name";
        public const string UserLastName = "Last Name";
        public const int UserNameMinLength = 3;
        public const int UserNameMaxLength = 50;
        public const string PhoneRegex = @"\+\d{10,12}";

        public const int TestNameMinLength = 3;
        public const int TestNameMaxLength = 100;

        public const int FeedbackContextMinLength = 3;
        public const int FeedbackContextMaxLength = 200;

        public const int FeedbackMinScore = 1;
        public const int FeedbackMaxScore = 5;
    }
}
