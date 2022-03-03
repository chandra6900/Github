using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using Bankdata.Models;

namespace Bankdata.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        static string connstrng = ConfigurationManager.ConnectionStrings["bankcon"].ConnectionString;

        public ActionResult LogIn()
        {
            List<BankRecord> brlist=ReadFromDb();
            return View(brlist);
        }

       
        public ActionResult LogOut()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string BankName,string cityName,string Address)
        {
            WriteToDb(BankName, cityName, Address);
        }

        private static void WriteToDb(string BankName, string cityName, string Address)
        {
            //string connstrng = ConfigurationManager.ConnectionStrings["bankcon"].ConnectionString;
            BankName = "'" + BankName + "'";
            cityName = "'" + cityName + "'";
            Address = "'" + Address + "'";
            using (SqlConnection con = new SqlConnection(connstrng))
            {
                SqlCommand sqlcmd = new SqlCommand("insert into tmphello (BankName,City,Address) values (" + BankName + "," + cityName + "," + Address + ");", con);
                con.Open();
                try
                {
                    sqlcmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Source);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private List<BankRecord> ReadFromDb()
        {
            using (SqlConnection con = new SqlConnection(connstrng))
            {
                List<BankRecord> brlist = null;
                SqlCommand sqlcmd = new SqlCommand("select * from tmphello;", con);
                con.Open();
                try
                {
                    SqlDataReader rdr = sqlcmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        brlist = new List<BankRecord>();
                        while (rdr.Read())
                        {
                            BankRecord br = new BankRecord();
                            br.BankName = rdr.GetString(1);
                            br.City = rdr.GetString(2);
                            br.Address = rdr.GetString(3);
                            brlist.Add(br);
                        }                      
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Source);
                }
                finally
                {
                    con.Close();
                }
                return brlist;
            }

        }

    }
}
