using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite
{
	public class CaseManagerBuilder
	{
		private int _cMID;
		private string _firstName;
		private string _lastName;
		private string _login;
		private bool _active;

		public CaseManagerBuilder() { }

		public CaseManagerBuilder WithCMID(int cMID)
		{
			_cMID = cMID;
			return this;
		}

		public CaseManagerBuilder WithFirstName(string firstName)
		{
			_firstName = firstName;
			return this;
		}

		public CaseManagerBuilder WithLastName(string lastName)
		{
			_lastName = lastName;
			return this;
		}

		public CaseManagerBuilder WithLogin(string login)
		{
			_login = login;
			return this;
		}

		public CaseManagerBuilder WithActive(bool active)
		{
			_active = active;
			return this;
		}

		public CaseManager Build()
		{
			return new CaseManager
			{
				CMID = _cMID,
				FirstName = _firstName,
				LastName = _lastName,
				Login = _login,
				Active = _active
			};
		}
	}
}
