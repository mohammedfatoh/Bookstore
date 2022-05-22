using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books;

        public BookRepository()
        {
            books = new List<Book>()
            {
                //list Books لاضافة بعض العناصر داخل 
                new Book()
                {
                    Id = 1,
                    Title="C# Programming",
                    Description="No description",
                    ImageUrl = "home.jpg",
                    Author =new Author{ Id = 2}
                },
                new Book()
                {
                    Id = 2,Title="java Programming",Description="Nothing",
                    ImageUrl = "images.jpg",
                    Author =new Author()
                },
                new Book()
                {
                    Id = 3,Title="python Programming",Description="No data",
                    ImageUrl = "lion.jpg",
                    Author =new Author()
                },
            };
         }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id)+1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id); 
            return book;
        }

        public IList<Book> List()
        {
           return books;
        }

        public List<Book> Search(string term)
        {
            return books.Where(a => a.Title.Contains(term)).ToList();

        }

        public void Update(int id,Book newBook)
        {
            var book = Find(id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
            book.ImageUrl = newBook.ImageUrl;
        }
    }
}
