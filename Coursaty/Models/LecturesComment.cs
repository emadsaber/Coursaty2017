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
    
    public partial class LecturesComment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LecturesComment()
        {
            this.LecturesComments_Replies = new HashSet<LecturesComments_Replies>();
        }
    
        public int id { get; set; }
        public System.DateTime currDate { get; set; }
        public string comment { get; set; }
        public int userId { get; set; }
        public int lectureId { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
    
        public virtual Lecture Lecture { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LecturesComments_Replies> LecturesComments_Replies { get; set; }
        public virtual User User { get; set; }
    }
}
