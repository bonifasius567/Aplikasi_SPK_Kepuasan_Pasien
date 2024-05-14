using Aplikasi_SPK_Kepuasan_Pasien.Models;
using Aplikasi_SPK_Kepuasan_Pasien.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aplikasi_SPK_Kepuasan_Pasien.Controllers
{
    public class HomeController : Controller
    {
        VMKriteria vm = new VMKriteria();

        public ActionResult Index()
        {
            if (Session["nama"] == null)
            {
                return RedirectToAction("index", "login");
            }

            VMKriteria data = new VMKriteria
            {
                Kriterias = vm.GetKriteria(),
                KriteriaDetails = vm.GetKriteriaDetails(),
            };

            vm.HitungNilaiSAW();

            return View(data);
        }

        public ActionResult Survey()
        {
            VMKriteria data = new VMKriteria
            {
                Kriterias = vm.GetKriteria(),
                KriteriaDetails = vm.GetKriteriaDetails(),
            };

            return View(data);
        }

        public ActionResult Thanks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertAlternative(FormCollection form)
        {
            try
            {
                vm.InsertAlternative(form);
                return Json(new { Remarks = true, Message = "Insert Success", JsonRequestBehavior.AllowGet });

            }
            catch (Exception e)
            {
                return Json(new { Remarks = false, e.Message, JsonRequestBehavior.AllowGet });
            }
        }


        [HttpGet]
        public JsonResult GetListRekomedasi()
        {
            List<VW_REKOMENDASI_SAW> data = new List<VW_REKOMENDASI_SAW>();
            try
            {
                data = vm.GetRekomendasiSAW();
                return new JsonResult() { Data = new { Data = data }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new { Data = data, ex.Message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
            }
        }

        [HttpGet]
        public JsonResult GetNilaiKriteria(int id)
        {
            List<VW_NILAI_KRITERIA> data = new List<VW_NILAI_KRITERIA>();
            try
            {
                data = vm.GetNilaiKriteria(id);
                return new JsonResult() { Data = new { Data = data }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new { Data = data, ex.Message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
            }
        }

        [HttpPost]
        public ActionResult DeleteAlternative(int id)
        {
            try
            {
                vm.DeleteAlternative(id);
                return Json(new { Remarks = true, Message = "Delete Success" });
            }
            catch (Exception e)
            {
                return Json(new { Remarks = false, Message = e.Message });
            }
        }

    }
}