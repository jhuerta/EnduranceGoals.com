using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using EnduranceGoals.Controllers;
using EnduranceGoals.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace EnduranceGoals.Tests
{
    [TestFixture]
    public class AccountControllerTest
    {
        [Test]
        public void ChangePasswordPostReturnsRedirectOnSuccess()
        {
            AccountController controller = GetAccountController(new MockMembershipService());
            var model = new ChangePasswordModel
                            {
                                OldPassword = "goodOldPassword",
                                NewPassword = "goodNewPassword",
                                ConfirmPassword = "goodNewPassword"
                            };

            ActionResult result = controller.ChangePassword(model);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            var redirectResult = (RedirectToRouteResult) result;
            Assert.AreEqual("ChangePasswordSuccess", redirectResult.RouteValues["action"]);
        }

        [Test]
        public void ChangePasswordPostReturnsViewIfModelStateIsInvalid()
        {
            AccountController controller = GetAccountController(new MockMembershipService());
            var model = new ChangePasswordModel
                            {
                                OldPassword = "goodOldPassword",
                                NewPassword = "goodNewPassword",
                                ConfirmPassword = "goodNewPassword"
                            };
            controller.ModelState.AddModelError("", "Dummy error message.");

            ActionResult result = controller.ChangePassword(model);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult) result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        [Test]
        public void ChangePasswordPostReturnsViewWithCorrectMessageIfChangePasswordFails()
        {
            AccountController controller = GetAccountController(new MockMembershipService());
            var model = new ChangePasswordModel
                            {
                                OldPassword = "goodOldPassword",
                                NewPassword = "badNewPassword",
                                ConfirmPassword = "badNewPassword"
                            };

            ActionResult result = controller.ChangePassword(model);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult) result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual("The current password is incorrect or the new password is invalid.",
                            controller.ModelState[""].Errors[0].ErrorMessage);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        [Test]
        public void ChangePasswordShouldReturnCorrectView()
        {
            AccountController controller = GetAccountController(new MockMembershipService());

            ActionResult result = controller.ChangePassword();

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(10, ((ViewResult) result).ViewData["PasswordLength"]);
        }

        [Test]
        public void ChangePasswordSuccessReturnsView()
        {
            AccountController controller = GetAccountController(new MockMembershipService());

            ActionResult result = controller.ChangePasswordSuccess();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void LogOffLogsOutAndRedirects()
        {
            
            AccountController controller = GetAccountController(new MockMembershipService());

            ActionResult result = controller.LogOff();

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            var redirectResult = (RedirectToRouteResult) result;
            Assert.AreEqual("Goals", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
            Assert.IsTrue(((MockFormsAuthenticationService) controller.FormsService).SignOutWasCalled);
        }

        [Test]
        public void LogOnGetReturnsView()
        {
            AccountController controller = GetAccountController(new MockMembershipService());

            ActionResult result = controller.LogOn();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void LogOnPostReturnsRedirectOnSuccessWithReturnUrl()
        {
            var mock = MockRepository.GenerateMock<IMembershipService>();
            
            mock.Stub(s => s.CreateUser(
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything))
                .IgnoreArguments()
                .Return(MembershipCreateStatus.Success);

            mock.Stub(s => s.MinPasswordLength).Return(10);

            AccountController controller = GetAccountController(new MockMembershipService());
            var model = new LogOnModel
                            {
                                UserName = "someUser",
                                Password = "goodPassword",
                                RememberMe = false
                            };

            ActionResult result = controller.LogOn(model, "/someUrl");

            Assert.IsInstanceOf<RedirectResult>(result);
            var redirectResult = (RedirectResult) result;
            Assert.AreEqual("/someUrl", redirectResult.Url);
            Assert.IsTrue(((MockFormsAuthenticationService) controller.FormsService).SignInWasCalled);
        }

        [Test]
        public void LogOnPostReturnsRedirectOnSuccessWithoutReturnUrl()
        {
            AccountController controller = GetAccountController(new MockMembershipService());
            var model = new LogOnModel
                            {
                                UserName = "someUser",
                                Password = "goodPassword",
                                RememberMe = false
                            };

            ActionResult result = controller.LogOn(model, null);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            var redirectResult = (RedirectToRouteResult) result;
            Assert.AreEqual("Goals", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
            Assert.IsTrue(((MockFormsAuthenticationService) controller.FormsService).SignInWasCalled);
        }

        [Test]
        public void LogOnPostReturnsViewIfModelStateIsInvalid()
        {
            AccountController controller = GetAccountController(new MockMembershipService());
            var model = new LogOnModel
                            {
                                UserName = "someUser",
                                Password = "goodPassword",
                                RememberMe = false
                            };
            controller.ModelState.AddModelError("", "Dummy error message.");

            ActionResult result = controller.LogOn(model, null);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult) result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
        }

        [Test]
        public void LogOnPostReturnsViewIfValidateUserFails()
        {
            AccountController controller = GetAccountController(new MockMembershipService());
            var model = new LogOnModel
                            {
                                UserName = "someUser",
                                Password = "badPassword",
                                RememberMe = false
                            };

            ActionResult result = controller.LogOn(model, null);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult) result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual("The user name or password provided is incorrect.",
                            controller.ModelState[""].Errors[0].ErrorMessage);
        }

        [Test]
        public void RegisterGetReturnsView()
        {
            AccountController controller = GetAccountController(new MockMembershipService());

            ActionResult result = controller.Register();

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(10, ((ViewResult) result).ViewData["PasswordLength"]);
        }

        [Test]
        public void RegisterPostReturnsRedirectOnSuccess()
        {
            var mock = MockRepository.GenerateStub<IMembershipService>(); ;
            mock.Stub(s => s.CreateUser(
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything))
                .IgnoreArguments()
                .Return(MembershipCreateStatus.Success);

            mock.Stub(s => s.MinPasswordLength).Return(10);

            AccountController controller = GetAccountController(mock);
            var model = new RegisterModel
                            {
                                UserName = "someUser",
                                Email = "goodEmail",
                                Password = "goodPassword",
                                ConfirmPassword = "goodPassword"
                            };

            ActionResult result = controller.Register(model);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            var redirectResult = (RedirectToRouteResult) result;
            Assert.AreEqual("Goals", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
        }

        [Test]
        public void RegisterPostReturnsViewIfModelStateIsInvalid()
        {
            AccountController controller = GetAccountController(new MockMembershipService());
            var model = new RegisterModel
                            {
                                UserName = "someUser",
                                Email = "goodEmail",
                                Password = "goodPassword",
                                ConfirmPassword = "goodPassword"
                            };
            controller.ModelState.AddModelError("", "Dummy error message.");

            ActionResult result = controller.Register(model);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult) result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        [Test]
        public void RegisterPostReturnsViewWithCorrectMessageIfRegistrationFails()
        {
            string uname =  "duplicateUser";
            string email = "goodEmail";
            string password =  "goodPassword";

            var mock = MockRepository.GenerateStub<IMembershipService>();;
            mock.Stub(s => s.CreateUser(
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything))
                .IgnoreArguments()
                .Return(MembershipCreateStatus.DuplicateUserName);

            mock.Stub(s => s.MinPasswordLength).Return(10);

            AccountController controller = GetAccountController(mock);

            var model = new RegisterModel
                            {
                                UserName =uname,
                                Email = email,
                                Password = password,
                                ConfirmPassword = password
                            };

            ActionResult result = controller.Register(model);

            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult) result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual("Username already exists. Please enter a different user name.",
                            controller.ModelState[""].Errors[0].ErrorMessage);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        private static AccountController GetAccountController(IMembershipService mockMembershipService)
        {
            var controller = new AccountController
            {
                FormsService = new MockFormsAuthenticationService(),
                MembershipService = mockMembershipService
            };
            controller.ControllerContext = new ControllerContext
            {
                Controller = controller,
                RequestContext =
                    new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }

        private class MockFormsAuthenticationService : IFormsAuthenticationService
        {
            public bool SignInWasCalled;
            public bool SignOutWasCalled;

            public void SignIn(string userName, bool createPersistentCookie)
            {
                Assert.AreEqual("someUser", userName);
                Assert.IsFalse(createPersistentCookie);

                SignInWasCalled = true;
            }

            public void SignOut()
            {
                SignOutWasCalled = true;
            }
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get { return _user; }
                set { base.User = value; }
            }
        }

        private class MockMembershipService : IMembershipService
        {
            public int MinPasswordLength
            {
                get { return 10; }
            }

            public bool ValidateUser(string userName, string password)
            {
                return (userName == "someUser" && password == "goodPassword");
            }

            public MembershipCreateStatus CreateUser(string userName, string password, string email, string name, string lastname)
            {
                return MembershipCreateStatus.InvalidAnswer;
            }

            public MembershipCreateStatus CreateUser(string userName, string password, string email)
            {
                if (userName == "duplicateUser")
                {
                    return MembershipCreateStatus.DuplicateUserName;
                }

                // verify that values are what we expected
                Assert.AreEqual("goodPassword", password);
                Assert.AreEqual("goodEmail", email);

                return MembershipCreateStatus.Success;
            }

            public bool ChangePassword(string userName, string oldPassword, string newPassword)
            {
                return (userName == "someUser" && oldPassword == "goodOldPassword" && newPassword == "goodNewPassword");
            }
        }
    }
}
