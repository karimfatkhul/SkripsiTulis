//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainCRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Modul
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modul()
        {
            this.Biddings = new HashSet<Bidding>();
        }
    
        public int ModulID { get; set; }
        public Nullable<int> ProgramID { get; set; }
        public string ModulTitle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bidding> Biddings { get; set; }
        public virtual Program Program { get; set; }
    }
}