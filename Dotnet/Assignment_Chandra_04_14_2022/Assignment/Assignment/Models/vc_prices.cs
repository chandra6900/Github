namespace Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vc_prices
    {
        int? _price = 0;
        string _status = "ACTIVE";
        [Key]
        public int surrogate { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime pricedate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? delivdat { get; set; }

        [DefaultValue(0)]
        public int? price { get { return _price ?? 0; } set { _price = value; } }

        [DefaultValue("ACTIVE")]
        [StringLength(10)]
        [RegularExpression("ACTIVE|INACTIVE", ErrorMessage = "Status must be ACTIVE|INACTIVE")]
        public string status { get { return string.IsNullOrWhiteSpace(_status) ? "ACTIVE" : _status; } set { _status = value; } }
    }
}
