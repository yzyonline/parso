//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parso.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApplicationDefinition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApplicationDefinition()
        {
            this.Batch = new HashSet<Batch>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public string RootUrl { get; set; }
        public string DetailUrl { get; set; }
        public string CatalogDetailUrl { get; set; }
        public string CatalogSeperator { get; set; }
        public string ApplicationType { get; set; }
        public Nullable<System.DateTime> RecordDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Batch> Batch { get; set; }
    }
}
