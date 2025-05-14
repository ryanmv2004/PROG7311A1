using PROG7311.Models;
using System;
using System.Collections.Generic;

namespace PROG7311.ViewModels
{
    //View model to be able to pass data to the cshtml file to display the data
    public class DisplayViewModel
    {
        public List<Farmer> Farmers { get; set; }
        public List<Product> Products { get; set; }
        public int? SelectedFarmerId { get; set; }
        public DateTime? SelectedDate { get; set; }
        public string SelectedCategory { get; set; }
        public List<string> Categories { get; set; }
    }
}
