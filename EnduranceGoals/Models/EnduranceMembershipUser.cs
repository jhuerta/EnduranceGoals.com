using System;
using System.Web.Security;

namespace EnduranceGoals.Models
{
    public class EnduranceMembershipUser : MembershipUser
    {
        private string Name { get; set; }
        private string LastName { get; set; }


        public EnduranceMembershipUser(string providername,
                                       string username,
                                       object providerUserKey,
                                       string email,
                                       string passwordQuestion,
                                       string comment,
                                       bool isApproved,
                                       bool isLockedOut,
                                       DateTime creationDate,
                                       DateTime lastLoginDate,
                                       DateTime lastActivityDate,
                                       DateTime lastPasswordChangedDate,
                                       DateTime lastLockedOutDate,
                                       string name,
                                       string lastname) :
                                           base(providername,
                                                username,
                                                providerUserKey,
                                                email,
                                                passwordQuestion,
                                                comment,
                                                isApproved,
                                                isLockedOut,
                                                creationDate,
                                                lastLoginDate,
                                                lastActivityDate,
                                                lastPasswordChangedDate,
                                                lastLockedOutDate)
        {
            Name = name;
            LastName = lastname;
        }
    }
}