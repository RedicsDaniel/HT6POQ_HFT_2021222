using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HT6POQ_HTF_2021222.Models
{
    public class Shop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
        public Shop()
        {
            Books = new HashSet<Book>();
        }
    }
}
