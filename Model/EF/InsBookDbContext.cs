namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InsBookDbContext : DbContext
    {
        public InsBookDbContext()
            : base(@"data source=LAPTOP-Q88KDV0C\SQLEXPRESS;initial catalog=social_network_ai;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<anh> anhs { get; set; }
        public virtual DbSet<anh_binhluan> anh_binhluan { get; set; }
        public virtual DbSet<anh_chiase> anh_chiase { get; set; }
        public virtual DbSet<baiviet> baiviets { get; set; }
        public virtual DbSet<baiviet_binhluan> baiviet_binhluan { get; set; }
        public virtual DbSet<baiviet_chiase> baiviet_chiase { get; set; }
        public virtual DbSet<baiviet_chude_luu> baiviet_chude_luu { get; set; }
        public virtual DbSet<baiviet_hinhnen> baiviet_hinhnen { get; set; }
        public virtual DbSet<baiviet_luu> baiviet_luu { get; set; }
        public virtual DbSet<banbe> banbes { get; set; }
        public virtual DbSet<baocao_baiviet> baocao_baiviet { get; set; }
        public virtual DbSet<baocao_bosuutap> baocao_bosuutap { get; set; }
        public virtual DbSet<baocao_nguoidung> baocao_nguoidung { get; set; }
        public virtual DbSet<baocao_nhom> baocao_nhom { get; set; }
        public virtual DbSet<baocao_sukien> baocao_sukien { get; set; }
        public virtual DbSet<baocao_trang> baocao_trang { get; set; }
        public virtual DbSet<baocao_video> baocao_video { get; set; }
        public virtual DbSet<bosuutap> bosuutaps { get; set; }
        public virtual DbSet<bosuutap_binhluan> bosuutap_binhluan { get; set; }
        public virtual DbSet<bosuutap_chiase> bosuutap_chiase { get; set; }
        public virtual DbSet<cauchuyen> cauchuyens { get; set; }
        public virtual DbSet<cauchuyen_anh> cauchuyen_anh { get; set; }
        public virtual DbSet<cauchuyen_video> cauchuyen_video { get; set; }
        public virtual DbSet<chan_chiase> chan_chiase { get; set; }
        public virtual DbSet<chophep_chiase> chophep_chiase { get; set; }
        public virtual DbSet<chude> chudes { get; set; }
        public virtual DbSet<chuyennganh> chuyennganhs { get; set; }
        public virtual DbSet<congty> congties { get; set; }
        public virtual DbSet<diadiem> diadiems { get; set; }
        public virtual DbSet<hangmuc_trang> hangmuc_trang { get; set; }
        public virtual DbSet<nguoidung> nguoidungs { get; set; }
        public virtual DbSet<nguoidung_congty> nguoidung_congty { get; set; }
        public virtual DbSet<nguoidung_diadiem> nguoidung_diadiem { get; set; }
        public virtual DbSet<nguoidung_tinhtrang> nguoidung_tinhtrang { get; set; }
        public virtual DbSet<nguoidung_truonghoc> nguoidung_truonghoc { get; set; }
        public virtual DbSet<nguoidung_truonghoc_chuyennganh> nguoidung_truonghoc_chuyennganh { get; set; }
        public virtual DbSet<nhom> nhoms { get; set; }
        public virtual DbSet<nhom_thanhvien> nhom_thanhvien { get; set; }
        public virtual DbSet<nhomtinnhan> nhomtinnhans { get; set; }
        public virtual DbSet<nhomtinnhan_nguoidung> nhomtinnhan_nguoidung { get; set; }
        public virtual DbSet<sukien> sukiens { get; set; }
        public virtual DbSet<sukien_lichtrinh> sukien_lichtrinh { get; set; }
        public virtual DbSet<sukien_thanhvien> sukien_thanhvien { get; set; }
        public virtual DbSet<tinnhan> tinnhans { get; set; }
        public virtual DbSet<trang> trangs { get; set; }
        public virtual DbSet<trang_vaitro> trang_vaitro { get; set; }
        public virtual DbSet<truonghoc> truonghocs { get; set; }
        public virtual DbSet<video> videos { get; set; }
        public virtual DbSet<video_binhluan> video_binhluan { get; set; }
        public virtual DbSet<video_chiase> video_chiase { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<anh>()
                .Property(e => e.anh_url)
                .IsUnicode(false);

            modelBuilder.Entity<anh>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.anh_binhluan)
                .WithOptional(e => e.anh)
                .HasForeignKey(e => e.anh_id);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.anh_chiase)
                .WithRequired(e => e.anh)
                .HasForeignKey(e => e.anh_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.nguoidungs)
                .WithOptional(e => e.anh)
                .HasForeignKey(e => e.anhbia);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.nguoidungs1)
                .WithOptional(e => e.anh1)
                .HasForeignKey(e => e.anhdd);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.nhoms)
                .WithOptional(e => e.anh)
                .HasForeignKey(e => e.anhbia_url);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.sukiens)
                .WithOptional(e => e.anh)
                .HasForeignKey(e => e.anhbia_url);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.trangs)
                .WithOptional(e => e.anh)
                .HasForeignKey(e => e.anhbia);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.trangs1)
                .WithOptional(e => e.anh1)
                .HasForeignKey(e => e.anhdd);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.nguoidungs2)
                .WithMany(e => e.anhs)
                .Map(m => m.ToTable("anh_ganthe"));

            modelBuilder.Entity<anh>()
                .HasMany(e => e.nguoidungs3)
                .WithMany(e => e.anhs1)
                .Map(m => m.ToTable("anh_thich"));

            modelBuilder.Entity<anh>()
                .HasMany(e => e.baiviets)
                .WithMany(e => e.anhs)
                .Map(m => m.ToTable("baiviet_anh"));

            modelBuilder.Entity<anh>()
                .HasMany(e => e.bosuutaps)
                .WithMany(e => e.anhs)
                .Map(m => m.ToTable("bosuutap_anh"));

            modelBuilder.Entity<anh>()
                .HasMany(e => e.tinnhans)
                .WithMany(e => e.anhs)
                .Map(m => m.ToTable("tinnhan_anh").MapLeftKey("anh_url"));

            modelBuilder.Entity<anh_binhluan>()
                .HasMany(e => e.anh_binhluan1)
                .WithOptional(e => e.anh_binhluan2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<baiviet>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.baiviet_binhluan)
                .WithOptional(e => e.baiviet)
                .HasForeignKey(e => e.baiviet_id);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.baiviet_chiase)
                .WithRequired(e => e.baiviet)
                .HasForeignKey(e => e.baiviet_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.baiviet_luu)
                .WithRequired(e => e.baiviet)
                .HasForeignKey(e => e.baiviet_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.baocao_baiviet)
                .WithRequired(e => e.baiviet)
                .HasForeignKey(e => e.baiviet_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.nhoms)
                .WithOptional(e => e.baiviet)
                .HasForeignKey(e => e.ghim_baiviet);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.videos)
                .WithOptional(e => e.baiviet)
                .HasForeignKey(e => e.baiviet_id);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.nguoidungs)
                .WithMany(e => e.baiviets1)
                .Map(m => m.ToTable("baiviet_banbe"));

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.chudes)
                .WithMany(e => e.baiviets)
                .Map(m => m.ToTable("baiviet_chude"));

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.nguoidungs1)
                .WithMany(e => e.baiviets2)
                .Map(m => m.ToTable("baiviet_ganthe"));

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.nguoidungs2)
                .WithMany(e => e.baiviets3)
                .Map(m => m.ToTable("baiviet_thich"));

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.nhoms1)
                .WithMany(e => e.baiviets)
                .Map(m => m.ToTable("nhom_baiviet"));

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.sukiens)
                .WithMany(e => e.baiviets)
                .Map(m => m.ToTable("sukien_baiviet"));

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.trangs)
                .WithMany(e => e.baiviets)
                .Map(m => m.ToTable("trang_baiviet"));

            modelBuilder.Entity<baiviet_binhluan>()
                .HasMany(e => e.baiviet_binhluan1)
                .WithOptional(e => e.baiviet_binhluan2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<baiviet_chude_luu>()
                .HasMany(e => e.baiviet_luu)
                .WithOptional(e => e.baiviet_chude_luu)
                .HasForeignKey(e => e.chude_luu_id);

            modelBuilder.Entity<baiviet_hinhnen>()
                .Property(e => e.anh_url)
                .IsUnicode(false);

            modelBuilder.Entity<baiviet_hinhnen>()
                .HasMany(e => e.baiviets)
                .WithOptional(e => e.baiviet_hinhnen)
                .HasForeignKey(e => e.baiviet_hinhnen_id);

            modelBuilder.Entity<bosuutap>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<bosuutap>()
                .HasMany(e => e.baocao_bosuutap)
                .WithRequired(e => e.bosuutap)
                .HasForeignKey(e => e.bosuutap_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bosuutap>()
                .HasMany(e => e.bosuutap_chiase)
                .WithRequired(e => e.bosuutap)
                .HasForeignKey(e => e.bosuutap_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bosuutap>()
                .HasMany(e => e.bosuutap_binhluan)
                .WithOptional(e => e.bosuutap)
                .HasForeignKey(e => e.bosuutap_id);

            modelBuilder.Entity<bosuutap>()
                .HasMany(e => e.nguoidungs)
                .WithMany(e => e.bosuutaps1)
                .Map(m => m.ToTable("bosuutap_ganthe"));

            modelBuilder.Entity<bosuutap>()
                .HasMany(e => e.nguoidungs1)
                .WithMany(e => e.bosuutaps2)
                .Map(m => m.ToTable("bosuutap_thich"));

            modelBuilder.Entity<bosuutap>()
                .HasMany(e => e.nhoms)
                .WithMany(e => e.bosuutaps)
                .Map(m => m.ToTable("nhom_bosuutap"));

            modelBuilder.Entity<bosuutap>()
                .HasMany(e => e.sukiens)
                .WithMany(e => e.bosuutaps)
                .Map(m => m.ToTable("sukien_bosuutap"));

            modelBuilder.Entity<bosuutap>()
                .HasMany(e => e.trangs)
                .WithMany(e => e.bosuutaps)
                .Map(m => m.ToTable("trang_bosuutap"));

            modelBuilder.Entity<bosuutap_binhluan>()
                .HasMany(e => e.bosuutap_binhluan1)
                .WithOptional(e => e.bosuutap_binhluan2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<cauchuyen>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<cauchuyen_anh>()
                .Property(e => e.anh_url)
                .IsUnicode(false);

            modelBuilder.Entity<cauchuyen_video>()
                .Property(e => e.video_url)
                .IsUnicode(false);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.anh_chiase)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.baiviets)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.baiviet_chiase)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.bosuutaps)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.bosuutap_chiase)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.nguoidung_congty)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.nguoidung_diadiem)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.nguoidung_tinhtrang)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.nguoidung_truonghoc)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.nguoidung_truonghoc_chuyennganh)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.videos)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.video_chiase)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.nguoidungs)
                .WithMany(e => e.chan_chiase)
                .Map(m => m.ToTable("chan_danhsach"));

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.anh_chiase)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.baiviets)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.baiviet_chiase)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.bosuutaps)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.bosuutap_chiase)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.nguoidung_congty)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.nguoidung_diadiem)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.nguoidung_tinhtrang)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.nguoidung_truonghoc)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.nguoidung_truonghoc_chuyennganh)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.videos)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.video_chiase)
                .WithOptional(e => e.chophep_chiase)
                .HasForeignKey(e => e.baomat_chophep);

            modelBuilder.Entity<chophep_chiase>()
                .HasMany(e => e.nguoidungs)
                .WithMany(e => e.chophep_chiase)
                .Map(m => m.ToTable("chophep_danhsach"));

            modelBuilder.Entity<chude>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<chude>()
                .HasMany(e => e.chude1)
                .WithOptional(e => e.chude2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<chuyennganh>()
                .HasMany(e => e.chuyennganh1)
                .WithOptional(e => e.chuyennganh2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<chuyennganh>()
                .HasMany(e => e.nguoidung_truonghoc_chuyennganh)
                .WithRequired(e => e.chuyennganh)
                .HasForeignKey(e => e.chuyennganh_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<chuyennganh>()
                .HasMany(e => e.truonghocs)
                .WithMany(e => e.chuyennganhs)
                .Map(m => m.ToTable("truonghoc_chuyennganh"));

            modelBuilder.Entity<congty>()
                .Property(e => e.anh_url)
                .IsUnicode(false);

            modelBuilder.Entity<congty>()
                .HasMany(e => e.nguoidung_congty)
                .WithRequired(e => e.congty)
                .HasForeignKey(e => e.congty_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<diadiem>()
                .Property(e => e.anh_url)
                .IsUnicode(false);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.baiviets)
                .WithOptional(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.bosuutaps)
                .WithOptional(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.congties)
                .WithOptional(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.diadiem1)
                .WithOptional(e => e.diadiem2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.nguoidung_diadiem)
                .WithRequired(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.sukiens)
                .WithOptional(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.truonghocs)
                .WithOptional(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id);

            modelBuilder.Entity<hangmuc_trang>()
                .HasMany(e => e.trangs)
                .WithMany(e => e.hangmuc_trang)
                .Map(m => m.ToTable("trang_hangmuc").MapLeftKey("hangmuc_id"));

            modelBuilder.Entity<nguoidung>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.anh_binhluan)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.anh_chiase)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baiviets)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoitao_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baiviet_binhluan)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baiviet_chiase)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baiviet_luu)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.banbes)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.banbes1)
                .WithRequired(e => e.nguoidung3)
                .HasForeignKey(e => e.nguoidung2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.banbes2)
                .WithOptional(e => e.nguoidung4)
                .HasForeignKey(e => e.nguoihanhdong);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baocao_baiviet)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoibaocao_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baocao_bosuutap)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoibaocao_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baocao_nguoidung)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baocao_nguoidung1)
                .WithRequired(e => e.nguoidung1)
                .HasForeignKey(e => e.nguoibaocao_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baocao_nhom)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoibaocao_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baocao_sukien)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoibaocao_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baocao_trang)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoibaocao_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baocao_video)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoibaocao_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.bosuutaps)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoitao_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.bosuutap_binhluan)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.bosuutap_chiase)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.cauchuyens)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoitao_id);

            modelBuilder.Entity<nguoidung>()
                .HasOptional(e => e.cauchuyen_anh)
                .WithRequired(e => e.nguoidung);

            modelBuilder.Entity<nguoidung>()
                .HasOptional(e => e.cauchuyen_video)
                .WithRequired(e => e.nguoidung);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.nguoidung_congty)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.nguoidung_diadiem)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.nguoidung_tinhtrang)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.nguoidung_tinhtrang1)
                .WithRequired(e => e.nguoidung3)
                .HasForeignKey(e => e.nguoidung2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.nguoidung_truonghoc)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.nhoms)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoitao_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.nhom_thanhvien)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.thanhvien_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.nhomtinnhan_nguoidung)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.sukiens)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoitao);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.sukien_thanhvien)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.thanhvien_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.tinnhans)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoigui_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.trangs)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoitao_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.trang_vaitro)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.videos)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoitao_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.video_binhluan)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.video_chiase)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.tinnhans1)
                .WithMany(e => e.nguoidungs)
                .Map(m => m.ToTable("nguoidung_tinnhan").MapLeftKey("nguoinhan_id"));

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.videos1)
                .WithMany(e => e.nguoidungs)
                .Map(m => m.ToTable("video_ganthe"));

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.videos2)
                .WithMany(e => e.nguoidungs1)
                .Map(m => m.ToTable("video_thich"));

            modelBuilder.Entity<nguoidung_truonghoc>()
                .HasMany(e => e.nguoidung_truonghoc_chuyennganh)
                .WithRequired(e => e.nguoidung_truonghoc)
                .HasForeignKey(e => e.nguoidung_truonghoc_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhom>()
                .Property(e => e.duongdan_web)
                .IsUnicode(false);

            modelBuilder.Entity<nhom>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<nhom>()
                .HasMany(e => e.baocao_nhom)
                .WithRequired(e => e.nhom)
                .HasForeignKey(e => e.nhom_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhom>()
                .HasMany(e => e.nhom_thanhvien)
                .WithRequired(e => e.nhom)
                .HasForeignKey(e => e.nhom_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhom>()
                .HasMany(e => e.videos)
                .WithMany(e => e.nhoms)
                .Map(m => m.ToTable("nhom_video"));

            modelBuilder.Entity<nhom>()
                .HasMany(e => e.trangs)
                .WithMany(e => e.nhoms)
                .Map(m => m.ToTable("trang_nhom"));

            modelBuilder.Entity<nhomtinnhan>()
                .HasMany(e => e.nhomtinnhan_nguoidung)
                .WithRequired(e => e.nhomtinnhan)
                .HasForeignKey(e => e.nhomtinnhan_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nhomtinnhan>()
                .HasMany(e => e.tinnhans)
                .WithMany(e => e.nhomtinnhans)
                .Map(m => m.ToTable("nhomtinnhan_tinnhan"));

            modelBuilder.Entity<sukien>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<sukien>()
                .HasMany(e => e.baocao_sukien)
                .WithRequired(e => e.sukien)
                .HasForeignKey(e => e.sukien_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sukien>()
                .HasMany(e => e.sukien_lichtrinh)
                .WithOptional(e => e.sukien)
                .HasForeignKey(e => e.sukien_id);

            modelBuilder.Entity<sukien>()
                .HasMany(e => e.sukien_thanhvien)
                .WithRequired(e => e.sukien)
                .HasForeignKey(e => e.sukien_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sukien>()
                .HasMany(e => e.videos)
                .WithMany(e => e.sukiens)
                .Map(m => m.ToTable("sukien_video"));

            modelBuilder.Entity<sukien>()
                .HasMany(e => e.trangs)
                .WithMany(e => e.sukiens)
                .Map(m => m.ToTable("trang_sukien"));

            modelBuilder.Entity<tinnhan>()
                .HasMany(e => e.trangs)
                .WithMany(e => e.tinnhans)
                .Map(m => m.ToTable("trang_nhantin"));

            modelBuilder.Entity<trang>()
                .Property(e => e.web)
                .IsUnicode(false);

            modelBuilder.Entity<trang>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<trang>()
                .HasMany(e => e.baocao_trang)
                .WithRequired(e => e.trang)
                .HasForeignKey(e => e.trang_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trang>()
                .HasMany(e => e.trang_vaitro)
                .WithRequired(e => e.trang)
                .HasForeignKey(e => e.trang_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trang>()
                .HasMany(e => e.videos)
                .WithMany(e => e.trangs)
                .Map(m => m.ToTable("trang_video"));

            modelBuilder.Entity<truonghoc>()
                .Property(e => e.anh_url)
                .IsUnicode(false);

            modelBuilder.Entity<truonghoc>()
                .HasMany(e => e.nguoidung_truonghoc)
                .WithOptional(e => e.truonghoc)
                .HasForeignKey(e => e.truonghoc_id);

            modelBuilder.Entity<video>()
                .Property(e => e.video_url)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<video>()
                .HasMany(e => e.baocao_video)
                .WithRequired(e => e.video)
                .HasForeignKey(e => e.video_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<video>()
                .HasMany(e => e.video_binhluan)
                .WithOptional(e => e.video)
                .HasForeignKey(e => e.video_id);

            modelBuilder.Entity<video>()
                .HasMany(e => e.video_chiase)
                .WithRequired(e => e.video)
                .HasForeignKey(e => e.video_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<video_binhluan>()
                .HasMany(e => e.video_binhluan1)
                .WithOptional(e => e.video_binhluan2)
                .HasForeignKey(e => e.parent_id);
        }
    }
}
