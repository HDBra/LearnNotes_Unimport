using System;
using System.Collections.Generic;
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
                List<JQueryFeature> myList = new List<JQueryFeature>();
                myList.Add(new JQueryFeature("0", "Jquery", 0, false));
                myList.Add(new JQueryFeature("1", "核心", 1, false));
                myList.Add(new JQueryFeature("2", "选择符", 1, false));
                myList.Add(new JQueryFeature("3", "基本选择符", 2, true));
                myList.Add(new JQueryFeature("4", "内容选择符", 2, true));
                myList.Add(new JQueryFeature("5", "属性选择符", 2, true));
                myList.Add(new JQueryFeature("6", "筛选", 1, false));
                myList.Add(new JQueryFeature("7", "过滤", 2, true));
                myList.Add(new JQueryFeature("8", "查找", 2, true));
                myList.Add(new JQueryFeature("9", "事件", 1, false));
                myList.Add(new JQueryFeature("10", "页面载入", 2, true));
                myList.Add(new JQueryFeature("11", "事件处理", 2, true));
                myList.Add(new JQueryFeature("12", "事件委托", 2, true));

                ddlBox.DataTextField = "Name";
                ddlBox.DataValueField = "Id";
                ddlBox.DataSimulateTreeLevelField = "Level";
                ddlBox.DataEnableSelectField = "EnableSelect";
                ddlBox.DataSource = myList;
                ddlBox.DataBind();
                ddlBox.SelectedValue = "3";
            }
        }

    }


    public class JQueryFeature
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool EnableSelect { get; set; }

        public JQueryFeature(String id, String name, int level, bool enableSelect)
        {
            this.Id = id;
            this.Name = name;
            this.Level = level;
            this.EnableSelect = enableSelect;
        }
    }
}