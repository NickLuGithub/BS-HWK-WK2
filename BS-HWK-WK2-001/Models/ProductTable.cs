namespace BS_HWK_WK2_001.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductTable")]
    public partial class ProductTable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }
    }
}
