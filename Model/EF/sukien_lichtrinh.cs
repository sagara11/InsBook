namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sukien_lichtrinh
    {
        public int id { get; set; }

        public int? sukien_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? batdau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ketthuc { get; set; }

        [StringLength(255)]
        public string noidung { get; set; }

        public virtual sukien sukien { get; set; }
    }
}
