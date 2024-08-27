using System;
using System.Collections.Generic;

namespace APISuperMarket.Models
{
    public partial class Customer
    {
        public Customer()
        {
            AccCustomers = new HashSet<AccCustomer>();
            BankAccounts = new HashSet<BankAccount>();
            BrandChanges = new HashSet<BrandChange>();
            Carts = new HashSet<Cart>();
            DiscountChanges = new HashSet<DiscountChange>();
            OrderChanges = new HashSet<OrderChange>();
            Orders = new HashSet<Order>();
            ProductChanges = new HashSet<ProductChange>();
            ProductReviews = new HashSet<ProductReview>();
            UiChanges = new HashSet<UiChange>();
            UserChangeAdmins = new HashSet<UserChange>();
            UserChangeCustomers = new HashSet<UserChange>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? MailId { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? GenderId { get; set; }
        public int? ProfileImageId { get; set; }

        public virtual Gender? Gender { get; set; }
        public virtual Mail? Mail { get; set; }
        public virtual ProfileImage? ProfileImage { get; set; }
        public virtual ICollection<AccCustomer> AccCustomers { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<BrandChange> BrandChanges { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<DiscountChange> DiscountChanges { get; set; }
        public virtual ICollection<OrderChange> OrderChanges { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductChange> ProductChanges { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<UiChange> UiChanges { get; set; }
        public virtual ICollection<UserChange> UserChangeAdmins { get; set; }
        public virtual ICollection<UserChange> UserChangeCustomers { get; set; }
    }
}
