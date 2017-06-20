//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Coursaty.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lecture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lecture()
        {
            this.LecturesComments = new HashSet<LecturesComment>();
        }
    
        public int id { get; set; }
        public int courseId { get; set; }
        public string name { get; set; }
        public decimal rate { get; set; }
        public string description { get; set; }
        public string materials { get; set; }
        public string thumb { get; set; }
        public string contents { get; set; }
    
        public virtual Course Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LecturesComment> LecturesComments { get; set; }
    }
}