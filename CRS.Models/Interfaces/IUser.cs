using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;

namespace CRS.Models.Interfaces
{
    public interface IUser:IPerson
    {
        int AccessCode { get; set; }
        string Division { get; set; }
        string Email { get; set; }
        string ISB { get; set; }
        string JamesBond { get; set; }
        string PasswordReset { get; set; }
        int UserStatus { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ExpirationDate { get; set; }
        int? FailedLogins { get; set; }
        DateTime? FirstFailureDate { get; set; }
        DateTime? LastFailureDate { get; set; }
        DateTime LastLoginDate { get; set; }
        DateTime PasswordExpirationDate { get; set; }
        IEnumerationDetail RoleDetail { get; set; }
    }
}
