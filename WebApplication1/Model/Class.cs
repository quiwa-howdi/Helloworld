using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication1.Model
{

    public class SqlClass
    {
        public List<Book> Sqlquery()//string keyword,Status status,string author
        {
            List<Book> result = new List<Book>();
            using (SqlConnection connection = new SqlConnection(new SqlConnectionStringBuilder() { DataSource = "DG-T420S-HOWDI", IntegratedSecurity = true, PersistSecurityInfo = false, InitialCatalog = "master" }.ConnectionString))
            {
                using (SqlCommand dc = connection.CreateCommand())
                {
                    dc.CommandText = @"SELECT * from book";

                    dc.Connection.Open();

                    using (SqlDataReader reader = dc.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            result.Add(new Book() { Id = Guid.Parse(reader["id"].ToString()),Name=reader["name"].ToString(),Status= (Statuses) Enum.Parse(typeof(Statuses),reader["status"].ToString()),Author=reader["author"].ToString() });
                            //Name = reader["namezhtw"].ToString(), Empno = reader["empno"].ToString(), EnterDate = DateTime.Parse(reader["enterdate"].ToString()), Email = reader["email"].ToString(), Sex = String.Compare(reader["sex"].ToString(), "M", true) == 0 ? Sex.male : Sex.Female, PositionId = !String.IsNullOrEmpty(reader["positionid"].ToString()) ? Guid.Parse(reader["positionid"].ToString()) : default(Guid), Autobiography = reader["autobiography"].ToString(), });
                        }
                    }
                    dc.Connection.Close();
                }
                
            }
            return result;
        }


    }
}


//using (SqlConnection connection = new SqlConnection(new SqlConnectionStringBuilder() { DataSource = "DG-A45V", IntegratedSecurity = true, PersistSecurityInfo = false, InitialCatalog = "恆天大陸", }.ConnectionString))
//{
//    using (SqlCommand dc = connection.CreateCommand())
//    {
//        dc.CommandText = @"SELECT TOP 15 dgpersonal.namezhtw, dgemployee.id, dgemployee.empno, dgemployee.enterdate, dgemployee.email, dgpersonal.sex , dgemployee.positionid, dgpersonal.autobiography
//                                       FROM dgemployee 
//                                       INNER JOIN dgpersonal ON dgpersonal.id = dgemployee.personid 
//                                       WHERE dgemployee.empno NOT LIKE '100%' 
//                                       ORDER BY dgemployee.initdate desc, dgemployee.empno ";

//        dc.Connection.Open();
//        using (SqlDataReader reader = dc.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                result.Add(new Employee() { Id = Guid.Parse(reader["id"].ToString()), Name = reader["namezhtw"].ToString(), Empno = reader["empno"].ToString(), EnterDate = DateTime.Parse(reader["enterdate"].ToString()), Email = reader["email"].ToString(), Sex = String.Compare(reader["sex"].ToString(), "M", true) == 0 ? Sex.male : Sex.Female, PositionId = !String.IsNullOrEmpty(reader["positionid"].ToString()) ? Guid.Parse(reader["positionid"].ToString()) : default(Guid), Autobiography = reader["autobiography"].ToString(), });
//            }
//        }

//        dc.Connection.Close();
//    }
//}