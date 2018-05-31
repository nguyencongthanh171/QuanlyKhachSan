using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKSOmni.Models;
using System.IO;
namespace QuanLyKSOmni.Controllers
{
    public class DatPhongController : Controller
    {
        qlksDataContext db = new qlksDataContext();
        // GET: DatPhong
        public ActionResult Index()
        {
            return View();
        }
        public string RandomSPDT(string a)
        {
            Random rnd = new Random();
            a = rnd.Next(1, 10000000).ToString();
            return a;
        }
        public string RandomSPTP(string a)
        {
            Random rnd = new Random();
            a = rnd.Next(1, 10000000).ToString();
            return a;
        }
        [HttpGet]
        public ActionResult DatPhong()
        {

            ViewBag.MaPhong = new SelectList(db.PHONGs.ToList().OrderBy(n => n.TenPhong), "MaPhong", "TenPhong");
            return View();
        }
        [HttpPost]
        public ActionResult DatPhong(FormCollection collection, KHACHHANG kh, THUEPHONG th, DATPHONG dp,PHONG p)
        {
            ViewBag.MaPhong = new SelectList(db.PHONGs.ToList().OrderBy(n => n.TenPhong), "MaPhong", "TenPhong");
            string spdt = "";
            string sptp = "";
            Random rnd = new Random();
            var makh = rnd.Next(1, 10000000);
       
            var tenkh = collection["TenKH"];
            var sdt = collection["SDT"];
            var cmnd = collection["CMND"];
            var passport = collection["PassPort"];
            var ngaydat = string.Format("{0:dd/MM/yyyy}", collection["NgayDat"]);
            var maphong = collection["MaPhong"];
            var ngayden = string.Format("{0:dd/MM/yyyy}", collection["NgayDen"]);
            var ngaydi = string.Format("{0:dd/MM/yyyy}", collection["NgayDi"]);
            kh.MaKH = makh.ToString();
            kh.HoTen = tenkh;
            int sdt1 = int.Parse(sdt);
            kh.SDT = sdt1;
            int cmnd1 = int.Parse(cmnd);
            kh.CMND = cmnd1;
           
            kh.Passport = passport;
            kh.PhanLoaiKH = "ThuePhong";
            dp.SoPhieuDP = RandomSPDT(spdt);
            dp.MaKH = makh.ToString();
            dp.NgayDat = DateTime.Parse(ngaydat).ToShortDateString();
            dp.TienDat = 5000000;
            th.SoPhieuTP = RandomSPTP(sptp);
            th.SoPhieuDP = dp.SoPhieuDP;
            th.MaKH = makh.ToString();
            th.MaPhong = maphong;
            th.Ngayden= DateTime.Parse(ngayden).ToShortDateString();
            th.Ngaydi= DateTime.Parse(ngaydi).ToShortDateString();
            if (maphong == p.MaPhong)
                p.Tinhtrang = "Đã Thuê";
            db.KHACHHANGs.InsertOnSubmit(kh);
            db.DATPHONGs.InsertOnSubmit(dp);
            db.THUEPHONGs.InsertOnSubmit(th);
            UpdateModel(p);
            db.SubmitChanges();
            ViewBag.ThongBao = "Đã đặt phòng thành công";
            return View();
        }
    }
}