using Microsoft.AspNetCore.Mvc;
using Selftest_WebApi.DTO.BookDTO;
using Selftest_WebApi.Models;
using Selftest_WebApi.Services.BookServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Selftest_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<BookModel> Books = new List<BookModel>
        {
            new BookModel()
        };

        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleBook(int id)
        {
            return Ok(await _bookService.GetBookById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Addbook(AddBookDTO newbook)
        {
            BookServiceResponse<List<GetBookDTO>> response = await _bookService.AddNewBook(newbook);
            try
            {
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(response);
            }
        }

        [HttpPut]
        public  async Task<IActionResult> UpdateBookInfo(UpdateBookInfoDTO updatebook)
        {
            BookServiceResponse<GetBookDTO> response = await _bookService.UpdateBookInfo(updatebook);
            try
            {
                return Ok(response);
            }
            catch(Exception ex)
            {
                return NotFound(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookByID(int id)
        {
            BookServiceResponse<List<GetBookDTO>> response=await _bookService.DeleteBookByID(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }
        }
    }
        
}
