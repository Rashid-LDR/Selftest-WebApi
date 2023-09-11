namespace Selftest_WebApi.DTO.BookDTO
{
    public class GetBookDTO
    {
        public int id { get; set; } = 0;

        public string Title { get; set; } = null;
        public string Author { get; set; } = null;

        public string Pages { get; set; } = null;

        public int Price { get; set; } = 0;

    }
}
