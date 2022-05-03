namespace appShop.ModelBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public string Description { get; set; }

        public bool isActive { get; set; }

        [StringLength(1000)]
        public string MainImagePath { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }
    }
}
