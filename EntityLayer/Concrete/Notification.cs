using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public String NotificationType { get; set; }
        public String NotificationTypeSymbol { get; set; }  
        public String NotificationDetails { get; set; }
        public DateTime NotificationDate { get; set; }  
        public bool NotificationStatus { get; set; }
        public String NotificationColor { get; set; }
    }
}
