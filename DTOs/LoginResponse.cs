namespace HSSMSSYNC_API.DTOs
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? EmployeeName { get; set; }
        public long EnrollmentId { get; set; }
    }
}
