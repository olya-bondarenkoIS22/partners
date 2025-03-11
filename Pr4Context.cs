using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace partners;

public partial class Pr4Context : DbContext
{
    public Pr4Context()
    {
    }

    public Pr4Context(DbContextOptions<Pr4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<ApplicationStatusHistory> ApplicationStatusHistories { get; set; }

    public virtual DbSet<ImplementationHistory> ImplementationHistories { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestProduct> RequestProducts { get; set; }

    public virtual DbSet<TypeOfPartner> TypeOfPartners { get; set; }

    public virtual DbSet<TypesOfMaterial> TypesOfMaterials { get; set; }

    public virtual DbSet<TypesOfProduct> TypesOfProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=pr4;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("applicationStatuses_pkey");

            entity.ToTable("applicationStatuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameStatus).HasColumnName("nameStatus");
        });

        modelBuilder.Entity<ApplicationStatusHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("applicationStatusHistory_pkey");

            entity.ToTable("applicationStatusHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfStatusChange).HasColumnName("dateOfStatusChange");
            entity.Property(e => e.IdApplicationStatus).HasColumnName("idApplicationStatus");
            entity.Property(e => e.IdRequest).HasColumnName("idRequest");

            entity.HasOne(d => d.IdApplicationStatusNavigation).WithMany(p => p.ApplicationStatusHistories)
                .HasForeignKey(d => d.IdApplicationStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_statusHistory_applicationStatuses");

            entity.HasOne(d => d.IdRequestNavigation).WithMany(p => p.ApplicationStatusHistories)
                .HasForeignKey(d => d.IdRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_statusHistory_requests");
        });

        modelBuilder.Entity<ImplementationHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ImplementationHistory_pkey");

            entity.ToTable("ImplementationHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DateOfSale).HasColumnName("dateOfSale");
            entity.Property(e => e.IdPartner).HasColumnName("idPartner");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.ImplementationHistories)
                .HasForeignKey(d => d.IdPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_implementationHistory_partners");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_pkey");

            entity.ToTable("partners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CompanyName).HasColumnName("companyName");
            entity.Property(e => e.DateOfRegistrationPartner).HasColumnName("dateOfRegistrationPartner");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.IdTypeOfPartner).HasColumnName("idTypeOfPartner");
            entity.Property(e => e.Inn)
                .HasColumnType("character varying(10)[]")
                .HasColumnName("INN");
            entity.Property(e => e.LastName).HasColumnName("lastName");
            entity.Property(e => e.MiddleName).HasColumnName("middleName");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("character varying(11)[]")
                .HasColumnName("phoneNumber");

            entity.HasOne(d => d.IdTypeOfPartnerNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdTypeOfPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partners_typeOfPartner");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Article)
                .HasColumnType("character varying(10)[]")
                .HasColumnName("article");
            entity.Property(e => e.IdImplementationHistory).HasColumnName("idImplementationHistory");
            entity.Property(e => e.IdTyoeOfProduct).HasColumnName("idTyoeOfProduct");
            entity.Property(e => e.IdTypeOfMaterials).HasColumnName("idTypeOfMaterials");
            entity.Property(e => e.MinPrice).HasColumnName("minPrice");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdImplementationHistoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdImplementationHistory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_omplementationHistory");

            entity.HasOne(d => d.IdTyoeOfProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTyoeOfProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_typesOfProducts");

            entity.HasOne(d => d.IdTypeOfMaterialsNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTypeOfMaterials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products_typesOfMaterials");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("requests_pkey");

            entity.ToTable("requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateEnd).HasColumnName("dateEnd");
            entity.Property(e => e.DateStart).HasColumnName("dateStart");
            entity.Property(e => e.IdPartner).HasColumnName("idPartner");
            entity.Property(e => e.OrderAmount).HasColumnName("orderAmount");
            entity.Property(e => e.PrepaymentAmount).HasColumnName("prepaymentAmount");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.IdPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_requests_partners");
        });

        modelBuilder.Entity<RequestProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("request_product_pkey");

            entity.ToTable("request_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountOfUnitsOrdered).HasColumnName("countOfUnitsOrdered");
            entity.Property(e => e.DateOfManufacture).HasColumnName(" dateOfManufacture");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdRequest).HasColumnName("idRequest");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.RequestProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_requestProduct_products");

            entity.HasOne(d => d.IdRequestNavigation).WithMany(p => p.RequestProducts)
                .HasForeignKey(d => d.IdRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_requestProduct_requests");
        });

        modelBuilder.Entity<TypeOfPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("typeOfPartners_pkey");

            entity.ToTable("typeOfPartners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName).HasColumnName("typeName");
        });

        modelBuilder.Entity<TypesOfMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("typesOfMaterials_pkey");

            entity.ToTable("typesOfMaterials");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MaterialScrapPercentage).HasColumnName("materialScrapPercentage");
            entity.Property(e => e.TypeOfMaterial).HasColumnName("typeOfMaterial");
        });

        modelBuilder.Entity<TypesOfProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("typesOfProducts_pkey");

            entity.ToTable("typesOfProducts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductTypeCoefficient).HasColumnName("productTypeCoefficient");
            entity.Property(e => e.TypeOfProduct).HasColumnName("typeOfProduct");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
