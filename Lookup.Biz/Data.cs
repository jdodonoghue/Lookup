using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Schema;
using System.Configuration;

namespace Lookup.Biz
{

	public abstract class Db_Base_Sql
	{
		protected SqlConnection Connection;
		private string mConnectionString;
		
		
		public Db_Base_Sql(string PWD, string Connectionstring)
		{
            
            string DBPWD = (string)ConfigurationManager.AppSettings[PWD];
            string sDBPWD = string.Empty;

            string constring = (string)ConfigurationManager.AppSettings[Connectionstring];
            mConnectionString = constring;
		
		}
        
		
		public Db_Base_Sql()
		{
		}

		protected string ConnectionString
		{
			get 
			{
				return mConnectionString;
			}
			set 
			{
				mConnectionString=value;
				if (Connection != null)
				{
					if (Connection.State == System.Data.ConnectionState.Open)
					{Connection.Close();}
				}
				Connection = new SqlConnection(mConnectionString);
			}
		}

		protected SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters )
		{
			SqlDataReader returnReader;

            using (SqlConnection cn = new SqlConnection(mConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = storedProcName;
                    if (parameters != null)
                    {
                        foreach (SqlParameter xParam in parameters)
                        {
                            cm.Parameters.Add(xParam);
                        }
                    }
                    returnReader = cm.ExecuteReader();
                                            
                }
                                    
            }
				
			return returnReader;
		}

		protected int RunProcedure(string storedProcName, IDataParameter[] parameters,  out int rowsAffected )
		{
			int result;
			
            using (SqlConnection cn = new SqlConnection(mConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = storedProcName;
                    if (parameters != null)
                    {
                        foreach (SqlParameter xParam in parameters)
                        {
                            cm.Parameters.Add(xParam);
                        }
                    }
                    rowsAffected = cm.ExecuteNonQuery();
                    result = (int)cm.Parameters["ReturnValue"].Value;
                }

            }

			return result;
		}

		protected DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName )
		{
			DataSet dataSet = new DataSet();

            using (SqlConnection cn = new SqlConnection(mConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = storedProcName;
                    if (parameters != null)
                    {
                        foreach (SqlParameter xParam in parameters)
                        {
                            cm.Parameters.Add(xParam);
                        }
                    }
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = cm;
                    sqlDA.Fill(dataSet, tableName);
                }
            }

			return dataSet;
		}

        protected DataSet RunProcedurePage(string pStoredProcName, IDataParameter[] parameters, string pTableName, int pStart, int pMaxRecords)
		{
			DataSet mDataSet = new DataSet();
			
            using (SqlConnection cn = new SqlConnection(mConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = pStoredProcName;

                    if (parameters != null)
                    {
                        foreach (SqlParameter xParam in parameters)
                        {
                            cm.Parameters.Add(xParam);
                        }
                    }
                    SqlDataAdapter mSqlDA = new SqlDataAdapter();
                    mSqlDA.SelectCommand = cm;
                    mSqlDA.Fill( mDataSet, pStart, pMaxRecords, pTableName );
                }
            }

            
			return mDataSet;
		}

		protected void RunProcedure(string storedProcName, IDataParameter[] parameters, DataSet dataSet, string tableName )
		{
			
            using (SqlConnection cn = new SqlConnection(mConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = storedProcName;

                    cm.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
                    cm.CommandTimeout = 1800;

                    if (parameters != null)
                    {
                        foreach (SqlParameter xParam in parameters)
                        {
                            cm.Parameters.Add(xParam);
                        }
                    }
                    SqlDataAdapter mSqlDA = new SqlDataAdapter();
                    mSqlDA.SelectCommand = cm;
                    if (tableName.Length > 0)
                    {
                        mSqlDA.Fill(dataSet, tableName);
                    }
                    else
                    {
                        mSqlDA.Fill(dataSet);
                    }
                }
            }
            
		}

        protected DataTable RunProcedureTable(string pStoredProcName, IDataParameter[] parameters, string pTableName)
		{
			DataTable mDataTable = new DataTable(pTableName);

            using (SqlConnection cn = new SqlConnection(mConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = pStoredProcName;

                    if (parameters != null)
                    {
                        foreach (SqlParameter xParam in parameters)
                        {
                            cm.Parameters.Add(xParam);
                        }
                    }
                    SqlDataAdapter mSqlDA = new SqlDataAdapter();
                    mSqlDA.SelectCommand = cm;
                    mSqlDA.Fill(mDataTable);
                }
            }
            

			return mDataTable;
		}

        protected DataTable RunProcedureTable(string pStoredProcName, IDataParameter[] parameters, string pTableName, int pMaxRows)
        {
            DataSet mDS = new DataSet(pTableName);

            using (SqlConnection cn = new SqlConnection(mConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = pStoredProcName;

                    if (parameters != null)
                    {
                        foreach (SqlParameter param in parameters)
                        {
                            cm.Parameters.Add(param);
                        }
                    }
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = cm;
                    sqlDA.Fill(mDS, 0, pMaxRows, pTableName);
                }
            }
                
            if (mDS.Tables.Count > 0)
                return mDS.Tables[0];
            else
                return null;
        }

        
        



      
		/// <summary>
		/// Can be used, If stored procedure returns a single value
		/// </summary>
		public object RunScalarQuery(string storedProcName,IDataParameter[] parameters)
		{
            object Rslt = null;

            using (SqlConnection cn = new SqlConnection(mConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = storedProcName;

                    if (parameters != null)
                    {
                        foreach (SqlParameter xParam in parameters)
                        {
                            cm.Parameters.Add(xParam);
                        }
                    }
                    Rslt = cm.ExecuteScalar(); //Getting result value as object, since result can be any type
                    
                }
            }
            
            return Rslt;

			
		}

	
	}
}
