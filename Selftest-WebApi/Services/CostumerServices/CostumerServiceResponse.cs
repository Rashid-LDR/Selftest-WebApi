namespace Selftest_WebApi.Services.CostumerServices
{
    public class CostumerServiceResponse<T>
    {
        public T Data   { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;
    }
}
