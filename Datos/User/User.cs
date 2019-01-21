using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Entidad;

namespace Datos.User
{
    public class User
    {
        public User()
        {

        }
        public Boolean authentication(Entidad.User.User user)
        {
            Boolean validated = false;
            try
            {
                #region
                //String query = "SELECT * FROM users WHERE email='{0}' AND password='{1}'; ";
                //SqlCommand command = new SqlCommand(string.Format(query, email, password), SQLServerConnection.openConnection());
                //SqlDataReader reader = command.ExecuteReader();
                #endregion

                #region login example using SP
                SqlCommand cmd = new SqlCommand("sp_login", SQLServerConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", user.Email_);
                cmd.Parameters.AddWithValue("@password", user.Password_);
                SqlDataReader dr = cmd.ExecuteReader();
                #endregion

                while (dr.Read())
                {
                    validated = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SQLServerConnection.close();
            }

            return validated;
        }
        /// <summary>
        /// List all users
        /// </summary>
        /// <returns></returns>
        public List<Entidad.User.User> index()
        {
            try
            {
                List<Entidad.User.User> list = new List<Entidad.User.User>();
                String query = "SELECT id, name, last_name, email FROM users";
                SqlCommand command = new SqlCommand(string.Format(query), SQLServerConnection.open());
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Entidad.User.User user = new Entidad.User.User();
                    user.Id_ = reader.GetInt32(0);
                    user.Name_ = reader.GetString(1);
                    user.LastName_ = reader.GetString(2);
                    user.Email_ = reader.GetString(3);
                    list.Add(user);
                }

                return list;
                //Entidad.User.User user = new Entidad.User.User();
                //List<Entidad.User.User> list = new List<Entidad.User.User>();
                //SqlCommand cmd = new SqlCommand("sp_user_list", SQLServerConnection.open());
                //cmd.CommandType = CommandType.StoredProcedure;
                //SqlDataReader dr = cmd.ExecuteReader();

                //while (dr.Read())
                //{
                //    user.Id_ = dr.GetInt32(0);
                //    user.Name_ = dr.GetString(1);
                //    user.LastName_ = dr.GetString(2);
                //    user.Email_ = dr.GetString(3);
                //    list.Add(user);
                //}

                //return list;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SQLServerConnection.close();
            }
        }

        /// <summary>
        /// Store a new resource
        /// </summary>
        /// <returns></returns>
        public int store(Entidad.User.User user)
        {
            int retorno = 0;
            try
            {
                #region
                //String sql = "INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}')";
                //SqlCommand command = new SqlCommand(
                //    string.Format(
                //        sql,
                //        user.Name_,
                //        user.LastName_,
                //        user.Email_,
                //        user.Password_
                //    ), SQLServerConnection.open());
                #endregion

                #region example using SP
                SqlCommand cmd = new SqlCommand("sp_user_insert", SQLServerConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user.Name_);
                cmd.Parameters.AddWithValue("@last_name", user.LastName_);
                cmd.Parameters.AddWithValue("@email", user.Email_);
                cmd.Parameters.AddWithValue("@password", user.Password_);
                retorno = cmd.ExecuteNonQuery();
                #endregion

                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SQLServerConnection.close();
            }
        }
        /// <summary>
        /// Update specific resource
        /// </summary>
        /// <returns></returns>
        public int update(Entidad.User.User user)
        {
            int retorno = 0;
            try
            {
                #region login example using SP
                SqlCommand cmd = new SqlCommand("sp_user_insert", SQLServerConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user.Id_);
                cmd.Parameters.AddWithValue("@name", user.Name_);
                cmd.Parameters.AddWithValue("@last_name", user.LastName_);
                cmd.Parameters.AddWithValue("@email", user.Email_);
                cmd.Parameters.AddWithValue("@password", user.Password_);
                retorno = cmd.ExecuteNonQuery();
                #endregion

                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SQLServerConnection.close();
            }
        }
        /// <summary>
        /// Delete a specific resource
        /// </summary>
        /// <returns></returns>
        public int delete(Entidad.User.User user)
        {
            int retorno = 0;
            try
            {
                #region example using SP
                SqlCommand cmd = new SqlCommand("sp_user_insert", SQLServerConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user.Id_);
                retorno = cmd.ExecuteNonQuery();
                #endregion

                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                SQLServerConnection.close();
            }
        }
    }
}
