namespace WindowsPubs.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public store()
        {
            sales = new HashSet<sale>();
        }

        [Key]
        [StringLength(4)]
        public string stor_id { get; set; }

        [StringLength(40)]
        public string stor_name { get; set; }

        [StringLength(40)]
        public string stor_address { get; set; }

        [StringLength(20)]
        public string city { get; set; }

        [StringLength(2)]
        public string state { get; set; }

        [StringLength(5)]
        public string zip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sale> sales { get; set; }
    }
}
