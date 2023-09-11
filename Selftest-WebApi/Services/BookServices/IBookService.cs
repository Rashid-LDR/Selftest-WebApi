using Selftest_WebApi.DTO.BookDTO;
using Selftest_WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.BookServices
{
    public interface IBookService
    {
        Task<BookServiceResponse<List<GetBookDTO>>> GetBooks();
        Task<BookServiceResponse<GetBookDTO>> GetBookById(int id);

        Task<BookServiceResponse<List<GetBookDTO>>> AddNewBook(AddBookDTO Newbook);

        Task<BookServiceResponse<GetBookDTO>> UpdateBookInfo(UpdateBookInfoDTO updatebookinfo);

        Task<BookServiceResponse<List<GetBookDTO>>> DeleteBookByID( int id);

    }
}
