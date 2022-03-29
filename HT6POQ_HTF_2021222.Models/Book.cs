using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HTF_2021222.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageNumber { get; set; }
        public BookType Type { get;set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        [ForeignKey(nameof(Shop))]
        public int ShopId { get; set; }
        [NotMapped]
        public virtual Author Author { get; set; }
        [NotMapped]
        public virtual Shop Shop { get; set; }
    }
}
