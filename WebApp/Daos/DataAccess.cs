using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using WebApp.Models;

namespace WebApp.Daos
{
    public static class DataAccess<T> where T : AbstractIdentificable, new()
    {
        public static List<T> Get(int? id)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RedCard"].ConnectionString);

            var result = new List<T>();

            try
            {
                var cmd = new SqlCommand
                {
                    CommandText = CreateSelectCommand(),
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandTimeout = 360
                };

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var entity = new T();

                    foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == typeof (int))
                            propertyInfo.SetValue(entity, int.Parse(reader[propertyInfo.Name].ToString()));
                        else
                            propertyInfo.SetValue(entity, reader[propertyInfo.Name].ToString());
                    }

                    result.Add(entity);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public static T Insert(T entity)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RedCard"].ConnectionString);

            try
            {
                var cmd = new SqlCommand
                {
                    CommandText = CreateInsertCommand(entity),
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandTimeout = 360
                };

                connection.Open();

                cmd.Transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                connection.Close();
            }

            return entity;
        }

        static string CreateSelectCommand()
        {
            var command = new StringBuilder();
            command.Append("select ");

            var type = new T().GetType();

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                command.AppendFormat("{0}, ",propertyInfo.Name);
            }

            command.Remove(command.Length - 2, 2);
            command.AppendFormat(" from {0}", type.Name);

            return command.ToString();
        }

        static string CreateInsertCommand(T entity)
        {
            var command = new StringBuilder();
            command.AppendFormat("insert into {0} ", entity.GetType().Name);
            command.Append("values (");
            // string values = "";
            foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
            {
                // command.AppendLine(propertyInfo.Name);
                command.AppendFormat("'{0}'", propertyInfo.GetValue(entity));
            }

            return command.ToString();
        }

        public static List<T> GetAll()
        {
           return Get(null);
        }
    }
}