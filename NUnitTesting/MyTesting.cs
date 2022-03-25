using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Tour;
namespace NUnitTesting
{
    public class MyTesting
    {
        //Test nút đăng nhập
        [Test]
        public void Login_Test0()
        {
            Tour.LoginForm login = new LoginForm();
            login.email = "19522003@gm.uit.edu.vn";
            login.password = "123";
            Assert.True(login.Login());
        }
        //Test nút đăng nhập
        [Test]
        public void Login_Test1()
        {
            Tour.LoginForm login = new LoginForm();
            login.email = "19522144@gm.uit.edu.vn";
            login.password = "123";
            Assert.True(login.Login());
        }
        //Test đăng nhập thất bại
        [Test]
        public void Login_Test2()
        {
            Tour.LoginForm login = new LoginForm();
            login.email = "19522003@gm.uit.edu.vn";
            login.password = "3213123"; // sai mật khẩu
            Assert.False(login.Login());
        }
        //Test thêm tuyến vào hệ thống
        [Test]
        public void AddTuyen_Test0()
        {
            Tour.Route tuyen = new Route();
            tuyen.RouteName = "TuyenHaNoi";
            tuyen.Departure = "HCM";
            tuyen.Location = "HaNoi";
            tuyen.Days = "3";
            tuyen.Nights = "4";
            tuyen.RouteCode = "ROUTE1";
            tuyen.TypeofRoute = "National";
            Assert.True(tuyen.addTuyen());
        }
        //Test xóa tuyến khỏi hệ thống
        [Test]
        public void DeleteTuyen_Test0()
        {
            Tour.Route tuyen = new Route();
            tuyen.RouteID = "3b10cb77-3521-4315-8eb3-d102ba4158ee";
            Assert.True(tuyen.deleteTuyen());
        }
        //Test cập nhật thông tin tuyến vào hệ thống
        [Test]
        public void UpdateTuyen_Test0()
        {
            Tour.Route tuyen = new Route();
            tuyen.RouteID = "2ee8b79c-45f2-4af7-aaca-e70915058dde";
            tuyen.RouteName = "TuyenHaNoi";
            tuyen.Departure = "HCM";
            tuyen.Location = "HaNoi";
            tuyen.Days = "4";
            tuyen.Nights = "5";
            tuyen.RouteCode = "ROUTE1";
            tuyen.TypeofRoute = "National";
            Assert.True(tuyen.updateTuyen());
        }
        //Test thêm chuyến vào hệ thống
        [Test]
        public void AddChuyen_Test0()
        {
            Tour.Tour chuyen = new Tour.Tour();
            chuyen.RouteID = "b7238d9f-740e-45a6-9d89-448f99c6bfd2";
            chuyen.TourName = "TuyenNhaTrang";
            chuyen.TourCode = "TOUR01";
            chuyen.TypeofTour = "Regular";
            chuyen.Transport = "Plane";
            chuyen.Hour = 3;
            chuyen.Minute = 45;
            chuyen.Year = 2021;
            chuyen.Month = 10;
            chuyen.Day = 20;
            chuyen.Tickets = 100;
            chuyen.Price = 50000;
            Assert.True(chuyen.addChuyen());
        }
        //Test xóa chuyến khỏi hệ thống
        [Test]
        public void DeleteChuyen_Test0()
        {
            Tour.Tour tuyen = new Tour.Tour();
            tuyen.TourID = "663b592d-bdad-4d2e-95ee-9dace76d9027";
            Assert.True(tuyen.deleteChuyen());
        }
        //Test cập nhật thông tin chuyến vào hệ thống
        [Test]
        public void UpdateChuyen_Test0()
        {
            Tour.Tour chuyen = new Tour.Tour();
            chuyen.TourID =  "2aa7333e-ff63-4421-9c20-a80eeb90fc1c";
            chuyen.RouteID = "b7238d9f-740e-45a6-9d89-448f99c6bfd2";
            chuyen.TourName = "TuyenHaiPhong";
            chuyen.TourCode = "TOUR02";
            chuyen.TypeofTour = "Promotional";
            chuyen.Transport = "Passenger Car";
            chuyen.Hour = 3;
            chuyen.Minute = 45;
            chuyen.Year = 2021;
            chuyen.Month = 10;
            chuyen.Day = 20;
            chuyen.Tickets = 50;
            chuyen.Price = 60000;
            Assert.True(chuyen.updateChuyen());
        }
        //Test thêm thông tin khách hàng trong nước và vé vào hệ thống
        [Test]
        public void CreateCustomer_Test0()
        {
            Tour.DangKy dangky = new DangKy();
            dangky.SurName = "Thanh";
            dangky.Name = "V";
            dangky.address = "HCM";
            dangky.phonenumber = "09393829283";
            dangky.typeCus = "CUS001";
            dangky.gender = "Male";
            dangky.CMND = "321213";
            dangky.TourID = "6c7f4f3e-7512-48a0-a196-f4178d63cd1a";
            dangky.tourist = "Domestic";
            dangky.Year = 2021;
            dangky.Month = 1;
            dangky.Day = 1;
            dangky.vYear = 2021;
            dangky.vMonth = 2;
            dangky.vDay = 1;
            dangky.lephihoantra = 50000;
            dangky.typeoftour = "Tuyen An Giang - TPHCM";
            dangky.RouteID = "6c7f4f3e-7512-48a0-a196-f4178d63cd1a";
            dangky.TenChuyen = "Tuyen An Giang - TPHCM";
            Assert.True(dangky.CreateCustomer());
        }
        //Test thêm thông tin khách hàng nước ngoài và vé vào hệ thống
        [Test]
        public void CreateCustomer_Test1()
        {
            Tour.DangKy dangky = new DangKy();
            dangky.SurName = "Thanh D";
            dangky.Name = "D";
            dangky.address = "HANOI";
            dangky.phonenumber = "09239803210";
            dangky.typeCus = "CUS002";
            dangky.gender = "Male";
            dangky.CMND = "321333";
            dangky.Year = 2021;
            dangky.Month = 1;
            dangky.Day = 1;
            dangky.vYear = 2021;
            dangky.vMonth = 2;
            dangky.vDay = 1;
            dangky.TourID = "6c7f4f3e-7512-48a0-a196-f4178d63cd1a";
            dangky.tourist = "Foreign";
            dangky.lephihoantra = 50000;
            dangky.typeoftour = "Tuyen An Giang - TPHCM";
            dangky.RouteID = "6c7f4f3e-7512-48a0-a196-f4178d63cd1a";
            dangky.TenChuyen = "Tuyen An Giang - TPHCM";
            Assert.True(dangky.CreateCustomer());
        }
        //Test nút xóa khách hàng khỏi màn hình quản lý
        [Test]
        public void DeleteCustomer_Test0()
        {
            Tour.CSDLPhieuDatCho csdl = new CSDLPhieuDatCho();
            csdl.mave = "b9cfabcc-730a-411e-a82d-99ec159c5219";
            csdl.maphieu = "61b62dbd-fc06-4079-bf3a-6b3e13540f2a";
            csdl.madukhach = "6208a54f-0f38-45c2-b057-6e6d3332edf3";
            csdl.tourID = "6c7f4f3e-7512-48a0-a196-f4178d63cd1a";
            Assert.True(csdl.XoaKhach());
        }
    }
}
