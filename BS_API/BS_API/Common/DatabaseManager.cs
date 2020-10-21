using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BS_API.Common
{
    public class DatabaseManager
    {
        private readonly String _conString;
        private IConfigurationRoot Configuration { get; set; }
        public DatabaseManager()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@"appsettings.json").Build();
            _conString = Configuration.GetSection("ConnectionStrings").GetSection("ConnectionString").Value;
        }

        public DataTable GetDataPost()
        {
            SqlConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                string connString = _conString;
                conn = new SqlConnection(connString);
                string query = "SELECT * FROM Table_Post";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Columns.Add("PostID");
                dt.Columns.Add("PostName");
                dt.Columns.Add("PostDate");
                while (dataReader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["PostID"] = dataReader.GetInt32("PostID");
                    dr["PostName"] = dataReader.GetString("PostName");
                    dr["PostDate"] = dataReader.GetString("PostDate");
                    dt.Rows.Add(dr);
                }
            }

            catch (SqlException)
            {
                // handle error 
            }

            catch (Exception ex)
            {
                // handle error 
            }

            finally
            {
                conn?.Close();
            }
            return dt;
        }
        public DataSet SearchDataPost(string id)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            DataTable dt = new DataTable();
            dt.TableName = "Post";
            try
            {
                string connString = _conString;
                conn = new SqlConnection(connString);
                string query = "SELECT * FROM Table_Post where PostId = " + int.Parse(id) + ""; 
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Columns.Add("PostID");
                dt.Columns.Add("PostName");
                dt.Columns.Add("PostDate");
                while (dataReader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["PostID"] = dataReader.GetInt32("PostID");
                    dr["PostName"] = dataReader.GetString("PostName");
                    dr["PostDate"] = dataReader.GetString("PostDate");
                    dt.Rows.Add(dr);
                }
            }

            catch (SqlException)
            {
                // handle error 
            }

            catch (Exception ex)
            {
                // handle error 
            }

            finally
            {
                conn?.Close();
            }

            ds.Tables.Add(dt);
            conn = null;
            dt = new DataTable();
            dt.TableName = "Comment";
            try
            {
                string connString = _conString;
                conn = new SqlConnection(connString);
                string query = "SELECT * FROM Comment where PostId = " + int.Parse(id) + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Columns.Add("CommentId");
                dt.Columns.Add("PostId");
                dt.Columns.Add("Comment");
                dt.Columns.Add("LikeCount");
                dt.Columns.Add("DislikeCount");
                while (dataReader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["CommentId"] = dataReader.GetInt32("CommentId");
                    dr["PostId"] = dataReader.GetInt32("PostId");
                    dr["Comment"] = dataReader.GetString("Comment");
                    dr["LikeCount"] = dataReader.GetInt32("LikeCount");
                    dr["DislikeCount"] = dataReader.GetInt32("DislikeCount");
                    dt.Rows.Add(dr);
                }
            }

            catch (SqlException)
            {
                // handle error 
            }

            catch (Exception)
            {
                // handle error 
            }

            finally
            {
                conn?.Close();
            }
            ds.Tables.Add(dt);
            return ds;
        }
        public DataTable GetDataComment()
        {
            SqlConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                string connString = _conString;
                conn = new SqlConnection(connString);
                string query = "SELECT * FROM Comment";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Columns.Add("CommentId");
                dt.Columns.Add("PostId");
                dt.Columns.Add("Comment");
                dt.Columns.Add("LikeCount");
                dt.Columns.Add("DislikeCount");
                while (dataReader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["CommentId"] = dataReader.GetInt32("CommentId");
                    dr["PostId"] = dataReader.GetInt32("PostId");
                    dr["Comment"] = dataReader.GetString("Comment");
                    dr["LikeCount"] = dataReader.GetInt32("LikeCount");
                    dr["DislikeCount"] = dataReader.GetInt32("DislikeCount");
                    dt.Rows.Add(dr);
                }
            }

            catch (SqlException)
            {
                // handle error 
            }

            catch (Exception)
            {
                // handle error 
            }

            finally
            {
                conn?.Close();
            }
            return dt;
        }
        public void LikeComment(string id)
        {
            SqlConnection conn = null;
            try
            {
                string connString = _conString;
                conn = new SqlConnection(connString);
                string query = "update Comment " +
                               "set LikeCount = (select LikeCount + 1 from Comment where CommentId = " + int.Parse(id) + ") " +
                               "where CommentId = " + int.Parse(id) + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                
                while (dataReader.Read())
                {
                }
            }

            catch (SqlException)
            {
                // handle error 
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conn?.Close();
            }
        }
        public void DisLikeComment(string id)
        {
            SqlConnection conn = null;
            try
            {
                string connString = _conString;
                conn = new SqlConnection(connString);
                string query = "update Comment " +
                               "set DislikeCount = (select DislikeCount + 1 from Comment where CommentId = " + int.Parse(id) + ") " +
                               "where CommentId = " + int.Parse(id) + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                }
            }

            catch (SqlException)
            {
                // handle error 
            }

            catch (Exception)
            {
                // handle error 
            }

            finally
            {
                conn?.Close();
            }
        }
    }
}
