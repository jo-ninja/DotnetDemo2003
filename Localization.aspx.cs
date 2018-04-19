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

using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Threading;

namespace dotNetDemo
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblGreetings;
		protected System.Web.UI.WebControls.Button btnClick;
		protected System.Web.UI.WebControls.LinkButton lnkJpn;
		protected System.Web.UI.WebControls.LinkButton lnkEnglish;
		
		private ResourceManager res = null;

		public string ButtonText
		{
			get
			{
				return res.GetString("btn.Text");
			}
		}

		public string GreetingsText
		{
			get
			{
				return res.GetObject("greetings").ToString();
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			btnClick.Style["color"] = "blue";
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
			this.LoadResources();
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
			this.lnkJpn.Click += new System.EventHandler(this.lnkJpn_Click);
			this.lnkEnglish.Click += new System.EventHandler(this.lnkEnglish_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoadResources()
		{
			res = new ResourceManager("dotNetDemo.dotNetDemo",Assembly.GetExecutingAssembly());
			DataBind();
		}

		private void lnkEnglish_Click(object sender, System.EventArgs e)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
			this.LoadResources();
		}

		private void lnkJpn_Click(object sender, System.EventArgs e)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ja-JP");
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
			this.LoadResources();
		}
	}
}
