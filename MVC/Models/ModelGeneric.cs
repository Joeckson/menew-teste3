using System;
using System.Collections.Generic;
using System.Reflection;

namespace menew_teste3.MVC.Models
{
	public class ModelGeneric
	{
		protected Dictionary<string, PropertyInfo> __Properties { get; private set; }
		protected Type __CurrentType { get; set; }
		public ModelGeneric()
		{
			this.__Properties = new Dictionary<string, PropertyInfo>();
			__CurrentType = this.GetType();
			foreach (var _ in __CurrentType.GetProperties())
				if (!_.Name.Equals("Item"))
					__Properties.Add(_.Name, _);
		}
		public List<string> ListarPropriedades()
		{
			var temp = new List<string>();
			foreach (var item in __Properties.Keys)
				temp.Add(item);
			return temp;
		}
		public object this[string s]
		{
			get => this.__Properties[s].GetValue(this);
			set
			{
				if (__Properties[s].PropertyType.FullName.Equals("System.Char"))
					this.__Properties[s].SetValue(this, Convert.ToChar(value));
				else
					this.__Properties[s].SetValue(this, value is DBNull ? null : value);
			}
		}
	}
}
