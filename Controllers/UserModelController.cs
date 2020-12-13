using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Models;

namespace CRM.Controllers
{
    public class UserModelController : Controller
    {
        // GET: UserModel
        private OperationDataContext context;

        public UserModelController()

        {

            context = new OperationDataContext();

        }
        public ActionResult Index()
        {
            IList<UserModel> userList = new List<UserModel>();

            var query = from user in context.Users

                        select user;

            var users = query.ToList();

            foreach (var userData in users)

            {

                userList.Add(new UserModel()

                {

                    Id = userData.id,
                    Name = userData.name,
                    Surname = userData.surname,
                    DateOfBirth = userData.dateOfBirth,
                    Login = userData.login

                });

            }

            return View(userList);
        }

        //////////////////////////////////////////////
        public ActionResult Create()

        {

            UserModel model = new UserModel();

            return View(model);

        }



        [HttpPost]

        public ActionResult Create(UserModel model)

        {

            try

            {

                Users user = new Users()

                {

                    name = model.Name,

                    surname = model.Surname,

                    dateOfBirth = model.DateOfBirth,

                    login = model.Login

                    

                };

                context.Users.InsertOnSubmit(user);

                context.SubmitChanges();

                return RedirectToAction("Index");

            }

            catch

            {

                return View(model);

            }

        }
        ///////////////////////////////////////////////////////////////////////////////////


    }
}