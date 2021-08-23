using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Pictures
    {
        public int PicturesId { get; set; }
        public string UserId { get; set; }
        public string Category { get; set; }
        public string ShootName { get; set; }
        public string Image { get; set; }
    }
}
