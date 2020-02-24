using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lookup.Biz
{

    public class Lookup : Db_Base_Sql
	{

        public Lookup(string pConnectionString)
        {
        
        }

        public System.Data.DataSet Retrieve_Lookup(int lookupTypeID)
        {
            return Retrieve_Lookup(lookupTypeID, 0, false, false);
        }

        public System.Data.DataSet Retrieve_Lookup(int lookupTypeID, int parentID, bool addEmptyRow, bool useParent)
        {
            SqlParameter[] Params ={new SqlParameter("@LookupType",System.Data.SqlDbType.Int),
                                   new SqlParameter("@ParentID", System.Data.SqlDbType.Int),
                                   new SqlParameter("@AddEmptyRow", System.Data.SqlDbType.Int),
                                   new SqlParameter("@useParent", System.Data.SqlDbType.Int)
                                   
                                   };
            Params[0].Value = lookupTypeID;

            if (parentID > 0)
            {
                Params[1].Value = parentID;
            }
            else {
                Params[1].Value = parentID;
            }

            if (addEmptyRow)
            {
                Params[2].Value = 1;
            }
            else
            {
                Params[2].Value = 0;
            }

            if (useParent)
            {
                Params[3].Value = 1;
            }
            else
            {
                Params[3].Value = 0;
            }

            return RunProcedure("Lookup_fetchByLookupType", Params, "Lookup");

        }

        public System.Data.DataTable Retrieve_LookupTable(int lookupTypeID)
        {
            return Retrieve_LookupTable(lookupTypeID, 0, true);
        }

        public System.Data.DataTable Retrieve_LookupTable(int lookupTypeID, int subtype, bool addEmptyRow)
        {
            SqlParameter[] Params ={new SqlParameter("@LookupType",System.Data.SqlDbType.Int,4),
                                       new SqlParameter("@ParentID", System.Data.SqlDbType.Int),
                                   new SqlParameter("@SubType", System.Data.SqlDbType.Int),
                                   new SqlParameter("@AddEmptyRow", System.Data.SqlDbType.Int)};
            Params[0].Value = lookupTypeID;

            if (subtype > 0)
            {
                Params[1].Value = subtype;
            }

            if (addEmptyRow)
            {
                Params[2].Value = 1;
            }
            else
            {
                Params[2].Value = 0;
            }

            return RunProcedureTable("Lookup_fetchByLookupType", Params, "Lookup");

        }

        public System.Data.DataSet GenericLookup(string sp, string paramname, int value1, string tablename)
        {
            SqlParameter[] Params = {new SqlParameter(paramname, System.Data.SqlDbType.Int)};
                                        //new SqlParameter(paramname2, System.Data.SqlDbType.Int)};

            Params[0].Value = value1;
            //Params[1].Value = value2;
            return RunProcedure(sp,Params,tablename);
		
        } 

        public System.Data.DataSet GenericLookup(string sp, string tablename){
            SqlParameter[] Params = null;						
            return RunProcedure(sp,Params,tablename);
        }

        

        //	GenericLookup(System.String, System.String, Int32, System.String, Int32, System.String). 
        public System.Data.DataSet GenericLookup(string sp, string paramname1, int value1, string paramname2, int value2, string tablename){
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.Int)};

            Params[0].Value = value1;
            Params[1].Value = value2;
            return RunProcedure(sp,Params,tablename);
		
        } 

        public System.Data.DataSet GenericLookup(string sp, string paramname1, int value1, string paramname2, int value2, string paramname3, int value3, string tablename){
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.Int)};

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            return RunProcedure(sp,Params,tablename);
		
        }

        public System.Data.DataSet GenericLookup(string sp, string paramname1, int value1, string paramname2, int value2, string paramname3, string value3, string tablename)
        {
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.VarChar)};

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            return RunProcedure(sp, Params, tablename);

        }

        public System.Data.DataSet GenericLookup(string sp, string paramname1, string value1, string paramname2, string value2, string paramname3, string value3, string paramname4, int value4, string paramname5, int value5, string tablename)
        {
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname4, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname5, System.Data.SqlDbType.Int)};

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            Params[3].Value = value4;
            Params[4].Value = value5;
            return RunProcedure(sp, Params, tablename);

        } 

        public System.Data.DataSet GenericLookup(string sp, string paramname1, string value1, string paramname2, string value2, string paramname3, string value3, string tablename){
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.VarChar)};

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            return RunProcedure(sp,Params,tablename);
		
        }

        public System.Data.DataSet GenericLookup(string sp, string paramname1, string value1, string paramname2, string value2, string paramname3, string value3, string paramname4, string value4, string paramname5, string value5, string tablename)
        {
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname4, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname5, System.Data.SqlDbType.VarChar)};

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            Params[3].Value = value4;
            Params[4].Value = value5;
            return RunProcedure(sp, Params, tablename);

        }

        public System.Data.DataSet GenericLookup(string sp, string paramname1, int value1, string paramname2, int value2, string paramname3, int value3, string paramname4, string value4, string paramname5, string value5, string paramname6, int value6, string paramname7, int value7, string tablename)
        {
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname4, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname5, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname6, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname7, System.Data.SqlDbType.Int)
                                        
            };

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            Params[3].Value = value4;
            Params[4].Value = value5;
            Params[5].Value = value6;
            Params[6].Value = value7;
            return RunProcedure(sp, Params, tablename);

        }

        public System.Data.DataSet GenericLookup(string sp, string paramname1, int value1, string paramname2, string value2, string paramname3, int value3, string paramname4, string value4, string paramname5, string value5, string paramname6, int value6, string paramname7, int value7, string tablename)
        {
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname4, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname5, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname6, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname7, System.Data.SqlDbType.Int)
                                        
            };

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            Params[3].Value = value4;
            Params[4].Value = value5;
            Params[5].Value = value6;
            Params[6].Value = value7;
            return RunProcedure(sp, Params, tablename);

        }

        public System.Data.DataSet GenericLookup(string sp, string paramname1, int value1, string paramname2, int value2, string paramname3, string value3, string paramname4, string value4, string paramname5, string value5, string paramname6, int value6, string paramname7, int value7, string tablename)
        {
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname4, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname5, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname6, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname7, System.Data.SqlDbType.Int)
                                        
            };

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            Params[3].Value = value4;
            Params[4].Value = value5;
            Params[5].Value = value6;
            Params[6].Value = value7;
            return RunProcedure(sp, Params, tablename);

        }

        public System.Data.DataSet GenericLookup(string sp, string paramname1, int value1, string paramname2, string value2, string paramname3, string value3, string paramname4, string value4, string paramname5, string value5, string paramname6, int value6, string paramname7, int value7, string tablename)
        {
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname4, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname5, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname6, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname7, System.Data.SqlDbType.Int)
                                        
            };

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            Params[3].Value = value4;
            Params[4].Value = value5;
            Params[5].Value = value6;
            Params[6].Value = value7;
            return RunProcedure(sp, Params, tablename);

        } 

        public System.Data.DataSet GenericLookup(string sp, string paramname1, int value1, string paramname2, string value2, string tablename){
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.Int),
                                    new SqlParameter(paramname2, System.Data.SqlDbType.VarChar)};

            Params[0].Value = value1;
            Params[1].Value = value2;
            return RunProcedure(sp,Params,tablename);
        }

        public System.Data.DataSet GenericLookup(string sp, string paramname, string value1, string paramname2, int value2, string tablename){
            SqlParameter[] Params = {new SqlParameter(paramname, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.Int)};

            Params[0].Value = value1;
            Params[1].Value = value2;
            return RunProcedure(sp,Params,tablename);
		
        }


        public System.Data.SqlClient.SqlDataReader GenericLookup(string sp, string paramname, int valueid)
        {  
            SqlParameter[] Params ={new SqlParameter(paramname,System.Data.SqlDbType.Int,4)};
            Params[0].Value =  valueid;
            return RunProcedure(sp,Params);
        }

        public System.Data.SqlClient.SqlDataReader GenericLookup(string sp, string paramname, string value)
        {  
            SqlParameter[] Params ={new SqlParameter(paramname, System.Data.SqlDbType.VarChar,value.Length)};
            Params[0].Value =  value;
            return RunProcedure(sp,Params);
        }

        public System.Data.DataSet GenericLookup(string sp, string paramname, string value, string tablename)
        {  
            SqlParameter[] Params ={new SqlParameter(paramname, System.Data.SqlDbType.VarChar,value.Length)};
            Params[0].Value =  value;
            return RunProcedure(sp,Params,tablename);
        }

        public System.Data.DataSet GenericLookup(string storedProcName, IDataParameter[] parameters, string sTableName)
        {
            SqlParameter[] Params = new SqlParameter[parameters.Length];

            if (parameters != null)
            {
                for (int iIndex = 0; iIndex < parameters.Length; iIndex++)
                {
                    Params[iIndex] = new SqlParameter(parameters[iIndex].ParameterName, parameters[iIndex].DbType);
                    Params[iIndex].Value = parameters[iIndex].Value;
                }
            }

            return RunProcedure(storedProcName, parameters, sTableName);
        }


        public System.Data.DataSet GenericLookup(string sp, string paramname1, int value1, string paramname2, string value2, string paramname3, string value3, string paramname4, string value4, string paramname5, string value5, string paramname6, int value6, string paramname7, int value7, string paramname8, string value8, string tablename)
        {
            SqlParameter[] Params = {new SqlParameter(paramname1, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname2, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname3, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname4, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname5, System.Data.SqlDbType.VarChar),
                                        new SqlParameter(paramname6, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname7, System.Data.SqlDbType.Int),
                                        new SqlParameter(paramname8, System.Data.SqlDbType.VarChar)
                                        
            };

            Params[0].Value = value1;
            Params[1].Value = value2;
            Params[2].Value = value3;
            Params[3].Value = value4;
            Params[4].Value = value5;
            Params[5].Value = value6;
            Params[6].Value = value7;
            Params[7].Value = value8;
            return RunProcedure(sp, Params, tablename);

        } 

        
		

	}
		
}