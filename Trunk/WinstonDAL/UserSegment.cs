//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Winston.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserSegment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserSegment()
        {
            this.Offer = new HashSet<Offer>();
        }
    
        public long UserSegmentID { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirthFrom { get; set; }
        public Nullable<System.DateTime> DateOfBirthTo { get; set; }
        public string ZipCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offer> Offer { get; set; }
    }
}
