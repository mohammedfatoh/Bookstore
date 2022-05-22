using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
        IList<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author() { Id = 1,FullName = "mohammed fatoh" },
                new Author() { Id = 2,FullName = "Ahmed ali" },
                new Author() { Id = 3,FullName = "samy mahmoud" },
            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(b => b.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public IList<Author> List()
        {
           return authors;
        }

        public List<Author> Search(string term)
        {
            return authors.Where(a => a.FullName.Contains(term)).ToList();      
        }

        public void Update(int id, Author newauthor)
        {
           var author =Find(id);
            author.FullName = newauthor.FullName;

        }
    }
}
