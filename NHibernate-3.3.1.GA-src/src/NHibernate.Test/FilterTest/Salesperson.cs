using System;
using Iesi.Collections;

namespace NHibernate.Test.FilterTest
{
	public class Salesperson
	{
		private long id;
		private String name;
		private String region;
		private DateTime hireDate;
		private Department department;
		private ISet orders = new HashedSet();

		public virtual long Id
		{
			get { return id; }
			set { id = value; }
		}

		public virtual string Name
		{
			get { return name; }
			set { name = value; }
		}

		public virtual string Region
		{
			get { return region; }
			set { region = value; }
		}

		public virtual DateTime HireDate
		{
			get { return hireDate; }
			set { hireDate = value; }
		}

		public virtual Department Department
		{
			get { return department; }
			set { department = value; }
		}

		public virtual ISet Orders
		{
			get { return orders; }
			set { orders = value; }
		}
	}
}