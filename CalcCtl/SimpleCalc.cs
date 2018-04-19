using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace CalcCtl
{
	/// <summary>
	/// Summary description for SimpleCalc.
	/// </summary>
	[DefaultProperty("Text1"),
	ToolboxData("<{0}:SimpleCalc runat=\"server\" HeaderText=\"Addition\" Text1=\"1\" Text2=\"2\"></{0}:SimpleCalc>")]
	public class SimpleCalc : System.Web.UI.WebControls.WebControl, INamingContainer
	{
		public delegate double OnCalculate(double value1, double value2);
		private SimpleCalc.CalculationOperationEnum operation;

		public enum CalculationOperationEnum
		{
			Addition,
			Subtraction,
			Multiplication,
			Division,
			Custom
		}

		#region Public Events
		
		[Category("Operation"),
		Description("Custom calculation operation")]
		public event SimpleCalc.OnCalculate Calculate;
		
		#endregion

		#region Public Properties

		[Bindable(false),
		Category("Operation"),
		Description("Calculation Operation"),
		DefaultValue(SimpleCalc.CalculationOperationEnum.Addition)]
		public SimpleCalc.CalculationOperationEnum CalculationOperation
		{
			get
			{
				EnsureChildControls();
				return operation;
			}

			set
			{
				EnsureChildControls();
				operation = (SimpleCalc.CalculationOperationEnum)value;
				if(operation != SimpleCalc.CalculationOperationEnum.Custom)
				{
					HeaderText = operation.ToString();
				}
			}
		}

		[Bindable(false),
		Category("Appearance"),
		Description("Border Style")]
		public BorderStyle CustomBorderStyle
		{
			get
			{
				EnsureChildControls();
				return ((Panel)Controls[0]).BorderStyle;
			}

			set
			{
				EnsureChildControls();
				((Panel)Controls[0]).BorderStyle = (BorderStyle)value;
			}
		}

		[Bindable(true),
		Category("Appearance"),
		Description("Header")]
		public string HeaderText
		{
			get
			{
				EnsureChildControls();
				return ((Label)Controls[0].Controls[0]).Text;
			}

			set
			{
				EnsureChildControls();
				((Label)Controls[0].Controls[0]).Text = value;
			}
		}

		[Bindable(true),
		Category("Appearance"),
		Description("First textbox"),
		DefaultValue("1")]
		public string Text1
		{
			get
			{
				EnsureChildControls();
				return ((TextBox)Controls[0].Controls[2]).Text;
			}

			set
			{
				EnsureChildControls();
				((TextBox)Controls[0].Controls[2]).Text = value;
			}
		}

		[Bindable(true),
		Category("Appearance"),
		Description("Second textbox"),
		DefaultValue("2")]
		public string Text2
		{
			get
			{
				EnsureChildControls();
				return ((TextBox)Controls[0].Controls[4]).Text;
			}

			set
			{
				EnsureChildControls();
				((TextBox)Controls[0].Controls[4]).Text = value;
			}
		}

		[Bindable(false),
		Category("Appearance"),
		Description("Result")]
		public string Result
		{
			get
			{
				EnsureChildControls();
				return ((TextBox)Controls[0].Controls[7]).Text;
			}
		}

		#endregion

		/// <summary>
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
//		protected override void Render(HtmlTextWriter output)
//		{
//			base.Render(output);
//		}
		
		protected override void CreateChildControls()
		{
			//base.CreateChildControls ();

			Panel panel = new Panel();
			panel.BorderStyle = BorderStyle.Dotted;
			panel.BorderColor = System.Drawing.Color.Red;
			Controls.Add(panel);

			Label lblHeader = new Label();
			panel.Controls.Add(lblHeader);

			panel.Controls.Add(new LiteralControl("<br>"));

			TextBox txt1 = new TextBox();
			txt1.Width = 50;
			panel.Controls.Add(txt1);

			panel.Controls.Add(new LiteralControl("<br>"));

			TextBox txt2 = new TextBox();
			txt2.Width = 50;
			panel.Controls.Add(txt2);

			panel.Controls.Add(new LiteralControl("<br>"));
			
			panel.Controls.Add(new LiteralControl("Result: "));
			
			TextBox txtResult = new TextBox();
			txtResult.Width = 50;
			panel.Controls.Add(txtResult);

			panel.Controls.Add(new LiteralControl("<br>"));

			Button btn = new Button();
			btn.Text = "Calculate";
			btn.Click += new EventHandler(btn_Click);
			panel.Controls.Add(btn);
		}

		private void btn_Click(object sender, EventArgs e)
		{
			if(Calculate != null && operation == CalculationOperationEnum.Custom)
			{
				((TextBox)Controls[0].Controls[7]).Text = ( Calculate(double.Parse(Text1), double.Parse(Text2)) ).ToString();
			}
			else
			{
				switch(operation)
				{
					case SimpleCalc.CalculationOperationEnum.Addition:
						((TextBox)Controls[0].Controls[7]).Text = ( double.Parse(((TextBox)Controls[0].Controls[2]).Text) + double.Parse(((TextBox)Controls[0].Controls[4]).Text) ).ToString();
						break;
					case SimpleCalc.CalculationOperationEnum.Division:
						((TextBox)Controls[0].Controls[7]).Text = ( double.Parse(((TextBox)Controls[0].Controls[2]).Text) / double.Parse(((TextBox)Controls[0].Controls[4]).Text) ).ToString();
						break;
					case SimpleCalc.CalculationOperationEnum.Multiplication:
						((TextBox)Controls[0].Controls[7]).Text = ( double.Parse(((TextBox)Controls[0].Controls[2]).Text) * double.Parse(((TextBox)Controls[0].Controls[4]).Text) ).ToString();
						break;
					case SimpleCalc.CalculationOperationEnum.Subtraction:
						((TextBox)Controls[0].Controls[7]).Text = ( double.Parse(((TextBox)Controls[0].Controls[2]).Text) - double.Parse(((TextBox)Controls[0].Controls[4]).Text) ).ToString();
						break;
				}
			}
		}
	}
}
