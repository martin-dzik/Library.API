﻿using System.ComponentModel.DataAnnotations;

namespace Library.API.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ISBN { get; set; }
        public required int AvailableCount { get; set; }


        public virtual ICollection<Author>? Authors { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
