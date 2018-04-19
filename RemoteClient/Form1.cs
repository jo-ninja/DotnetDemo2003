using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using RemoteServer;

namespace RemoteClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnClick;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private TcpChannel tcp = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnClick = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnClick
			// 
			this.btnClick.Location = new System.Drawing.Point(104, 128);
			this.btnClick.Name = "btnClick";
			this.btnClick.TabIndex = 0;
			this.btnClick.Text = "Click!";
			this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.btnClick);
			this.Name = "Form1";
			this.Text = "Form Client";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnClick_Click(object sender, System.EventArgs e)
		{
			try
			{
				Coba c = new Coba();
				btnClick.Text = c.Hei();
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Form f= new Form();
			f.Controls.Add(new TextBox());
			f.Show();
			try
			{
				tcp = new TcpChannel();
				ChannelServices.RegisterChannel(tcp);

				RemotingConfiguration.RegisterWellKnownClientType(typeof(Coba), "tcp://localhost:8080/Demo");

			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
	}
}
