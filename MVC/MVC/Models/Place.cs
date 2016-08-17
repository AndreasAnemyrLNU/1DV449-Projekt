using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Place
    {
        public Place()
        {
            this.Categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

        [DisplayName("Namn")]
        [StringLength(25, ErrorMessage = "Min 3 tecken, Max 25 tecken", MinimumLength = 3)]
        [Required(ErrorMessage = "Måste anges")]
        public string Name { get; set; }

        [Required(ErrorMessage = "En Adress måste anges")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Longitude får ej vara tomt")]
        public string Longitude { get; set; }

        [Required(ErrorMessage = "Latitiude får ej vara tomt")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "Beskrivning av plats är obligatorisk")]
        public string Description { get; set; }

        public string User { get; set; }

        [JsonIgnore]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
