using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Resident
    {
        public int Id { get; set; }
        public string NameAndSurname { get; set; }
        public string TcNo { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string VehiclePlateNumber { get; set; }
        public int UserId { get; set; }
        public int NotificationId { get; set; }
        public int PaymentId { get; set; }
        public int FlatId { get; set; }
    }
}
