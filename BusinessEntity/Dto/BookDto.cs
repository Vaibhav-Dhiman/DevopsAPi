using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.BusinessEntity.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public int Price { get; set; }
        public bool IsDelete{ get; set; }
    }
}
