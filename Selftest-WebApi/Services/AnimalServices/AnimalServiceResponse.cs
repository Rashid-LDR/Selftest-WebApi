namespace Selftest_WebApi.Services.AnimalServices
{
    public class AnimalServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;
    }
}
