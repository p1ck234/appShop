namespace appShop.ModelBD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductSale")]
    public partial class ProductSale
    {
        public int id { get; set; }

        public int id_product { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }
    }
}
