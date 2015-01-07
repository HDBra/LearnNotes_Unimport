using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace LearnFineUI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid1.DataSource = GetDataTable();
                Grid1.DataBind();
            }
        }



        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof (int)));
            table.Columns.Add(new DataColumn("Name", typeof (string)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof (String)));
            table.Columns.Add(new DataColumn("AtSchool", typeof (bool)));
            table.Columns.Add(new DataColumn("Major", typeof (string)));
            table.Columns.Add(new DataColumn("Group", typeof (int)));
            table.Columns.Add(new DataColumn("Gender", typeof (int)));
            table.Columns.Add(new DataColumn("LogTime", typeof (DateTime)));
            table.Columns.Add(new DataColumn("Desc", typeof (string)));
            table.Columns.Add(new DataColumn("Guid", typeof (Guid)));

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "陈萍萍";
            row[2] = "2000";
            row[3] = true;
            row[4] = "计算机应用技术";
            row[5] = 1;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-100);
            row[8] = "陈萍萍，女，20岁，出生于中国南方的一个小山村，毕业于中国科学技术大学。";
            row[9] = new Guid();
            table.Rows.Add(row);
  
            row = table.NewRow();
            row[0] = 102;
            row[1] = "胡飞";
            row[2] = "2008";
            row[3] = false;
            row[4] = "信息工程";
            row[5] = 1;
            row[6] = 1;
            row[7] = DateTime.Now.AddDays(-90);
            row[8] = "胡飞，男，20岁，出生于中国北方的一个小山村，毕业于南方科学技术大学。";
            row[9] = new Guid();
            table.Rows.Add(row);
  
            row = table.NewRow();
            row[0] = 103;
            row[1] = "金婷婷";
            row[2] = "2001";
            row[3] = true;
            row[4] = "会计学";
            row[5] = 2;
            row[6] = 0;
            row[7] = DateTime.Now.AddDays(-80);
            row[8] = "金婷婷，女，28岁，出生于中国海南岛的一个小山村，毕业于中国科学技术大学。";
            row[9] = new Guid();
            table.Rows.Add(row);
  
            return table;
        }
    }

}