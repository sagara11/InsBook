namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InsBookDbContext : DbContext
    {
        public InsBookDbContext()
            : base(@"data source=DESKTOP-7QMAV76\MSSQLSERVER01;initial catalog=wibook_network;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<anh> anhs { get; set; }
        public virtual DbSet<baiviet> baiviets { get; set; }
        public virtual DbSet<baiviet_binhluan> baiviet_binhluan { get; set; }
        public virtual DbSet<baiviet_chiase> baiviet_chiase { get; set; }
        public virtual DbSet<baiviet_chude_luu> baiviet_chude_luu { get; set; }
        public virtual DbSet<baiviet_hinhnen> baiviet_hinhnen { get; set; }
        public virtual DbSet<baiviet_luu> baiviet_luu { get; set; }
        public virtual DbSet<banbe> banbes { get; set; }
        public virtual DbSet<bosuutap> bosuutaps { get; set; }
        public virtual DbSet<chan_chiase> chan_chiase { get; set; }
        public virtual DbSet<chophep_chiase> chophep_chiase { get; set; }
        public virtual DbSet<chude> chudes { get; set; }
        public virtual DbSet<chuyennganh> chuyennganhs { get; set; }
        public virtual DbSet<congty> congties { get; set; }
        public virtual DbSet<diadiem> diadiems { get; set; }
        public virtual DbSet<nguoidung> nguoidungs { get; set; }
        public virtual DbSet<nguoidung_congty> nguoidung_congty { get; set; }
        public virtual DbSet<nguoidung_diadiem> nguoidung_diadiem { get; set; }
        public virtual DbSet<nguoidung_tinhtrang> nguoidung_tinhtrang { get; set; }
        public virtual DbSet<nguoidung_truonghoc> nguoidung_truonghoc { get; set; }
        public virtual DbSet<nguoidung_truonghoc_chuyennganh> nguoidung_truonghoc_chuyennganh { get; set; }
        public virtual DbSet<truonghoc> truonghocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<anh>()
                .Property(e => e.anh_url)
                .IsUnicode(false);

            modelBuilder.Entity<anh>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.nguoidungs)
                .WithOptional(e => e.anh)
                .HasForeignKey(e => e.anhbia);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.nguoidungs1)
                .WithOptional(e => e.anh1)
                .HasForeignKey(e => e.anhdd);

            modelBuilder.Entity<anh>()
                .HasMany(e => e.baiviets)
                .WithMany(e => e.anhs)
                .Map(m => m.ToTable("baiviet_anh"));

            modelBuilder.Entity<baiviet>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.baiviet_binhluan)
                .WithOptional(e => e.baiviet)
                .HasForeignKey(e => e.baiviet_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.baiviet_chiase)
                .WithRequired(e => e.baiviet)
                .HasForeignKey(e => e.baiviet_id);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.baiviet_luu)
                .WithRequired(e => e.baiviet)
                .HasForeignKey(e => e.baiviet_id);

            modelBuilder.Entity<baiviet>()
                .HasMany(e => e.baiviet1)
                .WithOptional(e => e.baiviet2)
                .HasForeignKey(e => e.parent_id);

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
                .HasMany(e => e.bosuutaps)
                .WithMany(e => e.baiviets)
                .Map(m => m.ToTable("bosuutap_anh").MapLeftKey("baiviet_anh_id"));

            modelBuilder.Entity<baiviet_binhluan>()
                .HasMany(e => e.baiviet_binhluan1)
                .WithOptional(e => e.baiviet_binhluan2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<baiviet_chude_luu>()
                .HasMany(e => e.baiviet_luu)
                .WithOptional(e => e.baiviet_chude_luu)
                .HasForeignKey(e => e.chude_luu_id)
                .WillCascadeOnDelete();

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
                .HasMany(e => e.nguoidung_congty)
                .WithOptional(e => e.chan_chiase)
                .HasForeignKey(e => e.baomat_chan);

            modelBuilder.Entity<chan_chiase>()
                .HasMany(e => e.nguoidungs)
                .WithMany(e => e.chan_chiase)
                .Map(m => m.ToTable("chan_danhsach"));

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
                .HasMany(e => e.nguoidung_congty)
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
                .HasMany(e => e.bosuutaps)
                .WithOptional(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.bosuutaps1)
                .WithOptional(e => e.diadiem1)
                .HasForeignKey(e => e.diadiem_id);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.congties)
                .WithOptional(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.nguoidung_diadiem)
                .WithRequired(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.truonghocs)
                .WithOptional(e => e.diadiem)
                .HasForeignKey(e => e.diadiem_id);

            modelBuilder.Entity<diadiem>()
                .HasMany(e => e.diadiem1)
                .WithOptional(e => e.diadiem2)
                .HasForeignKey(e => e.parent_id);

            modelBuilder.Entity<nguoidung>()
                .Property(e => e.duong_dan)
                .IsUnicode(false);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baiviets)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoitao_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baiviet_binhluan)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baiviet_chiase)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id);

            modelBuilder.Entity<nguoidung>()
                .HasMany(e => e.baiviet_luu)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id);

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
                .HasMany(e => e.bosuutaps)
                .WithOptional(e => e.nguoidung)
                .HasForeignKey(e => e.nguoitao_id)
                .WillCascadeOnDelete();

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
                .HasMany(e => e.nguoidung_congty)
                .WithRequired(e => e.nguoidung)
                .HasForeignKey(e => e.nguoidung_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nguoidung_truonghoc>()
                .HasMany(e => e.nguoidung_truonghoc_chuyennganh)
                .WithRequired(e => e.nguoidung_truonghoc)
                .HasForeignKey(e => e.nguoidung_truonghoc_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<truonghoc>()
                .Property(e => e.anh_url)
                .IsUnicode(false);

            modelBuilder.Entity<truonghoc>()
                .HasMany(e => e.nguoidung_truonghoc)
                .WithOptional(e => e.truonghoc)
                .HasForeignKey(e => e.truonghoc_id);
        }
    }
}
