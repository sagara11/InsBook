namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class baiviet_luu
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long baiviet_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nguoidung_id { get; set; }

        public int? chude_luu_id { get; set; }

        public virtual baiviet baiviet { get; set; }

        public virtual baiviet_chude_luu baiviet_chude_luu { get; set; }

        public virtual nguoidung nguoidung { get; set; }
    }
}
