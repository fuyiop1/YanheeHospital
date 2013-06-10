using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YanheeHospital.Models;
using YanheeHospital.ViewModels;
using YanheeHospital.Helpers;

namespace YanheeHospital.Controllers
{
    public class UserController : Controller
    {
        private YanheeHospitalDbContext DbContext = new YanheeHospitalDbContext();

        public ActionResult Index()
        {
            var viewModel = new UserIndexViewModel();
            viewModel.CurrentUser = new User();
            viewModel.Users = DbContext.Users.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UserIndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel != null && viewModel.CurrentUser != null)
                {
                    DbContext.Users.Add(viewModel.CurrentUser);
                    DbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.Users = DbContext.Users.ToList();
                return View("Index", viewModel);
            }
        }

        public ActionResult SendEmail(int id)
        {
            var user = DbContext.Users.Find(id);
            if (user != null && EmailHelper.SendEmail(user))
            {
                user.IsInvitationEmailSent = true;
                user.InvitationEmailSentTime = DateTime.Now;
                DbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult CollectAnswer(int id, string password)
        {
            var viewModel = new UserCollectAnswerViewModel();
            viewModel.GenderDictionary = EnumHelper.ConvertEnumToDictionary(typeof(Gender));
            viewModel.DinnerDictionary = EnumHelper.ConvertEnumToDictionary(typeof(Dinner));
            var user = DbContext.Users.Find(id);
            if (user != null && user.Password == password)
            {
                viewModel.IsUserAuthenticated = true;
                viewModel.User = user;
                viewModel.UserAnswer = new UserAnswer()
                {
                    UserId = id,
                    ChineseName = user.Name
                };
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CollectAnswer(UserCollectAnswerViewModel viewModel)
        {

            return View();
        }

    }
}
