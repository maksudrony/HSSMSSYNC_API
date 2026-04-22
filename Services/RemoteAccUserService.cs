using HSSMSSYNC_API.DTOs;
using HSSMSSYNC_API.Interfaces;

namespace HSSMSSYNC_API.Services
{
    public class RemoteAccUserService : IRemoteAccUserService
    {
        private readonly IRemoteAccUserRepository _repository;

        // Dependency Injection: The Service asks for the Repository
        public RemoteAccUserService(IRemoteAccUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginResponse> AuthenticateAsync(LoginRequest request)
        {
            // Fetch the user from Oracle via Dapper
            var user = await _repository.GetUserByEnrollmentIdAsync(request.EnrollmentId);

            // If user doesn't exist, fail early
            if (user == null)
            {
                return new LoginResponse { Success = false, Message = "Invalid Enrollment ID." };
            }

            // Password Verification
            if (user.EMP_PWD != request.Password)
            {
                return new LoginResponse { Success = false, Message = "Invalid Password." };
            }

            // Success Response
            return new LoginResponse
            {
                Success = true,
                Message = "Login Successful.",
                EmployeeName = user.EMP_NAME,
                EnrollmentId = user.EMP_ENROLL
            };
        }
    }
}