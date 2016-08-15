using MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }

        public Category PreviousCategory { get; set; }

        //State - to remember user's selection(s) 
        public Int32[] SelectedApps { get; set; }

        //All Apps for Selectlist etc.
        [DisplayName("Apps")]
        public IEnumerable<App> Apps { get; set; }
    }
}
