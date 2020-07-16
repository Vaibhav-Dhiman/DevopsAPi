using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.BusinessEntity.Dto;
using BooksApi.BusinessEntity.Entity;

namespace BooksApi
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
