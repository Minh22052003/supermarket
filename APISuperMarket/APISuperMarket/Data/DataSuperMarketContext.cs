using System;
using System.Collections.Generic;
using APISuperMarket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APISuperMarket.Data
{
    public partial class DataSuperMarketContext : DbContext
    {
        public DataSuperMarketContext()
        {
        }

        public DataSuperMarketContext(DbContextOptions<DataSuperMarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccCustomer> AccCustomers { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<BankAccount> BankAccounts { get; set; } = null!;
        public virtual DbSet<BankTransfer> BankTransfers { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<BrandChange> BrandChanges { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartProduct> CartProducts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ChangeType> ChangeTypes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerRole> CustomerRoles { get; set; } = null!;
        public virtual DbSet<DiscountChange> DiscountChanges { get; set; } = null!;
        public virtual DbSet<DiscountCode> DiscountCodes { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Mail> Mail { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderChange> OrderChanges { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductChange> ProductChanges { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<ProductReview> ProductReviews { get; set; } = null!;
        public virtual DbSet<ProfileImage> ProfileImages { get; set; } = null!;
        public virtual DbSet<ReviewImage> ReviewImages { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public virtual DbSet<StatusAcc> StatusAccs { get; set; } = null!;
        public virtual DbSet<StoreInfo> StoreInfos { get; set; } = null!;
        public virtual DbSet<UiChange> UiChanges { get; set; } = null!;
        public virtual DbSet<UserChange> UserChanges { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CNFI749\\SQLEXPRESS;Initial Catalog=DataSuperMarket;Integrated Security=True;Multiple Active Result Sets=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccCustomer>(entity =>
            {
                entity.ToTable("Acc_Customer");

                entity.HasIndex(e => e.CustomerId, "IX_Acc_Customer_CustomerID");

                entity.HasIndex(e => e.StatusAccId, "IX_Acc_Customer_Status_AccID");

                entity.Property(e => e.AccCustomerId).HasColumnName("Acc_CustomerID");

                entity.Property(e => e.AuthProvider)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Auth_Provider");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Creation")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HashPass)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Hash_Pass");

                entity.Property(e => e.ProviderId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ProviderID");

                entity.Property(e => e.StatusAccId).HasColumnName("Status_AccID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AccCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Acc_Custo__Statu__489AC854");

                entity.HasOne(d => d.StatusAcc)
                    .WithMany(p => p.AccCustomers)
                    .HasForeignKey(d => d.StatusAccId)
                    .HasConstraintName("FK__Acc_Custo__Statu__498EEC8D");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine1).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Commune).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.District).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Customer_Address");
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("Bank_Account");

                entity.HasIndex(e => e.CustomerId, "IX_Bank_Account_CustomerID");

                entity.Property(e => e.BankAccountId).HasColumnName("Bank_AccountID");

                entity.Property(e => e.AccountHolderName).HasColumnName("Account_Holder_Name");

                entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");

                entity.Property(e => e.BankName).HasColumnName("Bank_Name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Bank_Acco__Custo__08B54D69");
            });

            modelBuilder.Entity<BankTransfer>(entity =>
            {
                entity.ToTable("Bank_Transfers");

                entity.HasIndex(e => e.OrderId, "IX_Bank_Transfers_OrderID");

                entity.Property(e => e.BankTransferId).HasColumnName("Bank_TransferID");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Account_Name");

                entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");

                entity.Property(e => e.BankName).HasColumnName("Bank_Name");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_At")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.TransferDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Transfer_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Time")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BankTransfers)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Bank_Tran__Order__662B2B3B");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandName).HasColumnName("Brand_Name");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_At")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LogoBrandUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Logo_Brand_Url");

                entity.Property(e => e.NumberOfProducts).HasColumnName("Number_Of_Products");

                entity.Property(e => e.TotalStars).HasColumnName("Total_Stars");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_At")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<BrandChange>(entity =>
            {
                entity.ToTable("Brand_Changes");

                entity.HasIndex(e => e.BrandId, "IX_Brand_Changes_BrandID");

                entity.HasIndex(e => e.ChangeTypeId, "IX_Brand_Changes_Change_TypeID");

                entity.HasIndex(e => e.CustomerId, "IX_Brand_Changes_CustomerID");

                entity.Property(e => e.BrandChangeId).HasColumnName("Brand_ChangeID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Change_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ChangeDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Change_Description");

                entity.Property(e => e.ChangeTypeId).HasColumnName("Change_TypeID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.BrandChanges)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Brand_Cha__Brand__14E61A24");

                entity.HasOne(d => d.ChangeType)
                    .WithMany(p => p.BrandChanges)
                    .HasForeignKey(d => d.ChangeTypeId)
                    .HasConstraintName("FK__Brand_Cha__Chang__16CE6296");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BrandChanges)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Brand_Cha__Custo__15DA3E5D");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasIndex(e => e.CustomerId, "IX_Cart_CustomerID");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Cart__CustomerID__160F4887");
            });

            modelBuilder.Entity<CartProduct>(entity =>
            {
                entity.HasKey(e => e.CartProductsId)
                    .HasName("PK__Cart_Pro__A080AFB0CFC975CE");

                entity.ToTable("Cart_Products");

                entity.HasIndex(e => e.CartId, "IX_Cart_Products_CartID");

                entity.HasIndex(e => e.ProductId, "IX_Cart_Products_ProductID");

                entity.Property(e => e.CartProductsId).HasColumnName("Cart_ProductsID");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartProducts)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__Cart_Prod__CartI__18EBB532");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Cart_Prod__Produ__17F790F9");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasColumnName("Category_Name");
            });

            modelBuilder.Entity<ChangeType>(entity =>
            {
                entity.ToTable("Change_Type");

                entity.Property(e => e.ChangeTypeId).HasColumnName("Change_TypeID");

                entity.Property(e => e.ChangeName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Change_Name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.GenderId, "IX_Customer_GenderID");

                entity.HasIndex(e => e.MailId, "IX_Customer_MailID");

                entity.HasIndex(e => e.ProfileImageId, "IX_Customer_Profile_ImageID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.CustomerName).HasColumnName("Customer_Name");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.MailId).HasColumnName("MailID");

                entity.Property(e => e.ProfileImageId).HasColumnName("Profile_ImageID");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__Customer__Gender__66603565");

                entity.HasOne(d => d.Mail)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.MailId)
                    .HasConstraintName("FK__Customer__MailID__6754599E");

                entity.HasOne(d => d.ProfileImage)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ProfileImageId)
                    .HasConstraintName("FK__Customer__Profil__68487DD7");
            });

            modelBuilder.Entity<CustomerRole>(entity =>
            {
                entity.ToTable("Customer_Roles");

                entity.HasIndex(e => e.CustomerId, "IX_Customer_Roles_CustomerID");

                entity.HasIndex(e => e.RoleId, "IX_Customer_Roles_RoleID");

                entity.Property(e => e.CustomerRoleId).HasColumnName("Customer_RoleID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerRoles)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Customer___Custo__3E1D39E1");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.CustomerRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Customer___RoleI__3D2915A8");
            });

            modelBuilder.Entity<DiscountChange>(entity =>
            {
                entity.ToTable("Discount_Changes");

                entity.HasIndex(e => e.ChangeTypeId, "IX_Discount_Changes_Change_TypeID");

                entity.HasIndex(e => e.CustomerId, "IX_Discount_Changes_CustomerID");

                entity.HasIndex(e => e.DiscountCodeId, "IX_Discount_Changes_Discount_CodeID");

                entity.Property(e => e.DiscountChangeId).HasColumnName("Discount_ChangeID");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Change_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ChangeDescription).HasColumnName("Change_Description");

                entity.Property(e => e.ChangeTypeId).HasColumnName("Change_TypeID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DiscountCodeId).HasColumnName("Discount_CodeID");

                entity.HasOne(d => d.ChangeType)
                    .WithMany(p => p.DiscountChanges)
                    .HasForeignKey(d => d.ChangeTypeId)
                    .HasConstraintName("FK__Discount___Chang__05A3D694");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.DiscountChanges)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Discount___Custo__04AFB25B");

                entity.HasOne(d => d.DiscountCode)
                    .WithMany(p => p.DiscountChanges)
                    .HasForeignKey(d => d.DiscountCodeId)
                    .HasConstraintName("FK__Discount___Disco__03BB8E22");
            });

            modelBuilder.Entity<DiscountCode>(entity =>
            {
                entity.ToTable("Discount_Code");

                entity.Property(e => e.DiscountCodeId).HasColumnName("Discount_CodeID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_At")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentUsages).HasColumnName("Current_Usages");

                entity.Property(e => e.DiscountAmount).HasColumnName("Discount_Amount");

                entity.Property(e => e.DiscountPercentage).HasColumnName("Discount_Percentage");

                entity.Property(e => e.MaxUsages).HasColumnName("Max_Usages");

                entity.Property(e => e.MinimumOrderAmount).HasColumnName("Minimum_Order_Amount");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_At")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("Valid_From")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasColumnName("Valid_To")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderName).HasColumnName("Gender_Name");
            });

            modelBuilder.Entity<Mail>(entity =>
            {
                entity.Property(e => e.MailId).HasColumnName("MailID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Email_Address");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerID");

                entity.HasIndex(e => e.DiscountCodeId, "IX_Orders_Discount_CodeID");

                entity.HasIndex(e => e.OrderStatusId, "IX_Orders_Order_StatusID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DiscountAmount).HasColumnName("Discount_Amount");

                entity.Property(e => e.DiscountCodeId).HasColumnName("Discount_CodeID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderStatusId).HasColumnName("Order_StatusID");

                entity.Property(e => e.TotalAmoint).HasColumnName("Total_Amoint");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Time")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Order_Address");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__58D1301D");

                entity.HasOne(d => d.DiscountCode)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DiscountCodeId)
                    .HasConstraintName("FK__Orders__Discount__5AB9788F");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK__Orders__Order_St__59C55456");
            });

            modelBuilder.Entity<OrderChange>(entity =>
            {
                entity.ToTable("Order_Changes");

                entity.HasIndex(e => e.ChangeTypeId, "IX_Order_Changes_Change_TypeID");

                entity.HasIndex(e => e.CustomerId, "IX_Order_Changes_CustomerID");

                entity.HasIndex(e => e.OrderId, "IX_Order_Changes_OrderID");

                entity.Property(e => e.OrderChangeId).HasColumnName("Order_ChangeID");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Change_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ChangeDescription).HasColumnName("Change_Description");

                entity.Property(e => e.ChangeTypeId).HasColumnName("Change_TypeID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.ChangeType)
                    .WithMany(p => p.OrderChanges)
                    .HasForeignKey(d => d.ChangeTypeId)
                    .HasConstraintName("FK__Order_Cha__Chang__0B5CAFEA");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderChanges)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Order_Cha__Custo__0A688BB1");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderChanges)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_Cha__Order__09746778");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_Details");

                entity.HasIndex(e => e.OrderId, "IX_Order_Details_OrderID");

                entity.HasIndex(e => e.ProductId, "IX_Order_Details_ProductID");

                entity.Property(e => e.OrderDetailId).HasColumnName("Order_DetailID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_At")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasColumnName("Product_Name");

                entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Time")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_Det__Order__5F7E2DAC");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_Det__Produ__607251E5");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("Order_Status");

                entity.Property(e => e.OrderStatusId).HasColumnName("Order_StatusID");

                entity.Property(e => e.StatusName).HasColumnName("Status_Name");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.PermissionName).HasColumnName("Permission_Name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.BrandId, "IX_Product_BrandID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.Expiry)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InventoryQuantity)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Inventory_Quantity");

                entity.Property(e => e.ProductName).HasColumnName("Product_Name");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__BrandID__7A672E12");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("Product_Category");

                entity.HasIndex(e => e.CategoryId, "IX_Product_Category_CategoryID");

                entity.HasIndex(e => e.ProductId, "IX_Product_Category_ProductID");

                entity.Property(e => e.ProductCategoryId).HasColumnName("Product_CategoryID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product_C__Categ__32AB8735");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Product_C__Produ__31B762FC");
            });

            modelBuilder.Entity<ProductChange>(entity =>
            {
                entity.ToTable("Product_Changes");

                entity.HasIndex(e => e.ChangeTypeId, "IX_Product_Changes_Change_TypeID");

                entity.HasIndex(e => e.CustomerId, "IX_Product_Changes_CustomerID");

                entity.HasIndex(e => e.ProductId, "IX_Product_Changes_ProductID");

                entity.Property(e => e.ProductChangeId).HasColumnName("Product_ChangeID");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Change_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ChangeDescription).HasColumnName("Change_Description");

                entity.Property(e => e.ChangeTypeId).HasColumnName("Change_TypeID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.ChangeType)
                    .WithMany(p => p.ProductChanges)
                    .HasForeignKey(d => d.ChangeTypeId)
                    .HasConstraintName("FK__Product_C__Chang__7FEAFD3E");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductChanges)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Product_C__Custo__7EF6D905");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductChanges)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Product_C__Produ__7E02B4CC");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.ProductImagesId)
                    .HasName("PK__Product___46EC27B11133E25B");

                entity.ToTable("Product_Images");

                entity.HasIndex(e => e.ProductId, "IX_Product_Images_ProductID");

                entity.Property(e => e.ProductImagesId).HasColumnName("Product_ImagesID");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Image_Url");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Product_I__Produ__3587F3E0");
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasKey(e => e.ProductReviewsId)
                    .HasName("PK__Product___F25AB493DEBFBDEE");

                entity.ToTable("Product_Reviews");

                entity.HasIndex(e => e.CustomerId, "IX_Product_Reviews_CustomerID");

                entity.HasIndex(e => e.ProductId, "IX_Product_Reviews_ProductID");

                entity.Property(e => e.ProductReviewsId).HasColumnName("Product_ReviewsID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_At")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_At")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Product_R__Custo__1EA48E88");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Product_R__Produ__1DB06A4F");
            });

            modelBuilder.Entity<ProfileImage>(entity =>
            {
                entity.ToTable("Profile_Image");

                entity.Property(e => e.ProfileImageId).HasColumnName("Profile_ImageID");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Image_URL");
            });

            modelBuilder.Entity<ReviewImage>(entity =>
            {
                entity.HasKey(e => e.ReviewImages)
                    .HasName("PK__Review_I__3251BD3790172C85");

                entity.ToTable("Review_Images");

                entity.HasIndex(e => e.ProductReviewsId, "IX_Review_Images_Product_ReviewsID");

                entity.Property(e => e.ReviewImages).HasColumnName("Review_Images");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Image_Url");

                entity.Property(e => e.ProductReviewsId).HasColumnName("Product_ReviewsID");

                entity.HasOne(d => d.ProductReviews)
                    .WithMany(p => p.ReviewImages)
                    .HasForeignKey(d => d.ProductReviewsId)
                    .HasConstraintName("FK__Review_Im__Produ__2180FB33");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasColumnName("Role_Name");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Role_Permissions");

                entity.HasIndex(e => e.PermissionId, "IX_Role_Permissions_PermissionID");

                entity.HasIndex(e => e.RoleId, "IX_Role_Permissions_RoleID");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Permission)
                    .WithMany()
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__Role_Perm__Permi__41EDCAC5");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Role_Perm__RoleI__42E1EEFE");
            });

            modelBuilder.Entity<StatusAcc>(entity =>
            {
                entity.ToTable("Status_Acc");

                entity.Property(e => e.StatusAccId).HasColumnName("Status_AccID");

                entity.Property(e => e.StatusAccName).HasColumnName("Status_Acc_Name");
            });

            modelBuilder.Entity<StoreInfo>(entity =>
            {
                entity.ToTable("Store_Info");

                entity.Property(e => e.StoreInfoId).HasColumnName("Store_InfoID");

                entity.Property(e => e.BannerUrl).HasColumnName("Banner_URL");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_At")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LogoUrl).HasColumnName("Logo_URL");

                entity.Property(e => e.StoreName).HasColumnName("Store_Name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_At")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UiChange>(entity =>
            {
                entity.ToTable("UI_Changes");

                entity.HasIndex(e => e.ChangeTypeId, "IX_UI_Changes_Change_TypeID");

                entity.HasIndex(e => e.CustomerId, "IX_UI_Changes_CustomerID");

                entity.HasIndex(e => e.StoreInfoId, "IX_UI_Changes_Store_InfoID");

                entity.Property(e => e.UiChangeId).HasColumnName("UI_ChangeID");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Change_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ChangeDescription).HasColumnName("Change_Description");

                entity.Property(e => e.ChangeTypeId).HasColumnName("Change_TypeID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.StoreInfoId).HasColumnName("Store_InfoID");

                entity.HasOne(d => d.ChangeType)
                    .WithMany(p => p.UiChanges)
                    .HasForeignKey(d => d.ChangeTypeId)
                    .HasConstraintName("FK__UI_Change__Chang__7A3223E8");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.UiChanges)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__UI_Change__Custo__793DFFAF");

                entity.HasOne(d => d.StoreInfo)
                    .WithMany(p => p.UiChanges)
                    .HasForeignKey(d => d.StoreInfoId)
                    .HasConstraintName("FK__UI_Change__Store__7849DB76");
            });

            modelBuilder.Entity<UserChange>(entity =>
            {
                entity.ToTable("User_Changes");

                entity.HasIndex(e => e.AdminId, "IX_User_Changes_AdminID");

                entity.HasIndex(e => e.ChangeTypeId, "IX_User_Changes_Change_TypeID");

                entity.HasIndex(e => e.CustomerId, "IX_User_Changes_CustomerID");

                entity.Property(e => e.UserChangeId).HasColumnName("User_ChangeID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Change_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ChangeDescription).HasColumnName("Change_Description");

                entity.Property(e => e.ChangeTypeId).HasColumnName("Change_TypeID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.UserChangeAdmins)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK__User_Chan__Admin__0F2D40CE");

                entity.HasOne(d => d.ChangeType)
                    .WithMany(p => p.UserChanges)
                    .HasForeignKey(d => d.ChangeTypeId)
                    .HasConstraintName("FK__User_Chan__Chang__11158940");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.UserChangeCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__User_Chan__Custo__10216507");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
