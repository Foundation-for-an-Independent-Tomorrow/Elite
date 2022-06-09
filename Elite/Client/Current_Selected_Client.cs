using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.Client
{
    class Current_Selected_Client
    {
        private static Client _selectedClient;

        public static Client SelectedClient { get => _selectedClient; set => _selectedClient = value; }
    }
}
