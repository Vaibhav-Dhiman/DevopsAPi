using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Globalization;
using BooksApi.BusinessEntity.Dto;
using BooksApi.BusinessEntity.Entity;
using BusinessEntity.Data;
using System.Linq;

namespace Repository.Implementations
{
    public class BookRepository : IBook
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var booksFromRepo = await _context.Books.Where(x => x.IsDelete == false).ToListAsync();
            var data = _mapper.Map<List<Book>>(booksFromRepo);
            return data;
        }

        public async Task<Book> GetBook(int id)
        {
            var bookFromRepo = await _context.Books.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == false);
            var data = _mapper.Map<Book>(bookFromRepo);
            return data;
        }


        public async Task<Book> PutBook(BookDto bookDto, int id)
        {
            try
            {
                var bookFromRepo = await _context.Books.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == false);

                if (bookFromRepo != null)
                {
                    bookFromRepo.Author = bookDto.Author;
                    bookFromRepo.Name = bookDto.Name;
                    bookFromRepo.Description = bookDto.Description;
                    bookFromRepo.Price = bookDto.Price;
                     _context.Books.Update(bookFromRepo);
                    _context.SaveChanges();

                    var data = _mapper.Map<Book>(bookFromRepo);
                    return data;
                }
                return null;
            }

            catch (Exception ex) { 
                    return null;
            }
        }

        public async Task<bool> AddBook(BookDto bookDto)
        {
            try
            {
                if (bookDto != null)
                {

                    var AddBook = _mapper.Map<BookDto, Book>(bookDto);
                    AddBook.IsDelete = false;
                    AddBook.DateAdded = DateTime.Today;
                    await _context.Books.AddAsync(AddBook);
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }

            catch (Exception ex) {
                return false;
            }
        }

        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                var getBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == false);

                if (getBook != null)
                {
                    getBook.IsDelete = true;
                    _context.Books.Update(getBook);
                    _context.SaveChanges();
                   // _context.Books.Remove(getBook);
                    return true;
                }
                return false;
            }

            catch (Exception ex) {
                return false;   
            }
        }
    }
}
