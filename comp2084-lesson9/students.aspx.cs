using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2084_lesson9.Models;

namespace comp2084_lesson9
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                GetStudents();
            }
        }

        protected void GetStudents() 
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var stu = from s in db.Students
                          select s;

                grdStudents.DataSource = stu.ToList();
                grdStudents.DataBind();
              
            
            }
        
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);
            using (DefaultConnection db = new DefaultConnection())
            {
                Student stu = (from s in db.Students
                               where s.StudentID == StudentID
                               select s).FirstOrDefault();

                db.Students.Remove(stu);
                db.SaveChanges();

                GetStudents();
            
            }
        }
    }
}