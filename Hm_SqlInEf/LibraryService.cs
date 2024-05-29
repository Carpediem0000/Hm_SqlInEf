using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hm_SqlInEf
{
    internal class LibraryService
    {
        private readonly LibraryEntities _library;

        public LibraryService(LibraryEntities context)
        {
            _library = context;
        }

        public void TakeBook(int bookId, string rederName)
        {
            _library.TakeBook(bookId, rederName);
        }
        public void ReturnBook(int bookId)
        {
            _library.ReturnBook(bookId); 
        }
        public List<Books> GetBooksByName(string bookName)
        {
            List<Books> res = _library.Books
                                     .SqlQuery("SELECT * FROM Books WHERE Title LIKE @p0", "%" + bookName + "%")
                                     .ToList();
            return res;
        }
        public List<Books> GetBooksByAuthor(string authorName)
        {
            List<Books> res = _library.Books
                                     .SqlQuery("SELECT * FROM Books WHERE Author LIKE @p0", "%" + authorName + "%")
                                     .ToList();
            return res;
        }
        public List<Books> GetAvailableBooks()
        {
            List<Books> res = _library.Books
                                     .SqlQuery("SELECT * FROM Books WHERE Available = 1")
                                     .ToList();
            return res;
        }
        public List<Books> BooksIssuedByName(string readerName)
        {
            List<Books> res = _library.Books
                                    .SqlQuery(@"SELECT B.BookId, B.Title, B.Author, IB.IssueDate, IB.ReturnDate
                                                FROM Books AS B
                                                JOIN IssueBooks AS IB ON B.BookId = IB.BookId
                                                WHERE IB.ReaderName = @p0", readerName)
                                    .ToList();
            return res;
        }
        public List<Books> MostPopularBooks()
        {
            List<Books> res = _library.Books
                                    .SqlQuery(@"SELECT B.BookId, B.Title, B.Author, B.Available
                                                FROM Books AS B
                                                JOIN IssueBooks AS IB ON B.BookId = IB.BookId
                                                GROUP BY B.BookId, B.Title, B.Author, B.Available
                                                ORDER BY COUNT(*) DESC")
                                    .ToList();
            return res;
        }
        public List<Books> LastMonthsIssuedBooks()
        {
            List<Books> res = _library.Books
                                    .SqlQuery(@"SELECT DISTINCT B.BookId, B.Title, B.Author, B.Available
                                                FROM Books AS B
                                                JOIN IssueBooks AS IB ON B.BookId = IB.BookId
                                                WHERE IB.IssueDate >= DATEADD(MONTH, -1, GETDATE())")
                                    .ToList();
            return res;
        }
        public int QuantityLastYearIssuedBooks()
        {
            int res = _library.IssueBooks
                            .SqlQuery(@"SELECT *
                                        FROM IssueBooks
                                        WHERE YEAR(IssueDate) = YEAR(GETDATE())").Count();
            return res;
        }
        public void MostPopularAuthor()
        {
            var res = _library.Database
                            .SqlQuery<AuthorIssueCount>(@"
                                SELECT B.Author, COUNT(*) AS IssueCount
                                FROM Books AS B
                                JOIN IssueBooks AS IB ON B.BookId = IB.BookId
                                GROUP BY B.Author
                                ORDER BY IssueCount DESC")
                            .ToList();
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
