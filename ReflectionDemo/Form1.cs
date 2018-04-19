using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Reflection;

namespace ReflectionDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnTes;
		private System.Windows.Forms.Button btnRight;
		private System.Windows.Forms.Button btnLeft;
		private System.Windows.Forms.Button btnAddHandler;

		private object o = null;
		private Assembly ass = null;
		private Type t = null;
		private System.Windows.Forms.Button btnTrigger;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
			this.btnTes = new System.Windows.Forms.Button();
			this.btnRight = new System.Windows.Forms.Button();
			this.btnLeft = new System.Windows.Forms.Button();
			this.btnAddHandler = new System.Windows.Forms.Button();
			this.btnTrigger = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnTes
			// 
			this.btnTes.Location = new System.Drawing.Point(56, 16);
			this.btnTes.Name = "btnTes";
			this.btnTes.Size = new System.Drawing.Size(80, 23);
			this.btnTes.TabIndex = 0;
			this.btnTes.Text = "&Load";
			this.btnTes.Click += new System.EventHandler(this.btnTes_Click);
			// 
			// btnRight
			// 
			this.btnRight.Location = new System.Drawing.Point(96, 80);
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(40, 23);
			this.btnRight.TabIndex = 1;
			this.btnRight.Text = ">>";
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.Location = new System.Drawing.Point(56, 80);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(40, 23);
			this.btnLeft.TabIndex = 2;
			this.btnLeft.Text = "<<";
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// btnAddHandler
			// 
			this.btnAddHandler.Location = new System.Drawing.Point(8, 48);
			this.btnAddHandler.Name = "btnAddHandler";
			this.btnAddHandler.Size = new System.Drawing.Size(80, 23);
			this.btnAddHandler.TabIndex = 3;
			this.btnAddHandler.Text = "&Add Handler";
			this.btnAddHandler.Click += new System.EventHandler(this.btnAddHandler_Click);
			// 
			// btnTrigger
			// 
			this.btnTrigger.Location = new System.Drawing.Point(104, 48);
			this.btnTrigger.Name = "btnTrigger";
			this.btnTrigger.TabIndex = 4;
			this.btnTrigger.Text = "&Trigger";
			this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(200, 117);
			this.Controls.Add(this.btnTrigger);
			this.Controls.Add(this.btnAddHandler);
			this.Controls.Add(this.btnLeft);
			this.Controls.Add(this.btnRight);
			this.Controls.Add(this.btnTes);
			this.Name = "Form1";
			this.Text = "Form1";
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

		private void btnTes_Click(object sender, System.EventArgs e)
		{
			Assembly z = Assembly.GetExecutingAssembly();
			string path = z.Location.Substring(0, z.Location.IndexOf(z.FullName.Substring(0, (z.FullName.IndexOf(",")))));
			//ass = Assembly.LoadFrom( @"D:\dotNetDemo\RemoteServer\bin\Debug\RemoteServer.exe");
			ass = Assembly.LoadFrom(path + @"RemoteServer\bin\Debug\RemoteServer.exe");
			foreach(Type tt in ass.GetTypes())
			{
				object temp = Activator.CreateInstance(tt);
				if(temp is Form)
				{
					t = tt;
					break;
				}
			}
			ConstructorInfo ci = t.GetConstructor(Type.EmptyTypes);
			
			o = Activator.CreateInstance(t);
			ci.Invoke(o, null);

			Form f = o as Form;
			if(f != null)
			{
				f.Show();
				f.Owner = this;
			}
		}

		private void c_Click(object sender, EventArgs e)
		{
			MessageBox.Show( ((Control)sender).Text );
		}

		private void btnLeft_Click(object sender, System.EventArgs e)
		{
			Form f = o as Form;
			if(f != null)
			{
				if(f.Controls.Count > 0)
				{
					Control c = f.Controls[0];
					if(c != null)
					{
						c.Left -= 10;
					}
				}
			}
		}

		private void btnAddHandler_Click(object sender, System.EventArgs e)
		{
			Form f = o as Form;
			if(f != null)
			{
				foreach(Control c in f.Controls)
				{
					c.Text = "Wow!";
					c.Click += new EventHandler(c_Click);
				}
			}
		}

		private void btnTrigger_Click(object sender, System.EventArgs e)
		{
			Form f = o as Form;
			MethodInfo mi = t.GetMethod("btnStart_Click");
			mi.Invoke(o, new object[] {sender, e});
		}

		private void btnRight_Click(object sender, System.EventArgs e)
		{
			Form f = o as Form;
			if(f != null)
			{
				if(f.Controls.Count > 0)
				{
					Control c = f.Controls[0];
					if(c != null)
					{
						c.Left += 10;
					}
				}
			}
		}
	}
}
