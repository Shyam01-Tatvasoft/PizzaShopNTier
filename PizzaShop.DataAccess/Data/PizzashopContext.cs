using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PizzaShop.DataAccess.Data;

public partial class PizzashopContext : DbContext
{
    public PizzashopContext()
    {
    }

    public PizzashopContext(DbContextOptions<PizzashopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Mappingmenuitemwithmodifier> Mappingmenuitemwithmodifiers { get; set; }

    public virtual DbSet<Menuitem> Menuitems { get; set; }

    public virtual DbSet<Modifier> Modifiers { get; set; }

    public virtual DbSet<Modifiergroup> Modifiergroups { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderitem> Orderitems { get; set; }

    public virtual DbSet<Orderitemmodifiermapping> Orderitemmodifiermappings { get; set; }

    public virtual DbSet<Ordertaxmapping> Ordertaxmappings { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Rolepermission> Rolepermissions { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<Tableordermapping> Tableordermappings { get; set; }

    public virtual DbSet<Taxesandfee> Taxesandfees { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Waitingtoken> Waitingtokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=pizzashop;Username=postgres;Password=Tatva@123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_pkey");

            entity.ToTable("account");

            entity.HasIndex(e => e.Email, "account_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Isfirstlogin).HasColumnName("isfirstlogin");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("account_roleid_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.HasIndex(e => e.Name, "category_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("city_pkey");

            entity.ToTable("city");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Stateid).HasColumnName("stateid");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.Stateid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("city_stateid_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("country_pkey");

            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.HasIndex(e => e.Email, "customer_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("feedback_pkey");

            entity.ToTable("feedback");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ambience).HasColumnName("ambience");
            entity.Property(e => e.Avgrating)
                .HasPrecision(1, 1)
                .HasColumnName("avgrating");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .HasColumnName("comment");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Food).HasColumnName("food");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("feedback_orderid_fkey");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("invoice_pkey");

            entity.ToTable("invoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Modifierid).HasColumnName("modifierid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Quantityofmodifier).HasColumnName("quantityofmodifier");
            entity.Property(e => e.Rateofmodifier)
                .HasPrecision(10, 2)
                .HasColumnName("rateofmodifier");
            entity.Property(e => e.Totalamount)
                .HasPrecision(18, 2)
                .HasColumnName("totalamount");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Modifier).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Modifierid)
                .HasConstraintName("invoice_modifierid_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("invoice_orderid_fkey");
        });

        modelBuilder.Entity<Mappingmenuitemwithmodifier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mappingmenuitemwithmodifier_pkey");

            entity.ToTable("mappingmenuitemwithmodifier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Maxselectionrequired).HasColumnName("maxselectionrequired");
            entity.Property(e => e.Menuitemid).HasColumnName("menuitemid");
            entity.Property(e => e.Minselectionrequired).HasColumnName("minselectionrequired");
            entity.Property(e => e.Modifiergroupid).HasColumnName("modifiergroupid");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Menuitem).WithMany(p => p.Mappingmenuitemwithmodifiers)
                .HasForeignKey(d => d.Menuitemid)
                .HasConstraintName("mappingmenuitemwithmodifier_menuitemid_fkey");

            entity.HasOne(d => d.Modifiergroup).WithMany(p => p.Mappingmenuitemwithmodifiers)
                .HasForeignKey(d => d.Modifiergroupid)
                .HasConstraintName("mappingmenuitemwithmodifier_modifiergroupid_fkey");
        });

        modelBuilder.Entity<Menuitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menuitem_pkey");

            entity.ToTable("menuitem");

            entity.HasIndex(e => e.Name, "menuitem_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .HasColumnName("comment");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Isavailable)
                .HasDefaultValueSql("true")
                .HasColumnName("isavailable");
            entity.Property(e => e.Isdefaulttax).HasColumnName("isdefaulttax");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Isfavourite)
                .HasDefaultValueSql("false")
                .HasColumnName("isfavourite");
            entity.Property(e => e.Itemimage).HasColumnName("itemimage");
            entity.Property(e => e.Itemtype)
                .HasMaxLength(20)
                .HasColumnName("itemtype");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Rate)
                .HasPrecision(10, 2)
                .HasColumnName("rate");
            entity.Property(e => e.Shortcode)
                .HasMaxLength(10)
                .HasColumnName("shortcode");
            entity.Property(e => e.Taxpercentage)
                .HasPrecision(5, 2)
                .HasColumnName("taxpercentage");
            entity.Property(e => e.Unitid).HasColumnName("unitid");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Category).WithMany(p => p.Menuitems)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("menuitem_categoryid_fkey");

            entity.HasOne(d => d.Unit).WithMany(p => p.Menuitems)
                .HasForeignKey(d => d.Unitid)
                .HasConstraintName("menuitem_unitid_fkey");
        });

        modelBuilder.Entity<Modifier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modifier_pkey");

            entity.ToTable("modifier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifiergroupid).HasColumnName("modifiergroupid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Rate)
                .HasPrecision(10, 2)
                .HasColumnName("rate");
            entity.Property(e => e.Unitid).HasColumnName("unitid");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Modifiergroup).WithMany(p => p.Modifiers)
                .HasForeignKey(d => d.Modifiergroupid)
                .HasConstraintName("modifier_modifiergroupid_fkey");

            entity.HasOne(d => d.Unit).WithMany(p => p.Modifiers)
                .HasForeignKey(d => d.Unitid)
                .HasConstraintName("modifier_unitid_fkey");
        });

        modelBuilder.Entity<Modifiergroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modifiergroup_pkey");

            entity.ToTable("modifiergroup");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_pkey");

            entity.ToTable("order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Discount)
                .HasPrecision(10, 2)
                .HasColumnName("discount");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Isgstselected).HasColumnName("isgstselected");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Paymentid).HasColumnName("paymentid");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Subtotalamount)
                .HasPrecision(18, 2)
                .HasColumnName("subtotalamount");
            entity.Property(e => e.Tax)
                .HasPrecision(10, 2)
                .HasColumnName("tax");
            entity.Property(e => e.Totalamount)
                .HasPrecision(18, 2)
                .HasColumnName("totalamount");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("order_customerid_fkey");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Paymentid)
                .HasConstraintName("order_paymentid_fkey");
        });

        modelBuilder.Entity<Orderitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orderitem_pkey");

            entity.ToTable("orderitem");

            entity.HasIndex(e => e.Name, "orderitem_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(18, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .HasColumnName("comment");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Instruction).HasColumnName("instruction");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Menuitemid).HasColumnName("menuitemid");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Rate)
                .HasPrecision(10, 2)
                .HasColumnName("rate");
            entity.Property(e => e.Readyitemquantity).HasColumnName("readyitemquantity");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Tax)
                .HasPrecision(10, 2)
                .HasColumnName("tax");
            entity.Property(e => e.Totalamount)
                .HasPrecision(18, 2)
                .HasColumnName("totalamount");
            entity.Property(e => e.Totalmodifieramount)
                .HasPrecision(18, 2)
                .HasColumnName("totalmodifieramount");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Menuitem).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Menuitemid)
                .HasConstraintName("orderitem_menuitemid_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderitems)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("orderitem_orderid_fkey");
        });

        modelBuilder.Entity<Orderitemmodifiermapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orderitemmodifiermapping_pkey");

            entity.ToTable("orderitemmodifiermapping");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifierid).HasColumnName("modifierid");
            entity.Property(e => e.Orderitemid).HasColumnName("orderitemid");
            entity.Property(e => e.Quantityofmodifier).HasColumnName("quantityofmodifier");
            entity.Property(e => e.Rateofmodifier)
                .HasPrecision(10, 2)
                .HasColumnName("rateofmodifier");
            entity.Property(e => e.Totalamount)
                .HasPrecision(18, 2)
                .HasColumnName("totalamount");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Modifier).WithMany(p => p.Orderitemmodifiermappings)
                .HasForeignKey(d => d.Modifierid)
                .HasConstraintName("orderitemmodifiermapping_modifierid_fkey");

            entity.HasOne(d => d.Orderitem).WithMany(p => p.Orderitemmodifiermappings)
                .HasForeignKey(d => d.Orderitemid)
                .HasConstraintName("orderitemmodifiermapping_orderitemid_fkey");
        });

        modelBuilder.Entity<Ordertaxmapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ordertaxmapping_pkey");

            entity.ToTable("ordertaxmapping");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Taxid).HasColumnName("taxid");
            entity.Property(e => e.Taxvalue)
                .HasPrecision(10, 2)
                .HasColumnName("taxvalue");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Order).WithMany(p => p.Ordertaxmappings)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("ordertaxmapping_orderid_fkey");

            entity.HasOne(d => d.Tax).WithMany(p => p.Ordertaxmappings)
                .HasForeignKey(d => d.Taxid)
                .HasConstraintName("ordertaxmapping_taxid_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("payment_pkey");

            entity.ToTable("payment");

            entity.HasIndex(e => e.Method, "payment_method_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(18, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Invoiceid).HasColumnName("invoiceid");
            entity.Property(e => e.Method)
                .HasMaxLength(10)
                .HasColumnName("method");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Invoiceid)
                .HasConstraintName("payment_invoiceid_fkey");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permission_pkey");

            entity.ToTable("permission");

            entity.HasIndex(e => e.Name, "permission_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.HasIndex(e => e.Name, "role_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<Rolepermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rolepermission_pkey");

            entity.ToTable("rolepermission");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Canaddedit)
                .HasDefaultValueSql("false")
                .HasColumnName("canaddedit");
            entity.Property(e => e.Candelete)
                .HasDefaultValueSql("false")
                .HasColumnName("candelete");
            entity.Property(e => e.Canview)
                .HasDefaultValueSql("true")
                .HasColumnName("canview");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Permissionid).HasColumnName("permissionid");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Permission).WithMany(p => p.Rolepermissions)
                .HasForeignKey(d => d.Permissionid)
                .HasConstraintName("rolepermission_permissionid_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Rolepermissions)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("rolepermission_roleid_fkey");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("section_pkey");

            entity.ToTable("section");

            entity.HasIndex(e => e.Name, "section_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("state_pkey");

            entity.ToTable("state");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Countryid).HasColumnName("countryid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.Countryid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("state_countryid_fkey");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tables_pkey");

            entity.ToTable("tables");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isavailable)
                .HasDefaultValueSql("true")
                .HasColumnName("isavailable");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasColumnName("name");
            entity.Property(e => e.Sectionid).HasColumnName("sectionid");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Section).WithMany(p => p.Tables)
                .HasForeignKey(d => d.Sectionid)
                .HasConstraintName("tables_sectionid_fkey");
        });

        modelBuilder.Entity<Tableordermapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tableordermapping_pkey");

            entity.ToTable("tableordermapping");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Noofpersons).HasColumnName("noofpersons");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Tableid).HasColumnName("tableid");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Order).WithMany(p => p.Tableordermappings)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("tableordermapping_orderid_fkey");

            entity.HasOne(d => d.Table).WithMany(p => p.Tableordermappings)
                .HasForeignKey(d => d.Tableid)
                .HasConstraintName("tableordermapping_tableid_fkey");
        });

        modelBuilder.Entity<Taxesandfee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("taxesandfees_pkey");

            entity.ToTable("taxesandfees");

            entity.HasIndex(e => e.Name, "taxesandfees_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Flatamount)
                .HasPrecision(10, 2)
                .HasColumnName("flatamount");
            entity.Property(e => e.Isactive)
                .HasDefaultValueSql("true")
                .HasColumnName("isactive");
            entity.Property(e => e.Isdefault).HasColumnName("isdefault");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Percentge)
                .HasPrecision(5, 2)
                .HasColumnName("percentge");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unit_pkey");

            entity.ToTable("unit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Shortname)
                .HasMaxLength(10)
                .HasColumnName("shortname");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .HasColumnName("country");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Isactive)
                .HasDefaultValueSql("true")
                .HasColumnName("isactive");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Profileimage).HasColumnName("profileimage");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("state");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(6)
                .HasColumnName("zipcode");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("users_roleid_fkey");
        });

        modelBuilder.Entity<Waitingtoken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("waitingtoken_pkey");

            entity.ToTable("waitingtoken");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Isassigned)
                .HasDefaultValueSql("false")
                .HasColumnName("isassigned");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Noofpersons).HasColumnName("noofpersons");
            entity.Property(e => e.Sectionid).HasColumnName("sectionid");
            entity.Property(e => e.Tableid).HasColumnName("tableid");
            entity.Property(e => e.Updatedby)
                .HasMaxLength(50)
                .HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updateddate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Waitingtokens)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("waitingtoken_customerid_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.Waitingtokens)
                .HasForeignKey(d => d.Sectionid)
                .HasConstraintName("waitingtoken_sectionid_fkey");

            entity.HasOne(d => d.Table).WithMany(p => p.Waitingtokens)
                .HasForeignKey(d => d.Tableid)
                .HasConstraintName("waitingtoken_tableid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
