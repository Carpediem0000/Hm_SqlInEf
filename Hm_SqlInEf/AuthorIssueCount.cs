using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm_SqlInEf
{
    public class AuthorIssueCount
    {
        public string Author { get; set; }
        public int IssueCount { get; set; }

        public override string ToString()
        {
            return $"Author: {Author}, IssueCount: {IssueCount}";
        }
    }
}
