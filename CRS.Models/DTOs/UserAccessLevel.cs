using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;
using CRS.Models.Interfaces;

namespace CRS.Models.DTOs
{
    public class UserAccessLevel : IUserAccessInfo
    {
        public int Id
        {
            get;
            set;
        }

        public int AccessCode
        {
            get;
            set;
        }

        public string JamesBond
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }

        public IEnumerationDetail UserDetails
        {
            get;
            set;
        }

        public UserAccessLevel()
        {
            UserDetails = new EnumerationDetails();
        }

        public UserAccessLevel(EnumerationDetails info)
        {
            UserDetails = info;
        }


    }
}
