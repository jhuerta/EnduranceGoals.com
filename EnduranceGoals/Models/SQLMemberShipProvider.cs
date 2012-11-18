using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EnduranceGoals.Infrastructure;
using EnduranceGoals.Models.Repositories;

namespace EnduranceGoals.Models
{
    public class SQLMemberShipProvider : MembershipProvider
    {
        private Users users;

        public SQLMemberShipProvider()
        {
            minRequiredPasswordLength = 10;
            users = new Users(SessionProvider.CurrentSession);
        }

        private int minRequiredPasswordLength { get; set; }



        public EnduranceMembershipUser CreateUser(string username,
            string password,
            string email,
            string passwordQuestion,
            string passwordAnswer,
            bool isApproved,
            object providerUserKey,
            string name, string lastname,out MembershipCreateStatus status)
        {
            bool userExist = users.GetByUserName(username) != null;
            bool emailExit = GetUserNameByEmail(email) != null;

            if (emailExit)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            if (userExist)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }

            users.Add(new User()
            {
                Name = name,
                Lastname = lastname,
                Username = username,
                Password = HashSHA1(password),
                Email = email,
                CreatedOn = DateTime.Now
            });

            status = MembershipCreateStatus.Success;

            return (EnduranceMembershipUser) GetUser(username);
        }
        public override MembershipUser CreateUser(string username,
            string password,
            string email,
            string passwordQuestion,
            string passwordAnswer,
            bool isApproved,
            object providerUserKey,
            out MembershipCreateStatus status)
        {
            return this.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved,
                                   providerUserKey,"","",out status);

        }

        private string HashSHA1(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
        }


        public MembershipUser GetUser(string username)
        {
            


            var createdUser = users.GetByUserName(username);



            if (createdUser != null)
                {

                    string _username = createdUser.Username;
                    int _providerUserKey = createdUser.Id;
                    string _email = createdUser.Email;
                    string _passwordQuestion = "";
                    string _comment = null;
                    bool _isApproved = true;
                    bool _isLockedOut = false;
                    string name = createdUser.Name;
                    string lastname = createdUser.Lastname;
                    DateTime _creationDate = createdUser.CreatedOn;
                    DateTime _lastLoginDate = DateTime.Now;
                    DateTime _lastActivityDate = DateTime.Now;
                    DateTime _lastPasswordChangedDate = DateTime.Now;
                    DateTime _lastLockedOutDate = DateTime.Now;

                    var user = new EnduranceMembershipUser("SQLMemberShipProvider",
                                                              _username,
                                                              _providerUserKey,
                                                              _email,
                                                              _passwordQuestion,
                                                              _comment,
                                                              _isApproved,
                                                              _isLockedOut,
                                                              _creationDate,
                                                              _lastLoginDate,
                                                              _lastActivityDate,
                                                              _lastPasswordChangedDate,
                                                              _lastLockedOutDate,
                                                              name,
                                                              lastname);

                    return user;
                }
                else
                {
                    return null;
                }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            //var currentUser = users.GetById((int)user.ProviderUserKey);

            //currentUser.Email = user.Email; 
            //currentUser.Username = user.UserName;

            //users.Update(currentUser);

            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            return users.GetByUserName(username).Password == HashSHA1(password);
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            var userByEmail = users.GetByEmail(email);

            return userByEmail == null ? null: userByEmail.Username ;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { return minRequiredPasswordLength; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
    }
}
