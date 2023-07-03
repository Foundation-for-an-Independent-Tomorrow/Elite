using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite
{
    class Admins
    {
        private static Admins _selectedAdmin;
        public static Admins Selected_Admin { get => _selectedAdmin; set => _selectedAdmin = value; }

        private int _AdminId;
        public int AdminID { get => _AdminId; set => _AdminId = value; }

        private string _UserName;
        public string UserName { get => _UserName; set => _UserName = value; }

        private bool _isActive;
        public bool IsActive { get => _isActive; set => _isActive = value; }

        private DateTime _dateCreated;
        public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }
        public string CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
