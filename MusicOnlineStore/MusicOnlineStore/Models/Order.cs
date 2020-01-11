using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicOnlineStore.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int AddressID { get; set; }
        public int UserID { get; set; }
        public string OrderDate { get; set; }
    }
}
