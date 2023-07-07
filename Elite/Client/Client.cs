using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite
{
    class Client
    {
        private static Client _selectedClient;
        public static Client SelectedClient { get => _selectedClient; set => _selectedClient = value; }

        private int _clientID;
        public int ClientID { get => _clientID; set => _clientID = value; }

        private string _firstName;
        public string FirstName { get => _firstName; set => _firstName = value; }

        private string _middleInitial;
        public string MiddleInitial { get => _middleInitial; set => _middleInitial = value; }

        private string _lastName;
        public string LastName { get => _lastName; set => _lastName = value; }

        private string _social;
        public string Social { get => _social; set => _social = value; }

        private DateTime _appDate;
        public DateTime AppDate { get => _appDate; set => _appDate = value; }

        private int _cmID;
        public int CMID { get => _cmID;  set => _cmID = value; }

        private bool _incomeUpdated;
        public bool IncomeUpdated { get => _incomeUpdated; set => _incomeUpdated = value; }

        private bool _publicAssistUpdated;
        public bool PublicAssistUpdated { get => _publicAssistUpdated; set => _publicAssistUpdated = value; }

        private bool _goodToUpdate;
        public bool GoodToUpdate { get => _goodToUpdate; set => _goodToUpdate = value; }

        private bool _pacMAN;
        public bool PacMan { get => _pacMAN; set => _pacMAN = value; }

        public Client(int clientID, string fName, string MI, string lName, string social, DateTime appDate, int cmID)
        {
            _clientID = clientID;
            _firstName = fName;
            _middleInitial = MI;
            _lastName = lName;
            _social = social;
            _appDate = appDate;
            _cmID = cmID;
        }
    }
}
