namespace Selftest_WebApi.Services.PlantsServices
{
    public class PlantsServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}
