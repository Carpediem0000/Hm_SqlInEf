//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hm_SqlInEf
{
    using System;
    using System.Collections.Generic;
    
    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            this.IssueBooks = new HashSet<IssueBooks>();
        }
    
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<bool> Available { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueBooks> IssueBooks { get; set; }

        public override string ToString()
        {
            return $"BookId: {BookId}, Name: {Title}, Author: {Author}, Year: {Year}";
        }
    }
}
