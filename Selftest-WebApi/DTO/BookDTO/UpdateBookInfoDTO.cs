namespace Selftest_WebApi.DTO.BookDTO
{
    public class UpdateBookInfoDTO
    {
        public int id { get; set; }

        public string Title { get; set; } = null;
        public string Author { get; set; } = null;

        public string Pages { get; set; } = null;

        public int Price { get; set; } = 0;

    }
}
