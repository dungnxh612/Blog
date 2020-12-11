using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Blog.Models;

namespace Blog.DataAccess
{
    public class DataAccessLayer
    {
        public string InsertData(Blg blg)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;   
                cmd.Parameters.AddWithValue("@News", blg.News);
                cmd.Parameters.AddWithValue("@Category_ID", blg.Category_ID);
                cmd.Parameters.AddWithValue("@Status", blg.Status);
                cmd.Parameters.AddWithValue("@Position_ID", selectPosition(blg.Position));
                cmd.Parameters.AddWithValue("@Date", blg.Date);
                cmd.Parameters.AddWithValue("@Description", blg.Description);
                cmd.Parameters.AddWithValue("@Detail", blg.Detail);
                cmd.Parameters.AddWithValue("@Img", blg.Img);
                cmd.Parameters.AddWithValue("@Search", null);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public string UpdateData(Blg blg)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", blg.Id);
                cmd.Parameters.AddWithValue("@News", blg.News);
                cmd.Parameters.AddWithValue("@Category_ID", blg.Category_ID);
                cmd.Parameters.AddWithValue("@Status", blg.Status);
                cmd.Parameters.AddWithValue("@Position_ID", selectPosition(blg.Position));
                cmd.Parameters.AddWithValue("@Date", blg.Date);
                cmd.Parameters.AddWithValue("@Description", blg.Description);
                cmd.Parameters.AddWithValue("@Detail", blg.Detail);
                cmd.Parameters.AddWithValue("@Img", blg.Img);
                cmd.Parameters.AddWithValue("@Search", null);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteData(int id)
        {
            SqlConnection con = null;

            int result = 0;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Blogs> SelectAllData()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Blogs> listBlg = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                listBlg = new List<Blogs>();
                for(int i=0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blogs bl = new Blogs();
                    bl.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    bl.News = ds.Tables[0].Rows[i]["News"].ToString();
                    bl.Category_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Category_ID"].ToString());
                    bl.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                    bl.Position_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Position_ID"].ToString());
                    bl.Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString());
                    bl.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    bl.Detail = ds.Tables[0].Rows[i]["Detail"].ToString();
                    listBlg.Add(bl);
                }
                return listBlg;
            }
            catch
            {
                return listBlg;
            }
            finally
            {
                con.Close();
            }
        }


        public Blogs SelectDataById(int id)
        {
            SqlConnection con = null;
            DataSet ds = null;
            Blogs bl = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Query", 6);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bl = new Blogs();
                    bl.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    bl.News = ds.Tables[0].Rows[i]["News"].ToString();
                    bl.Category_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Category_ID"].ToString());
                    bl.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                    bl.Position_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Position_ID"].ToString());
                    bl.Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString());
                    bl.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    bl.Detail = ds.Tables[0].Rows[i]["Detail"].ToString();
                    bl.Img = ds.Tables[0].Rows[i]["Img"].ToString();
                }
                return bl;
            }
            catch
            {
                return bl;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Blogs> SelectData(string search)
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Blogs> listBlg = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", null);
                cmd.Parameters.AddWithValue("@News", null);
                cmd.Parameters.AddWithValue("@Category_ID", null);
                cmd.Parameters.AddWithValue("@Status", null);
                cmd.Parameters.AddWithValue("@Position_ID", null);
                cmd.Parameters.AddWithValue("@Date", null);
                cmd.Parameters.AddWithValue("@Description", null);
                cmd.Parameters.AddWithValue("@Detail", null);
                cmd.Parameters.AddWithValue("@Search", search);
                cmd.Parameters.AddWithValue("@Query", 5);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                listBlg = new List<Blogs>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blogs bl = new Blogs();
                    bl.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    bl.News = ds.Tables[0].Rows[i]["News"].ToString();
                    bl.Category_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Category_ID"].ToString());
                    bl.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                    bl.Position_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Position_ID"].ToString());
                    bl.Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString());
                    bl.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    bl.Detail = ds.Tables[0].Rows[i]["Detail"].ToString();
                    listBlg.Add(bl);
                }
                return listBlg;
            }
            catch
            {
                return listBlg;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Category> SelectCategory()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Category> listCate = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ListAllCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                listCate = new List<Category>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Category cate = new Category();
                    cate.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    cate.Category_Name = ds.Tables[0].Rows[i]["Category_Name"].ToString();
                    listCate.Add(cate);
                }
                return listCate;
            }
            catch
            {
                return listCate;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Position> SelectPosition()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<Position> listPos = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("ListAllPosition", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                listPos = new List<Position>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Position pos = new Position();
                    pos.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                    pos.Position_Name = ds.Tables[0].Rows[i]["Position_Name"].ToString();
                    listPos.Add(pos);
                }
                return listPos;
            }
            catch
            {
                return listPos;
            }
            finally
            {
                con.Close();
            }
        }

        public int selectPosition(string name)
        {
            Blogs blg = new Blogs();
            DataAccessLayer obj = new DataAccessLayer();
            List<Position> pos = obj.SelectPosition();
            foreach(Position item in pos)
            {
                if (item.Position_Name.Equals(name))
                {
                    return item.ID;
                }
            }
            return 0;
        }
    }
}