namespace Selftest_WebApi.Services.PGCServices
{
    public class PGCServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}
