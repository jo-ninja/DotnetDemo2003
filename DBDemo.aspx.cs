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
using System.Data.SqlClient;

namespace dotNetDemo
{
	/// <summary>
	/// Summary description for DBDemo.
	/// </summary>
	public class DBDemo : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected dotNetDemo.DataSet1 dataSet11;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;

		private string SortExpression
		{
			get
			{
				if(ViewState["SortExpression"] == null)
					return (ViewState["SortExpression"] = String.Empty).ToString();
				return ViewState["SortExpression"].ToString();
			}
			set
			{
				ViewState["SortExpression"] = value;
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.LoadData();

			if(!IsPostBack)
			{
				DataGrid1.DataBind();
			}
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dataSet11 = new dotNetDemo.DataSet1();
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
			this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=ZHANG;packet size=4096;user id=sa;data source=ZHANG;persist securi" +
				"ty info=True;initial catalog=dotNetDemo;password=password";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "MsUser", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("id", "id"),
																																																				new System.Data.Common.DataColumnMapping("name", "name"),
																																																				new System.Data.Common.DataColumnMapping("city", "city"),
																																																				new System.Data.Common.DataColumnMapping("country", "country")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM dbo.MsUser WHERE (id = @Original_id) AND (city = @Original_city OR @Original_city IS NULL AND city IS NULL) AND (country = @Original_country OR @Original_country IS NULL AND country IS NULL) AND (name = @Original_name OR @Original_name IS NULL AND name IS NULL)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_id", System.Data.SqlDbType.VarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_country", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "country", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO dbo.MsUser(id, name, city, country) VALUES (@id, @name, @city, @count" +
				"ry); SELECT id, name, city, country FROM dbo.MsUser WHERE (id = @id)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.VarChar, 3, "id"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "name"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 30, "city"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@country", System.Data.SqlDbType.VarChar, 30, "country"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT id, name, city, country FROM dbo.MsUser";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.MsUser SET id = @id, name = @name, city = @city, country = @country WHERE (id = @Original_id) AND (city = @Original_city OR @Original_city IS NULL AND city IS NULL) AND (country = @Original_country OR @Original_country IS NULL AND country IS NULL) AND (name = @Original_name OR @Original_name IS NULL AND name IS NULL); SELECT id, name, city, country FROM dbo.MsUser WHERE (id = @id)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.VarChar, 3, "id"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.VarChar, 50, "name"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.VarChar, 30, "city"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@country", System.Data.SqlDbType.VarChar, 30, "country"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_id", System.Data.SqlDbType.VarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_city", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "city", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_country", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "country", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "name", System.Data.DataRowVersion.Original, null));
			// 
			// dataSet11
			// 
			this.dataSet11.DataSetName = "DataSet1";
			this.dataSet11.Locale = new System.Globalization.CultureInfo("en-US");
			this.Load += new System.EventHandler(this.Page_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();

		}
		#endregion

		private void LoadData()
		{
			sqlDataAdapter1.Fill(dataSet11);
			DataGrid1.DataSource = dataSet11.Tables[0];
		}

		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LoadSortedData(source, this.SortExpression = e.SortExpression);
			((DataGrid)source).DataBind();
		}

		private void LoadSortedData(object source, string sortExpression)
		{
			DataView dv = new DataView( (DataTable) ((DataGrid)source).DataSource );
			((DataGrid)source).SelectedIndex = -1;
			((DataGrid)source).EditItemIndex = -1;
			dv.Sort = sortExpression;
			((DataGrid)source).DataSource = dv;
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.LoadSortedData(source, this.SortExpression);
			((DataGrid)source).SelectedIndex = -1;
			((DataGrid)source).EditItemIndex = -1;
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;
			((DataGrid)source).DataBind();
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.LoadSortedData(source, this.SortExpression);
			((DataGrid)source).SelectedIndex = -1;
			((DataGrid)source).EditItemIndex = e.Item.ItemIndex;
			((DataGrid)source).DataBind();
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.LoadSortedData(source, this.SortExpression);
			((DataGrid)source).SelectedIndex = -1;
			((DataGrid)source).EditItemIndex = -1;
			((DataGrid)source).DataBind();
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "Select")
			{
				this.LoadSortedData(source, this.SortExpression);
				((DataGrid)source).SelectedIndex = e.Item.ItemIndex;
				((DataGrid)source).DataBind();
			}
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string id = e.Item.Cells[1].Text;
			string name = ((TextBox)e.Item.FindControl("txtName")).Text;
			string city = ((TextBox)e.Item.FindControl("txtCity")).Text;
			string country = ((TextBox)e.Item.FindControl("txtCountry")).Text;

			sqlConnection1.Open();
			SqlCommand cmd = new SqlCommand("update MsUser set name='"+name+"',city='"+city+"',country='"+country+"' where id='"+id+"'", sqlConnection1);
			cmd.ExecuteNonQuery();
			sqlConnection1.Close();

			this.LoadData();
			this.LoadSortedData(source, this.SortExpression);
			((DataGrid)source).SelectedIndex = e.Item.ItemIndex;
			((DataGrid)source).DataBind();
		}

		private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.EditItem || e.Item.ItemType == ListItemType.SelectedItem)
			{
				((DropDownList)e.Item.FindControl("lstTes")).DataSource = dataSet11.Tables[0];
				((DropDownList)e.Item.FindControl("lstTes")).DataTextField = "city";
				((DropDownList)e.Item.FindControl("lstTes")).DataValueField = "city";
				((DropDownList)e.Item.FindControl("lstTes")).DataBind();
			}
		}
	}
}
