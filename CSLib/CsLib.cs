using System;

namespace CSLibs
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Cs
	{
		private string _name;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		
		public Cs() : this("C#")
		{
		}
		public Cs(string name)
		{
			_name = name;
		}

		public int Add(int a, int b)
		{
			return a + b;
		}
	}
}
