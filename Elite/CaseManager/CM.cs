using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite
{
    class CM
    {
        private static CM _selectedCaseManager;
        public static CM SelectedCaseManager { get => _selectedCaseManager; set => _selectedCaseManager = value; }

        private int _cmid;
        public int CMID { get => _cmid; set => _cmid = value; }

        private string _firstName;
        public string FirstName { get => _firstName; set => _firstName = value; }

        private string _lastName;
        public string LastName { get => _lastName; set => _lastName = value; }

        private string _login;
        public string Login { get => _login; set => _login = value; }

        private bool _active;
        public bool Active { get => _active; set => _active = value; }
    }
}
