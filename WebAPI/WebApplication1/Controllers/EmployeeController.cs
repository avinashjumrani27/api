using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
             string query = @"
                     select EmployeeId,EmployeeCode,Name,Email,Phone,DOB,
                    Age,skills,address,Department,Status
                     from
                     dbo.Employee
                     ";
             DataTable table = new DataTable();
             using (var con = new SqlConnection(ConfigurationManager.
                 ConnectionStrings["EmployeeAppDB"].ConnectionString))
             using (var cmd = new SqlCommand(query, con))
             using (var da = new SqlDataAdapter(cmd))
             {
                 cmd.CommandType = CommandType.Text;
                 da.Fill(table);
          }
           /// DataTable table = new DataTable();

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string Post(Employee emp)
        {
            try
            {
                string query = @"
                    insert into dbo.Employee values
                    (
                    '" +  emp.EmployeeCode + @"'
                    ,'" + emp.Name + @"'
                    ,'" + emp.Email + @"'
                    ,'" + emp.Phone + @"'
                    ,'" + emp.DOB + @"'
                    ,'" + emp.Age + @"'
                    ,'" + emp.skills + @"'
                    ,'" + emp.address + @"'
                    ,'" + emp.Department + @"'
                    ,'" + emp.Status + @"'

               )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }


        public string Put(Employee emp)
        {
            try
            {
                string query = @"
                    update dbo.Employee set 
                     EmployeeCode='" + emp.EmployeeCode + @"'
                    ,Name='" + emp.Name + @"'
                    ,Email='" + emp.Email + @"'
                    ,Phone='" + emp.Phone + @"'
                    ,DOB='" + emp.DOB + @"'
                    ,Age='" + emp.Age + @"'
                    ,skills='" + emp.skills + @"'
                    ,address='" + emp.address + @"'
                    ,Department='" + emp.Department + @"'  
                    ,Statuss='" + emp.Status + @"' 
                    where EmployeeId=" + emp.EmployeeId + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
               

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }


        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Employee 
                    where EmployeeId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }

        [Route("api/Employee/GetAllDepartmentNames")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentNames()
        {
            string query = @"
                    select DepartmentName,DepartmentStatus from dbo.Department";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

      

    }
}
