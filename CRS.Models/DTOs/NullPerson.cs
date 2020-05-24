using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.Models.Interfaces;

namespace CRS.Models
{
    public class NullPerson:IPerson
    {

        public int Id
        {
            get{return 0;}
            set { ;}
        }

        public string FirstName
        {
            get { return string.Empty; }
            set { ;}
        }

        public string MiddleName
        {
            get { return string.Empty; }
            set { ;}
        }

        public string LastName
        {
            get { return string.Empty; }
            set { ;}
        }
    }
}
