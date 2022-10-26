using Shop1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PagedList;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using Shop1.ViewModel;
namespace Shop1.Controllers
{
    
    public class CategoryController : Controller
    {
        DBContext con = new DBContext();
        // GET: Category
        public class listofSegments
        {
            public string Text { get; set; }
            public string Value { get; set; }


        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DanhMucHSXPartial()
        {
            var hang_sx = con.HangSanXuat.ToList();
            return PartialView(hang_sx);
        }


        public PartialViewResult SanPhamTheoDanhMuc(string id, int page = 1, int pageSize = 6)
        {
            var segmentList = new List<listofSegments>();
            listofSegments segmentItem;
            var sizeArr = new string[] { "6", "9", "12", "15" };
            for(int idx = 0; idx < sizeArr.Length; idx++ )
            {
                segmentItem = new listofSegments();
                segmentItem.Text = sizeArr[idx];
                segmentItem.Value = sizeArr[idx];
                segmentList.Add(segmentItem);
            }
            ViewBag.segmentList = segmentList;

            HangSanXuat dm_HSX = con.HangSanXuat.SingleOrDefault(x => x.TenHang == id);
            if (dm_HSX == null)
            {
                Console.WriteLine("tungp");
            }
            List<SanPham> sanphams = con.SanPham.Where(x => x.HangSX == dm_HSX.HangSX).ToList();
            ViewBag.hangsx = id;
            var model = sanphams.OrderByDescending(x => x.GiaGoc).ToPagedList(page, pageSize);
            return PartialView(model);
        }



        //them code doan nay nha
        public ActionResult single_product(string id)
        {



            dynamic model = new ExpandoObject();
            model.sanpham = new DetailsViewModel().SPViewDetail(id);
            ViewBag.category = new DetailsViewModel().HViewDetail(model.sanpham.HangSX);
            model.ctsp = new DetailsViewModel().listCTSP(id);
            model.size = new DetailsViewModel().listSize(id);
            model.listSP = con.SanPham.ToList();
            return View(model);

        }

    }
}