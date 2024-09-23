using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISuperMarket.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number_Of_Products = table.Column<int>(type: "int", nullable: true),
                    Total_Stars = table.Column<double>(type: "float", nullable: true),
                    Logo_Brand_Url = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Change_Type",
                columns: table => new
                {
                    Change_TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Change_Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Change_Type", x => x.Change_TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Discount_Code",
                columns: table => new
                {
                    Discount_CodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount_Percentage = table.Column<int>(type: "int", nullable: true),
                    Discount_Amount = table.Column<double>(type: "float", nullable: true),
                    Valid_From = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Valid_To = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Minimum_Order_Amount = table.Column<double>(type: "float", nullable: true),
                    Max_Usages = table.Column<int>(type: "int", nullable: true),
                    Current_Usages = table.Column<int>(type: "int", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_Code", x => x.Discount_CodeID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Mail",
                columns: table => new
                {
                    MailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email_Address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mail", x => x.MailID);
                });

            migrationBuilder.CreateTable(
                name: "Order_Status",
                columns: table => new
                {
                    Order_StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Status", x => x.Order_StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permission_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "Profile_Image",
                columns: table => new
                {
                    Profile_ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_URL = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile_Image", x => x.Profile_ImageID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Status_Acc",
                columns: table => new
                {
                    Status_AccID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Acc_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_Acc", x => x.Status_AccID);
                });

            migrationBuilder.CreateTable(
                name: "Store_Info",
                columns: table => new
                {
                    Store_InfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Store_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Info", x => x.Store_InfoID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    BrandID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiry = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Inventory_Quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK__Product__BrandID__7A672E12",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "BrandID");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailID = table.Column<int>(type: "int", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    GenderID = table.Column<int>(type: "int", nullable: true),
                    Profile_ImageID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK__Customer__Gender__66603565",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID");
                    table.ForeignKey(
                        name: "FK__Customer__MailID__6754599E",
                        column: x => x.MailID,
                        principalTable: "Mail",
                        principalColumn: "MailID");
                    table.ForeignKey(
                        name: "FK__Customer__Profil__68487DD7",
                        column: x => x.Profile_ImageID,
                        principalTable: "Profile_Image",
                        principalColumn: "Profile_ImageID");
                });

            migrationBuilder.CreateTable(
                name: "Role_Permissions",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Role_Perm__Permi__41EDCAC5",
                        column: x => x.PermissionID,
                        principalTable: "Permission",
                        principalColumn: "PermissionID");
                    table.ForeignKey(
                        name: "FK__Role_Perm__RoleI__42E1EEFE",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Product_Category",
                columns: table => new
                {
                    Product_CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Category", x => x.Product_CategoryID);
                    table.ForeignKey(
                        name: "FK__Product_C__Categ__32AB8735",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK__Product_C__Produ__31B762FC",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "Product_Images",
                columns: table => new
                {
                    Product_ImagesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Image_Url = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product___46EC27B11133E25B", x => x.Product_ImagesID);
                    table.ForeignKey(
                        name: "FK__Product_I__Produ__3587F3E0",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "Acc_Customer",
                columns: table => new
                {
                    Acc_CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    User_Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Hash_Pass = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Auth_Provider = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ProviderID = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Date_Creation = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Status_AccID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acc_Customer", x => x.Acc_CustomerID);
                    table.ForeignKey(
                        name: "FK__Acc_Custo__Statu__489AC854",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Acc_Custo__Statu__498EEC8D",
                        column: x => x.Status_AccID,
                        principalTable: "Status_Acc",
                        principalColumn: "Status_AccID");
                });

            migrationBuilder.CreateTable(
                name: "Bank_Account",
                columns: table => new
                {
                    Bank_AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Bank_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account_Holder_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account_Number = table.Column<double>(type: "float", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Updated_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank_Account", x => x.Bank_AccountID);
                    table.ForeignKey(
                        name: "FK__Bank_Acco__Custo__08B54D69",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Brand_Changes",
                columns: table => new
                {
                    Brand_ChangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Change_TypeID = table.Column<int>(type: "int", nullable: true),
                    Change_Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Change_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand_Changes", x => x.Brand_ChangeID);
                    table.ForeignKey(
                        name: "FK__Brand_Cha__Brand__14E61A24",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "BrandID");
                    table.ForeignKey(
                        name: "FK__Brand_Cha__Chang__16CE6296",
                        column: x => x.Change_TypeID,
                        principalTable: "Change_Type",
                        principalColumn: "Change_TypeID");
                    table.ForeignKey(
                        name: "FK__Brand_Cha__Custo__15DA3E5D",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                    table.ForeignKey(
                        name: "FK__Cart__CustomerID__160F4887",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Customer_Roles",
                columns: table => new
                {
                    Customer_RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Roles", x => x.Customer_RoleID);
                    table.ForeignKey(
                        name: "FK__Customer___Custo__3E1D39E1",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Customer___RoleI__3D2915A8",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Discount_Changes",
                columns: table => new
                {
                    Discount_ChangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount_CodeID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Change_TypeID = table.Column<int>(type: "int", nullable: true),
                    Change_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Change_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_Changes", x => x.Discount_ChangeID);
                    table.ForeignKey(
                        name: "FK__Discount___Chang__05A3D694",
                        column: x => x.Change_TypeID,
                        principalTable: "Change_Type",
                        principalColumn: "Change_TypeID");
                    table.ForeignKey(
                        name: "FK__Discount___Custo__04AFB25B",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Discount___Disco__03BB8E22",
                        column: x => x.Discount_CodeID,
                        principalTable: "Discount_Code",
                        principalColumn: "Discount_CodeID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Order_StatusID = table.Column<int>(type: "int", nullable: true),
                    Discount_CodeID = table.Column<int>(type: "int", nullable: true),
                    Total_Amoint = table.Column<double>(type: "float", nullable: true),
                    Discount_Amount = table.Column<double>(type: "float", nullable: true),
                    Order_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Orders__Customer__58D1301D",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Orders__Discount__5AB9788F",
                        column: x => x.Discount_CodeID,
                        principalTable: "Discount_Code",
                        principalColumn: "Discount_CodeID");
                    table.ForeignKey(
                        name: "FK__Orders__Order_St__59C55456",
                        column: x => x.Order_StatusID,
                        principalTable: "Order_Status",
                        principalColumn: "Order_StatusID");
                });

            migrationBuilder.CreateTable(
                name: "Product_Changes",
                columns: table => new
                {
                    Product_ChangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Change_TypeID = table.Column<int>(type: "int", nullable: true),
                    Change_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Change_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Changes", x => x.Product_ChangeID);
                    table.ForeignKey(
                        name: "FK__Product_C__Chang__7FEAFD3E",
                        column: x => x.Change_TypeID,
                        principalTable: "Change_Type",
                        principalColumn: "Change_TypeID");
                    table.ForeignKey(
                        name: "FK__Product_C__Custo__7EF6D905",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Product_C__Produ__7E02B4CC",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "Product_Reviews",
                columns: table => new
                {
                    Product_ReviewsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product___F25AB493DEBFBDEE", x => x.Product_ReviewsID);
                    table.ForeignKey(
                        name: "FK__Product_R__Custo__1EA48E88",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Product_R__Produ__1DB06A4F",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "UI_Changes",
                columns: table => new
                {
                    UI_ChangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Store_InfoID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Change_TypeID = table.Column<int>(type: "int", nullable: true),
                    Change_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Change_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UI_Changes", x => x.UI_ChangeID);
                    table.ForeignKey(
                        name: "FK__UI_Change__Chang__7A3223E8",
                        column: x => x.Change_TypeID,
                        principalTable: "Change_Type",
                        principalColumn: "Change_TypeID");
                    table.ForeignKey(
                        name: "FK__UI_Change__Custo__793DFFAF",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__UI_Change__Store__7849DB76",
                        column: x => x.Store_InfoID,
                        principalTable: "Store_Info",
                        principalColumn: "Store_InfoID");
                });

            migrationBuilder.CreateTable(
                name: "User_Changes",
                columns: table => new
                {
                    User_ChangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Change_TypeID = table.Column<int>(type: "int", nullable: true),
                    Change_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Change_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Changes", x => x.User_ChangeID);
                    table.ForeignKey(
                        name: "FK__User_Chan__Admin__0F2D40CE",
                        column: x => x.AdminID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__User_Chan__Chang__11158940",
                        column: x => x.Change_TypeID,
                        principalTable: "Change_Type",
                        principalColumn: "Change_TypeID");
                    table.ForeignKey(
                        name: "FK__User_Chan__Custo__10216507",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Cart_Products",
                columns: table => new
                {
                    Cart_ProductsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    CartID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart_Pro__A080AFB0CFC975CE", x => x.Cart_ProductsID);
                    table.ForeignKey(
                        name: "FK__Cart_Prod__CartI__18EBB532",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "CartID");
                    table.ForeignKey(
                        name: "FK__Cart_Prod__Produ__17F790F9",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "Bank_Transfers",
                columns: table => new
                {
                    Bank_TransferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    Bank_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account_Number = table.Column<double>(type: "float", nullable: true),
                    Account_Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Transfer_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank_Transfers", x => x.Bank_TransferID);
                    table.ForeignKey(
                        name: "FK__Bank_Tran__Order__662B2B3B",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "Order_Changes",
                columns: table => new
                {
                    Order_ChangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    Change_TypeID = table.Column<int>(type: "int", nullable: true),
                    Change_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Change_Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Changes", x => x.Order_ChangeID);
                    table.ForeignKey(
                        name: "FK__Order_Cha__Chang__0B5CAFEA",
                        column: x => x.Change_TypeID,
                        principalTable: "Change_Type",
                        principalColumn: "Change_TypeID");
                    table.ForeignKey(
                        name: "FK__Order_Cha__Custo__0A688BB1",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Order_Cha__Order__09746778",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    Order_DetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Total_Price = table.Column<double>(type: "float", nullable: true),
                    Create_At = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_Time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => x.Order_DetailID);
                    table.ForeignKey(
                        name: "FK__Order_Det__Order__5F7E2DAC",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK__Order_Det__Produ__607251E5",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "Review_Images",
                columns: table => new
                {
                    Review_Images = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_Url = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Product_ReviewsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Review_I__3251BD3790172C85", x => x.Review_Images);
                    table.ForeignKey(
                        name: "FK__Review_Im__Produ__2180FB33",
                        column: x => x.Product_ReviewsID,
                        principalTable: "Product_Reviews",
                        principalColumn: "Product_ReviewsID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acc_Customer_CustomerID",
                table: "Acc_Customer",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Acc_Customer_Status_AccID",
                table: "Acc_Customer",
                column: "Status_AccID");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_Account_CustomerID",
                table: "Bank_Account",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_Transfers_OrderID",
                table: "Bank_Transfers",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Changes_BrandID",
                table: "Brand_Changes",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Changes_Change_TypeID",
                table: "Brand_Changes",
                column: "Change_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Changes_CustomerID",
                table: "Brand_Changes",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerID",
                table: "Cart",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Products_CartID",
                table: "Cart_Products",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Products_ProductID",
                table: "Cart_Products",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_GenderID",
                table: "Customer",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_MailID",
                table: "Customer",
                column: "MailID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Profile_ImageID",
                table: "Customer",
                column: "Profile_ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Roles_CustomerID",
                table: "Customer_Roles",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Roles_RoleID",
                table: "Customer_Roles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Changes_Change_TypeID",
                table: "Discount_Changes",
                column: "Change_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Changes_CustomerID",
                table: "Discount_Changes",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Changes_Discount_CodeID",
                table: "Discount_Changes",
                column: "Discount_CodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Changes_Change_TypeID",
                table: "Order_Changes",
                column: "Change_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Changes_CustomerID",
                table: "Order_Changes",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Changes_OrderID",
                table: "Order_Changes",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_OrderID",
                table: "Order_Details",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_ProductID",
                table: "Order_Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Discount_CodeID",
                table: "Orders",
                column: "Discount_CodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_StatusID",
                table: "Orders",
                column: "Order_StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_CategoryID",
                table: "Product_Category",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_ProductID",
                table: "Product_Category",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Changes_Change_TypeID",
                table: "Product_Changes",
                column: "Change_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Changes_CustomerID",
                table: "Product_Changes",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Changes_ProductID",
                table: "Product_Changes",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Images_ProductID",
                table: "Product_Images",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Reviews_CustomerID",
                table: "Product_Reviews",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Reviews_ProductID",
                table: "Product_Reviews",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Images_Product_ReviewsID",
                table: "Review_Images",
                column: "Product_ReviewsID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_PermissionID",
                table: "Role_Permissions",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_RoleID",
                table: "Role_Permissions",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UI_Changes_Change_TypeID",
                table: "UI_Changes",
                column: "Change_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UI_Changes_CustomerID",
                table: "UI_Changes",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_UI_Changes_Store_InfoID",
                table: "UI_Changes",
                column: "Store_InfoID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Changes_AdminID",
                table: "User_Changes",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Changes_Change_TypeID",
                table: "User_Changes",
                column: "Change_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Changes_CustomerID",
                table: "User_Changes",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acc_Customer");

            migrationBuilder.DropTable(
                name: "Bank_Account");

            migrationBuilder.DropTable(
                name: "Bank_Transfers");

            migrationBuilder.DropTable(
                name: "Brand_Changes");

            migrationBuilder.DropTable(
                name: "Cart_Products");

            migrationBuilder.DropTable(
                name: "Customer_Roles");

            migrationBuilder.DropTable(
                name: "Discount_Changes");

            migrationBuilder.DropTable(
                name: "Order_Changes");

            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "Product_Category");

            migrationBuilder.DropTable(
                name: "Product_Changes");

            migrationBuilder.DropTable(
                name: "Product_Images");

            migrationBuilder.DropTable(
                name: "Review_Images");

            migrationBuilder.DropTable(
                name: "Role_Permissions");

            migrationBuilder.DropTable(
                name: "UI_Changes");

            migrationBuilder.DropTable(
                name: "User_Changes");

            migrationBuilder.DropTable(
                name: "Status_Acc");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product_Reviews");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Store_Info");

            migrationBuilder.DropTable(
                name: "Change_Type");

            migrationBuilder.DropTable(
                name: "Discount_Code");

            migrationBuilder.DropTable(
                name: "Order_Status");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Mail");

            migrationBuilder.DropTable(
                name: "Profile_Image");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
