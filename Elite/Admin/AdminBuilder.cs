using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Elite
{
	/// <summary>
	/// Builder for the class <see cref="Admin">Admin</see>
	/// </summary>
	public class AdminBuilder
	{
		private int adminID;
		private string userName;
		private bool isActive;
		private DateTime dateCreated;
		private string createdBy;
		private DateTime dateModified;
		private string modifiedBy;

		/// <summary>
		/// Create a new instance for the <see cref="AdminBuilder">AdminBuilder</see>
		/// </summary>
		public AdminBuilder()
		{
			Reset();
		}

		/// <summary>
		/// Reset all properties' to the default value
		/// </summary>
		/// <returns>Returns the <see cref="AdminBuilder">AdminBuilder</see> with the properties reseted</returns>
		public AdminBuilder Reset()
		{
			adminID = default;
			userName = default;
			isActive = default;
			dateCreated = default;
			createdBy = default;
			dateModified = default;
			modifiedBy = default;

			return this;
		}

		/// <summary>
		/// Build a class of type <see cref="Admin">Admin</see> with all the defined values
		/// </summary>
		/// <returns>Returns a <see cref="Admin">Admin</see> class</returns>
		internal Admin Build()
		{
			return new Admin
			{
				AdminID = adminID,
				UserName = userName,
				IsActive = isActive,
				DateCreated = dateCreated,
				CreatedBy = createdBy,
				DateModified = dateModified,
				ModifiedBy = modifiedBy,
			};
		}
	}
}