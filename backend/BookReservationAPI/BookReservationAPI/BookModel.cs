using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReservationAPI.Models
{
    [Table("Books")]
    public class BookModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

    }
}

