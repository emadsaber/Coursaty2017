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
    
    public partial class LecturesComments_Replies
    {
        public int id { get; set; }
        public System.DateTime currDate { get; set; }
        public string reply { get; set; }
        public int userId { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public int commentId { get; set; }
    
        public virtual LecturesComment LecturesComment { get; set; }
        public virtual User User { get; set; }
    }
}
