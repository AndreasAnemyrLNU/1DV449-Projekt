using MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class PlaceViewModel
    {
        public Place Place { get; set; }

        public Category PreviousPlace { get; set; }

        //State - to remember user's selection(s) 
        public Int32[] SelectedCategories { get; set; }

        //All Categories for Selectlist etc.
        [DisplayName("Category")]
        public IEnumerable<Category> Categories { get; set; }
    }
}
