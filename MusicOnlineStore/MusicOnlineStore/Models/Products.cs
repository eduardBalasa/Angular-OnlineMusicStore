using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicOnlineStore.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public byte Image { get; set; }
        public int CategoryID { get; set; }
    }
}
