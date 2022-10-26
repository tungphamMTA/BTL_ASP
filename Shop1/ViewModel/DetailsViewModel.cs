using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop1.Models;
namespace Shop1.ViewModel
{
    public class DetailsViewModel
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

        /*public Li SzViewDetail(string idsp, string idcl)
        {
            return db.CTSPs.Find(idsp, idcl);
        }*/
        /*        public List<ThongTinSP> anhsp(string id)
                {
                    IEnumerable<IGrouping<string, string>> model = (from a in db.SanPhams
                                              join b in db.CTSPs on a.MaSP equals b.MaSP //into anhsp
                                                                                         //from b in db.CTSPs
                                              where a.MaSP == id
                                              select new ThongTinSP()
                                              {
                                                  Anhdaidien = a.AnhDaiDien,
                                                  Anhnen = a.AnhNen,
                                                  TenSP = a.TenSP,
                                                  Mota = a.MoTa,
                                                  SoluotxemSP = a.SoLuotXemSP,
                                                  AnhSP = b.AnhSP
                                              }
                               );
                    return model.ToList();
                }
        */
        /*public List<DetailsViewModel> ListByIDSanPham(string id)
        {
            var model = from a in 
        }*/
        /*    public List<SanPham> ListAll()
            {
                return Shoes_Shop.Models.Context.HangSanXuat
            }*/

    }
}