﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT6POQ_HTF_2021222.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public int NumberOfBooks { get; set; }
        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() * Id*5;
        }
        public override string ToString()
        {
            return this.Name;
        }

    }
}