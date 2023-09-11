using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.BookDTO;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.BookServices
{
    public class BookService : IBookService
    {
        private static List<BookModel> Books = new List<BookModel> { new BookModel()};

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BookService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<BookServiceResponse<List<GetBookDTO>>> AddNewBook(AddBookDTO Newbook)
        {
            BookServiceResponse<List<GetBookDTO>> response = new BookServiceResponse<List<GetBookDTO>>();
            try
            {
                BookModel book=_mapper.Map<BookModel>(Newbook);
                //book.id=Books.Max(c => c.id)+1;
                //Books.Add(book);

                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();


                response.Data = (_context.Books.Select(c => _mapper.Map<GetBookDTO>(c))).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
        }

        public async Task<BookServiceResponse<GetBookDTO>> GetBookById(int id)
        {
            BookServiceResponse < GetBookDTO > response = new BookServiceResponse<GetBookDTO>();
            try
            {
                BookModel dbcontext =await _context.Books.FirstOrDefaultAsync(c => c.id == id);
                response.Data =_mapper.Map<GetBookDTO>(dbcontext);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
        }

        public async Task<BookServiceResponse<List<GetBookDTO>>> GetBooks()
        {
            BookServiceResponse<List<GetBookDTO>> response = new BookServiceResponse<List<GetBookDTO>>();
            try
            {
                List<BookModel> dbcontext=await _context.Books.ToListAsync();
                response.Data = (dbcontext.Select(c => _mapper.Map<GetBookDTO>(c))).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<BookServiceResponse<GetBookDTO>> UpdateBookInfo(UpdateBookInfoDTO updatebookinfo)
        {
            BookServiceResponse<GetBookDTO> response= new BookServiceResponse<GetBookDTO>();
            try
            {
                BookModel infoBook =await _context.Books.FirstOrDefaultAsync(c => c.id == updatebookinfo.id);
                infoBook.Title = updatebookinfo.Title;
                infoBook.Author = updatebookinfo.Author;
                infoBook.Price = updatebookinfo.Price;
                infoBook.Pages = updatebookinfo.Pages;

                _context.Books.Update(infoBook);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetBookDTO>(infoBook);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<BookServiceResponse<List<GetBookDTO>>> DeleteBookByID(int id)
        {
            BookServiceResponse<List<GetBookDTO>> response = new BookServiceResponse<List<GetBookDTO>>();
            try
            {
                BookModel book= await _context.Books.FirstOrDefaultAsync(x => x.id == id);

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                response.Data = (_context.Books.Select(x => _mapper.Map<GetBookDTO>(x))).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message=ex.Message;
            }
            return response;
        }
    }
}
