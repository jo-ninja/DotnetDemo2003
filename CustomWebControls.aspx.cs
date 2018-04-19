using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace dotNetDemo
{
	/// <summary>
	/// Summary description for CustomWebControls.
	/// </summary>
	public class CustomWebControls : System.Web.UI.Page
	{
		protected CalcCtl.SimpleCalc SimpleCalc1;
		protected CalcCtl.SimpleCalc SimpleCalc3;
		protected CalcCtl.SimpleCalc SimpleCalc4;
		protected CalcCtl.SimpleCalc SimpleCalc5;
		protected CalcCtl.SimpleCalc SimpleCalc2;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.SimpleCalc5.Calculate += new CalcCtl.SimpleCalc.OnCalculate(this.SimpleCalc5_Calculate);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private double SimpleCalc5_Calculate(double value1, double value2)
		{
			return value1 + value2 + 2;
		}
	}
}
