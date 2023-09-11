namespace Selftest_WebApi.Services.TeacherServices
{
    public class TeacherServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;
    }
}
