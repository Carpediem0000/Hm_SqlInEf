using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm_SqlInEf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryEntities())
            {
                var db = new LibraryService(context);


                //foreach (var item in db.GetAvailableBooks())
                //{
                //    Console.WriteLine(item);
                //}

                //Console.WriteLine(db.QuantityLastYearIssuedBooks());

                db.MostPopularAuthor();
            }
        }
    }
}
