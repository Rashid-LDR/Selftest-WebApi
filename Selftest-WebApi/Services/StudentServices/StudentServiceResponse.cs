namespace Selftest_WebApi.Services.StudentServices
{
    public class StudentServiceResponse<T>
    {
        public T Data { get; set; }

        public string Message { get; set; } = null;

        public bool Success { get; set; } = true;
    }
}
