using System;
using System.Web.Mvc;
using Calculator.Models;
using Calculator.Credit;
namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            ViewBag.Error = null;
            return View();
        }

        [HttpPost]
        public ViewResult Index(CalculateData data)
        {
            try
            {
                var payments = new CreditPayments(data);
                ViewBag.Error = null;
                return View("Result", payments.GetTableData());
            }catch(ArgumentException ex)
            {
                ViewBag.Error = "На сервере произошла ошибка :с";
                return View("Index");
            }
        }
    }
}
