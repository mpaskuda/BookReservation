using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReservationAPI.Models
{
    [Table("Reservations")]
    public class ReservationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }

        public int BookID { get; set; }

        public DateTime ReservationDate { get; set; }

    }
}
