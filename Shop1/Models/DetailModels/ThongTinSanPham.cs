using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop1.Models.DetailModels
{
    public class ThongTinSanPham
    {
        public class ThongTinSP
        {
            public string TenSP { set; get; }
            public int? SoluotxemSP { set; get; }
            public int? Size { set; get; }
            public int? Soluong { set; get; }
            public decimal? GiaTien { set; get; }
            public decimal? GiaGoc { set; get; }
            public string AnhSP { set; get; }
            public string Anhdaidien { set; get; }
            public string Anhnen { set; get; }
            public string Mamau { set; get; }
            public string Mota { set; get; }
        }
        public class TenHangSX
        {
            public string tenhang { set; get; }
        }
        DBContext db = new DBContext();
        public SanPham SPViewDetail(string id)
        {
            return db.SanPham.Find(id);
        }
        public HangSanXuat HViewDetail(string id)
        {
            return db.HangSanXuat.Find(id);
        }

        public List<ThongTinSP> listCTSP(string id)
        {
            //return db.CTSPs.Where(x => x.MaSP == id).GroupBy(x => x.AnhSP).ToList();
            return db.CTSP.Where(x => x.MaSP == id).GroupBy(x => new { x.AnhSP, x.MaMau }).OrderBy(x => x.Key).Select(g => new ThongTinSP()
            {
                AnhSP = g.Key.AnhSP,
                Mamau = g.Key.MaMau
            }).ToList();
        }

        public List<ThongTinSP> listSize(string id)
        {
            return db.CTSP.Where(x => x.MaSP == id).GroupBy(x => new { x.Size }).OrderBy(x => x.Key).Select(g => new ThongTinSP()
            {
                Size = g.Key.Size
            }).ToList();
        }
    }
}