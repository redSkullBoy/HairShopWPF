namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Discount_ID { get; set; }

        [StringLength(50)]
        public string Discount_Name { get; set; }

        public int Discount_amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime D_Start { get; set; }

        [Column(TypeName = "date")]
        public DateTime D_End { get; set; }

        public int? Product_Type_ID { get; set; }

        public int? Brand_ID { get; set; }
    }
}
