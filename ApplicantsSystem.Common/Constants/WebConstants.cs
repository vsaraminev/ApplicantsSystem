namespace ApplicantsSystem.Common.Constants
{
    public class WebConstants
    {
        public const string AdministratorRole = "Administrator";
        public const string InterviewerRole = "Interviewer";

        public const string TempDataSuccessMessageKey = "SuccessMessage";

        public const string AdminArea = "Admin";
        public const string InterviewerArea = "Interviewer";

        public const string Applicant = "Applicant";
        public const string Test = "Test";

        public const string StartTime = "Start Time";
        public const string EndTime = "End Time";

        public const string AddApplicantMessage = "Applicant {0} {1} is added successfully!";
        public const string AddInterviewertMessage = "Interviewer {0} {1} is added successfully!";
        public const string ChangeApplicantStatusMessage = "{0) {1} status was changed to successfully!";
        public const string RemoveApplicantMessage = "Applicant was removed successfully!";
        public const string RemoveInterviewerMessage = "Applicant was removed successfully!";
        public const string SendTestMessage = "{0} test was send to {1} successfully!";
        public const string InterviewMessage = "The interview was created successfully!";
        //The interview with {0} {1} will be held between {2} and {3} o'clock!
        public const string CreateTestMessage = "{0} test was created successfully!";
        public const string RemoveTestMessage = "Test was removed successfully!";
        public const string SetTestResultMessage = "Result {0} is added successfully!";

        public const string EmailSubject = "Interview test from Applicants System";
        public const string EmailMessage = "To open your test <a href='{0}'>click here</a>.";

        public const string InInterviewStatus = "InInterview";
        public const string HiredStatus = "Hired";
        public const string RejectedStatus = "Rejected";
    }
}
