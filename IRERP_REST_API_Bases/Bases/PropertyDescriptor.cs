using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Bases
{
    public class PropertyDescriptor<T>: PropertyDescriptor
    {

        public PropertyDescriptor(string propertyName)
            : base(propertyName, null)
		{
			this.propertyName = propertyName;
		}

		private string propertyName;

		public override bool CanResetValue(object component)
		{
			return false;
		}

		public override Type ComponentType
		{
			get
			{
				return typeof(T);
			}
		}

		public override object GetValue(object component)
		{
			return component.GetType().GetProperty(propertyName).GetValue(component, null);
		}

		public override void SetValue(object component, object value)
		{
			component.GetType().GetProperty(propertyName).SetValue(component, value, null);
		}

		public override bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public override Type PropertyType
		{
			get
			{
				return typeof(T).GetProperty(propertyName).PropertyType;
			}
		}

		public override bool ShouldSerializeValue(object component)
		{
			return false;
		}

		public override void ResetValue(object component)
		{

		}
    }
}
