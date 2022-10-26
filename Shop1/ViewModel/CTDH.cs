using Shop1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop1.ViewModel
{
    public class CTDH
    {
        DBContext db = new DBContext();
        public class ChiTietDH
        {
            public string MaDH { get; set; }
            public string MaKH { get; set; }
            public string tinhtrang { get; set; }
            public float tongtien { get; set; }
            public DateTime Ngaymua { get; set; }
            public decimal PhiVC { get; set; }

        }
    }
}