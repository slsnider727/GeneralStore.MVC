using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; } = DateTime.Now;
        public List<Product> Cart { get; set; } = new List<Product>();
        public decimal Total
        {
            get
            {
                decimal total = 0m;
                foreach (Product product in Cart)
                {
                    if (product.IsFood)
                    {
                        total += product.Price;
                    }
                    total += (product.Price * 1.07m);
                }
                return total;
            }
        }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}