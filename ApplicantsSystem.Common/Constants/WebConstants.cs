namespace ApplicantsSystem.Common.Constants
{
    public class WebConstants
    {
        public const string AdministratorRole = "Administrator";
        public const string InterviewerRole = "Interviewer";

        public const string FirstInterviewer = "First Interviewer";
        public const string SecondInterviewer = "Second Interviewer";

        public const string TempDataSuccessMessageKey = "SuccessMessage";

        public const string AdminArea = "Admin";
        public const string InterviewerArea = "Interviewer";

        public const string AdminPagesPolicy = "AdminPagesPolicy";
        public const string InterviewerPagesPolicy = "InterviewerPagesPolicy";

        public const string Applicant = "Applicant";
        public const string Test = "Test";

        public const string StartTime = "Start Time";
        public const string EndTime = "End Time";

        public const string AddApplicantMessage = "Applicant {0} {1} is added successfully!";
        public const string AddInterviewertMessage = "Interviewer {0} {1} is added successfully!";
        public const string ChangeApplicantStatusMessage = "Status was changed successfully!";
        public const string RemoveApplicantMessage = "Applicant was removed successfully!";
        public const string RemoveInterviewerMessage = "Applicant was removed successfully!";
        public const string SendTestMessage = "{0} test was send to {1} successfully!";
        public const string InterviewMessage = "The interview was created successfully!";
        public const string CreateTestMessage = "{0} test was created successfully!";

        public const string EditTestDescriptionMessage = "Description was edit successfully!";
        public const string RemoveTestMessage = "Test was removed successfully!";
        public const string SetTestResultMessage = "Result {0} is added successfully!";
        public const string LeaveFeedbackMessage = "You left feedback successfully!";

        public const string EmailSubject = "Interview test from Applicants System";
        public const string EmailMessage = "To open your test <a href='{0}'>click here</a>.";

        public const string InInterviewStatus = "InInterview";
        public const int InInterviewStatusId = 1;
        public const string HiredStatus = "Hired";
        public const string RejectedStatus = "Rejected";

        public const int ListingTestsPageSize = 2;
        public const int ListingInterviewsPageSize = 5;
        public const int ListingApplicantsPageSize = 2;
    }
}
