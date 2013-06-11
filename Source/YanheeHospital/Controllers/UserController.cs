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
                user.InvitationEmailSentTime = DateTime.Now.ToDefaultTargetGmtTime();
                DbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult CollectAnswer(int id, string password)
        {
            var viewModel = new UserCollectAnswerViewModel();
            
            var user = DbContext.Users.Find(id);
            if (user != null && user.Password == password)
            {
                viewModel.IsUserAuthenticated = true;
                viewModel.User = user;
                viewModel.UserAnswer = new UserAnswer()
                {
                    UserId = id,
                    ChineseName = user.Name,
                    IsNeedPost = true,
                    EatMostDinner = (int) Dinner.Lunch
                };
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CollectAnswer(UserCollectAnswerViewModel viewModel)
        {
            if (ModelState.IsValid & ValidateBirthDate(viewModel) & ValidateUserAnswer(viewModel.UserAnswer))
            {
                var id = viewModel.UserAnswer.UserId;
                var password = viewModel.User.Password;
                DbContext.UserAnswers.Add(viewModel.UserAnswer);
                var user = DbContext.Users.Find(id);
                if (user != null)
                {
                    user.IsAnswered = true;
                    user.AnswerTime = DateTime.Now.ToDefaultTargetGmtTime();
                }
                DbContext.SaveChanges();
                return RedirectToAction("CollectAnswer", new { id = id, password = password });
            }
            else
            {
                return View(viewModel);
            }
        }

        public ActionResult ViewAnswer(int id)
        {
            var viewModel = new UserCollectAnswerViewModel();
            viewModel.IsAdminViewAnswer = true;
            var user = DbContext.Users.Find(id);
            var userAnswer = DbContext.UserAnswers.Find(id);
            if (user != null && userAnswer != null)
            {
                viewModel.IsUserAuthenticated = true;
                viewModel.User = user;
                viewModel.UserAnswer = userAnswer;

                if (userAnswer.Birthdate.HasValue)
                {
                    viewModel.UserBirthdateYear = userAnswer.Birthdate.Value.Year;
                    viewModel.UserBirthdateMonth = userAnswer.Birthdate.Value.Month;
                    viewModel.UserBirthdateDay = userAnswer.Birthdate.Value.Day;
                }

            }
            return View("CollectAnswer", viewModel);
        }

        private bool ValidateBirthDate(UserCollectAnswerViewModel viewModel)
        {
            var result = true;
            try
            {
                viewModel.UserAnswer.Birthdate = new DateTime(viewModel.UserBirthdateYear, viewModel.UserBirthdateMonth, viewModel.UserBirthdateDay);
            }
            catch (Exception)
            {
                ModelState.AddModelError("UserAnswer.Birthdate", "该日期不存在");
                result = false;
            }
            return result;
        }

        private bool ValidateUserAnswer(UserAnswer userAnswer)
        {
            var result = true;

            if (userAnswer != null)
            {

                result = ValidateUserAnswerAddress(userAnswer, result);

                if (userAnswer.IsAllergic)
                {
                    if (string.IsNullOrWhiteSpace(userAnswer.AllergyDetail))
                    {
                        ModelState.AddModelError("UserAnswer.AllergyDetail", "请输入过敏药物/食物");
                        result = false;
                    }
                }
                else
                {
                    userAnswer.AllergyDetail = null;
                }

                if (userAnswer.HaveSeriousDesease)
                {
                    if (string.IsNullOrWhiteSpace(userAnswer.SeriousDeseaseDetail))
                    {
                        ModelState.AddModelError("UserAnswer.SeriousDeseaseDetail", "请输入重大疾病描述");
                        result = false;
                    }
                }
                else
                {
                    userAnswer.SeriousDeseaseDetail = null;
                }

                result = ValidateUserAnswerPreviousDietMedicine(userAnswer, result);

                if (userAnswer.IsHavingOtherMedicine)
                {
                    if (string.IsNullOrWhiteSpace(userAnswer.OtherMedicineDetail))
                    {
                        ModelState.AddModelError("UserAnswer.OtherMedicineDetail", "请输入药物名称与描述");
                        result = false;
                    }
                }
                else
                {
                    userAnswer.OtherMedicineDetail = null;
                }

            }

            return result;
        }

        private bool ValidateUserAnswerAddress(UserAnswer userAnswer, bool result)
        {
            if (userAnswer.Address != null)
            {
                if (userAnswer.IsNeedPost)
                {
                    if (string.IsNullOrWhiteSpace(userAnswer.Address.Street))
                    {
                        ModelState.AddModelError("UserAnswer.Address.Street", "请输入街道地址");
                        result = false;
                    }
                    if (string.IsNullOrWhiteSpace(userAnswer.Address.PostCode))
                    {
                        ModelState.AddModelError("UserAnswer.Address.PostCode", "请输入邮编");
                        result = false;
                    }
                    if (string.IsNullOrWhiteSpace(userAnswer.Address.City))
                    {
                        ModelState.AddModelError("UserAnswer.Address.City", "请输入城市");
                        result = false;
                    }
                    if (string.IsNullOrWhiteSpace(userAnswer.Address.Country))
                    {
                        ModelState.AddModelError("UserAnswer.Address.Country", "请输入国家");
                        result = false;
                    }
                }
                else
                {
                    userAnswer.Address.Street = null;
                    userAnswer.Address.PostCode = null;
                    userAnswer.Address.City = null;
                    userAnswer.Address.Country = null;
                }

            }
            return result;
        }

        private bool ValidateUserAnswerPreviousDietMedicine(UserAnswer userAnswer, bool result)
        {
            if (userAnswer.HavePreviousDietMedicine)
            {
                if (string.IsNullOrWhiteSpace(userAnswer.PreviousDietMedicineDetail))
                {
                    ModelState.AddModelError("UserAnswer.PreviousDietMedicineDetail", "请输入减肥药名称");
                    result = false;
                }
                if (string.IsNullOrWhiteSpace(userAnswer.PreviousDietMedicineDuringTime))
                {
                    ModelState.AddModelError("UserAnswer.PreviousDietMedicineDuringTime", "请输入服用时间");
                    result = false;
                }
                if (string.IsNullOrWhiteSpace(userAnswer.PreviousDietMedicineStopTime))
                {
                    ModelState.AddModelError("UserAnswer.PreviousDietMedicineStopTime", "请输入已停药多久");
                    result = false;
                }
                if (userAnswer.IsPreviousDietMedicineHaveSideEffect)
                {
                    if (string.IsNullOrWhiteSpace(userAnswer.PreviousDietMedicineSideEffectDetail))
                    {
                        ModelState.AddModelError("UserAnswer.PreviousDietMedicineSideEffectDetail", "请输入副作用描述");
                        result = false;
                    }
                }
                else
                {
                    userAnswer.PreviousDietMedicineSideEffectDetail = null;
                }
            }
            else
            {
                userAnswer.PreviousDietMedicineDetail = null;
                userAnswer.PreviousDietMedicineDuringTime = null;
                userAnswer.PreviousDietMedicineStopTime = null;
                userAnswer.IsPreviousDietMedicineHaveSideEffect = false;
                userAnswer.PreviousDietMedicineSideEffectDetail = null;
            }
            return result;
        }

    }
}
