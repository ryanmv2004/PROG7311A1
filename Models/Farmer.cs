using System.ComponentModel.DataAnnotations;

namespace PROG7311.Models
{
    public class Farmer
    {
        [Key]
        public int farmerID { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String email { get; set; }
        public String password { get; set; }

        public List<Product>? products { get; set; }
    }
}
