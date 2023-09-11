namespace Selftest_WebApi.Services.ClientServices
{
    public class ClientServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;

    }
}
