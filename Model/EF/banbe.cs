namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banbe")]
    public partial class banbe
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nguoidung1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nguoidung2 { get; set; }

        public int xacnhan { get; set; }

        public int? nguoihanhdong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaybatdau { get; set; }

        public int uutien { get; set; }

        public virtual nguoidung nguoidung { get; set; }

        public virtual nguoidung nguoidung3 { get; set; }

        public virtual nguoidung nguoidung4 { get; set; }
    }
}
