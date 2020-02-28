namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class nhomtinnhan_nguoidung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nhomtinnhan_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nguoidung_id { get; set; }

        [StringLength(255)]
        public string bietdanh { get; set; }

        public bool? truongnhom { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        public virtual nhomtinnhan nhomtinnhan { get; set; }
    }
}
