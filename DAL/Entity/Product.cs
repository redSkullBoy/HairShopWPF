namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Line_of_supply = new HashSet<Line_of_supply>();
            Check = new HashSet<Check>();
        }

        [Key]
        public int Product_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Name { get; set; }

        [Column(TypeName = "money")]
        public decimal unit_price { get; set; }

        public int count_stock { get; set; }

        public int? volume { get; set; }

        public int Brand_ID { get; set; }

        public int Product_Type_ID { get; set; }

        public int Hair_Type_ID { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Hair_Type Hair_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Line_of_supply> Line_of_supply { get; set; }

        public virtual Product_Type Product_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Check> Check { get; set; }
    }
}
