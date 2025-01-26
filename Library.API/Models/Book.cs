﻿using System.ComponentModel.DataAnnotations;

namespace Library.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ISBN { get; set; }

        [Range(0, Int32.MaxValue)]
        public required int AvailableCount { get; set; }


        public virtual ICollection<Author>? Authors { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
