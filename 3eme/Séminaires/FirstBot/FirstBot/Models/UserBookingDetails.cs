using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBot.Models
{
    public class UserBookingDetails
    {
        public BookingDetails BookingDetails { get; set; }
        public UserDetails UserDetails { get; set; }
    }
}
