using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    class Username_Date
    {
        private string _Username;
        public string Username
        {
            get { return _Username = Environment.UserName; }

        }

        private string _Create_Date;
        public string Create_Date
        {

            get { return _Create_Date = DateTime.Now.ToString("M/d/yyy"); }

        }

    }
}
