using System.ComponentModel.DataAnnotations;

namespace PROG7311.Models
{
    public class Product
    {
        [Key]
        public int productID { get; set; }
        public int farmerID { get; set; }
        public String productName { get; set; }
        public String productDescription { get; set; }
        public String productCategory { get; set; }
        public DateOnly dateAdded { get; set; }

        public Farmer farmer {get; set;}
}
}
