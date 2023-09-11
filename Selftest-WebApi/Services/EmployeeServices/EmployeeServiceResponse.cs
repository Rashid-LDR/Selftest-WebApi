namespace Selftest_WebApi.Services.EmployeeServices
{
    public class EmployeeServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;


    }
}
