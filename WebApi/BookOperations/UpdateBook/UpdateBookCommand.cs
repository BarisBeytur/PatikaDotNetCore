using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    /// <summary>
    /// UpdateBookCommand sınıfı, kitap güncelleme işlemlerini gerçekleştirmek için kullanılır.
    /// </summary>
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId {get; set;}
        public UpdateBookModel Model {get; set;}
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book =_dbContext.Books.SingleOrDefault(x=> x.Id==BookId);
            if(book is null)
             {
                throw new InvalidOperationException("Kitap mevcut değil.");
            }
            book.GenreId=Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title=Model.Title != default ? Model.Title : book.Title;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}