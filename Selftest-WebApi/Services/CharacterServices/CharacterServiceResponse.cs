namespace Selftest_WebApi.Services.CharacterServices
{
    public class CharacterServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;
    }
}
