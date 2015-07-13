using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2084_lesson9.Models;

namespace comp2084_lesson9
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    GetStudent();
                }
            }
        }

        protected void GetStudent()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                Student stu = (from s in db.Students
                               where s.StudentID == StudentID
                               select s).FirstOrDefault();
                txtLastName.Text = stu.LastName;
                txtFirstName.Text = stu.FirstMidName;
               txtDate.Text = stu.EnrollmentDate.ToString("yyyy-MM-dd");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                Student stu = new Student();

                Int32 StudentID = 0;

                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                    stu = (from s in db.Students
                           where s.StudentID == StudentID
                           select s).FirstOrDefault();
                                
                 }

                stu.LastName = txtLastName.Text;
                stu.FirstMidName = txtFirstName.Text;
                stu.EnrollmentDate = Convert.ToDateTime(txtDate.Text);

                if (StudentID == 0)
                {
                    db.Students.Add(stu);
                }
                db.SaveChanges();

                Response.Redirect("students.aspx");

            
            }
        }
    }
}