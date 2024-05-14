using Aplikasi_SPK_Kepuasan_Pasien.Models;
using Aplikasi_SPK_Kepuasan_Pasien.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aplikasi_SPK_Kepuasan_Pasien.Controllers
{
    public class SettingController : Controller
    {
        VMUser vm = new VMUser();

        public ActionResult Index()
        {
            if (Session["nama"] == null)
            {
                return RedirectToAction("index", "login");
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            IList<TBL_T_LOGIN> data = new List<TBL_T_LOGIN>();
            try
            {
                data = vm.GetUser();
                return new JsonResult() { Data = new { Data = data }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new { Data = data, ex.Message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
            }
        }

        [HttpGet]
        public JsonResult GetUser(int id)
        {
            TBL_T_LOGIN data = new TBL_T_LOGIN();
            try
            {
                data = vm.GetUser(id);
                return new JsonResult() { Data = new { Data = data }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new { Data = data, ex.Message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
            }
        }

        [HttpPost]
        public ActionResult InsertUser(TBL_T_LOGIN data)
        {
            try
            {
                if (vm.isEmailExist(data.email)) return Json(new { Remarks = false, Message = "Email Exist", JsonRequestBehavior.AllowGet });
                vm.InsertUser(data);
                return Json(new { Remarks = true, Message = "Insert Success", JsonRequestBehavior.AllowGet });

            }
            catch (Exception e)
            {
                return Json(new { Remarks = false, e.Message, JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        public ActionResult UpdateUser(TBL_T_LOGIN data)
        {
            try
            {
                if (vm.isEmailUpdateExist(data.email, data.id)) return Json(new { Remarks = false, Message = "Email Exist", JsonRequestBehavior.AllowGet });
                vm.UpdateUser(data);
                return Json(new { Remarks = true, Message = "Update Success", JsonRequestBehavior.AllowGet });

            }
            catch (Exception e)
            {
                return Json(new { Remarks = false, e.Message, JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                vm.DeleteUser(id);
                return Json(new { Remarks = true, Message = "Delete Success" });
            }
            catch (Exception e)
            {
                return Json(new { Remarks = false, Message = e.Message });
            }
        }

    }
}