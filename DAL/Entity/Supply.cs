namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supply")]
    public partial class Supply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supply()
        {
            Line_of_supply = new HashSet<Line_of_supply>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Supply_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Invoice { get; set; }

        [Column(TypeName = "date")]
        public DateTime Supply_Data { get; set; }

        public int Supplier_ID { get; set; }

        public int User_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Line_of_supply> Line_of_supply { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual User User { get; set; }
    }
}
