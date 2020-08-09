using System;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Shsict.DataAccess
{
    /// <summary>
    /// 用户
    /// </summary>
    public class InternalUser
    {
        public static DataTable GetInternalUsers()
        {
            string sql = @"SELECT SUR_USERACCOUNT, SUR_PASSWORD, SUR_DISPLAYNAME, SUR_DESCRIPTION, SUR_CREATETIME, SUR_UPDATETIME, SUR_GROUP, SUR_STATUS, SUR_ERRORCOUNT, SUR_ISLOOKED 
                                  FROM SYS_USER";

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql);

            return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        }

        public static DataTable GetInternalUserByUserName(string userAccount)
        {
            string sql = @"SELECT SUR_USERACCOUNT, SUR_PASSWORD, SUR_DISPLAYNAME, SUR_DESCRIPTION, SUR_CREATETIME, SUR_UPDATETIME, SUR_GROUP, SUR_STATUS, SUR_ERRORCOUNT, SUR_ISLOOKED 
                                  FROM SYS_USER Where  SUR_USERACCOUNT = :userAccount";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("userAccount", userAccount);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql, para);

            return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        }

        public static DataTable GetInternalUserByUserNamePassword(string userAccount, string password)
        {
            string sql = @"SELECT SUR_USERACCOUNT, SUR_PASSWORD, SUR_DISPLAYNAME, SUR_DESCRIPTION, SUR_CREATETIME, SUR_UPDATETIME, SUR_GROUP, SUR_STATUS, SUR_ERRORCOUNT, SUR_ISLOOKED 
                                  FROM SYS_USER Where SUR_USERACCOUNT = :userAccount AND SUR_PASSWORD = :password";

            OracleParameter[] para = new OracleParameter[2];
            para[0] = new OracleParameter("userAccount", userAccount);
            para[1] = new OracleParameter("password", password);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql, para);

            return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        }

        public static DataTable GetUserResourceByUserName(string userName)
        {
            string sql = @"SELECT SUR_USERACCOUNT, SUR_RESOURCECODE 
                                  FROM SYS_USER_RESOURCE  Where SUR_USERACCOUNT = :userName";

            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("userName", userName);

            DataSet ds = OracleDataTool.ExecuteDataset(ConnectStringOracle.GetInternalTableConnection(), sql, para);

            return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
        }

        public static void Update(string userAccount, string password, string displayName, string description, DateTime createTime, DateTime updateTime, string group, int status, int errorCount, int isLooked)
        {
            //string sql = @"UPDATE SYS_USER SET SUR_PASSWORD = :password, SUR_DISPLAYNAME = :displayName, SUR_DESCRIPTION = :description, 
            //                      SUR_CREATETIME = :createTime, SUR_UPDATETIME = :updateTime, SUR_GROUP = :group,  SUR_STATUS = :status,  SUR_ERRORCOUNT = :errorCount, SUR_ISLOOKED = :isLooked 
            //                      WHERE SUR_USERACCOUNT = :userAccount";

            var sql = @"UPDATE SYS_USER SET SUR_PASSWORD = :password, SUR_STATUS = :status, SUR_ERRORCOUNT = :errorCount, SUR_ISLOOKED = :isLooked
                              WHERE SUR_USERACCOUNT = :userAccount";

            OracleParameter[] para = {
                    new OracleParameter("userAccount", userAccount),
                    new OracleParameter("password", password),
                    //new OracleParameter("displayName", displayName),
                    //new OracleParameter("description", description),
                    //new OracleParameter("createTime", createTime),
                    //new OracleParameter("updateTime", updateTime),
                    //new OracleParameter("group", group),
                    //new OracleParameter("status", status),
                    //new OracleParameter("errorCount", errorCount),
                    //new OracleParameter("isLooked", isLooked)
            };

            OracleDataTool.ExecuteNonQuery(ConnectStringOracle.GetInternalTableConnection(), sql, para);
        }
    }
}
