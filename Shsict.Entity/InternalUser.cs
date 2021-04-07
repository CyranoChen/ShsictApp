using System;
using System.Collections.Generic;
using System.Data;

namespace Shsict.Entity
{
    /// <summary>
    /// 靠离泊情况
    /// </summary>
    public class InternalUser
    {
        public InternalUser() { }

        public InternalUser(DataRow dr)
        {
            InitInternalUser(dr);
        }

        private void InitInternalUser(DataRow dr)
        {
            if (dr != null)
            {
                SUR_USERACCOUNT = dr["SUR_USERACCOUNT"].ToString();
                SUR_PASSWORD = dr["SUR_PASSWORD"].ToString();
                SUR_DISPLAYNAME = dr["SUR_DISPLAYNAME"].ToString();
                SUR_DESCRIPTION = dr["SUR_DESCRIPTION"].ToString();
                SUR_CREATETIME = DateTime.Parse(dr["SUR_CREATETIME"].ToString());
                SUR_UPDATETIME = DateTime.Parse(dr["SUR_UPDATETIME"].ToString());
                SUR_GROUP = dr["SUR_GROUP"].ToString();
                SUR_STATUS = Convert.ToInt16(dr["SUR_STATUS"]);
                SUR_ERRORCOUNT = Convert.ToInt16(dr["SUR_ERRORCOUNT"]);
                SUR_ISLOOKED = Convert.ToBoolean(dr["SUR_ISLOOKED"]);
                SUR_WECHATUSERID = dr["SUR_WECHATUSERID"].ToString();
            }
            else
            {
                throw new Exception("Unable to init User.");
            }
        }

        #region members and propertis
        public string SUR_USERACCOUNT { get; set; }

        public string SUR_PASSWORD { get; set; }

        public string SUR_DISPLAYNAME { get; set; }

        public string SUR_DESCRIPTION { get; set; }

        public DateTime SUR_CREATETIME { get; set; }

        public DateTime SUR_UPDATETIME { get; set; }

        public string SUR_GROUP { get; set; }

        public int SUR_STATUS { get; set; }

        public int SUR_ERRORCOUNT { get; set; }

        public bool SUR_ISLOOKED { get; set; }

        public string SUR_WECHATUSERID { get; set; }

        #endregion


        public static List<InternalUser> GetInitInternalUsers()
        {
            DataTable dt = DataAccess.InternalUser.GetInternalUsers();
            List<InternalUser> list = new List<InternalUser>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new InternalUser(dr));
                }
            }

            return list;
        }

        public static InternalUser Load(string username)
        {
            DataTable dt = DataAccess.InternalUser.GetInternalUserByUserName(username);

            if (dt != null && dt.Rows.Count > 0)
            {
                return new InternalUser(dt.Rows[0]);
            }

            return null;
        }

        public static InternalUser Authenticate(string username, string password)
        {
            DataTable dt = DataAccess.InternalUser.GetInternalUserByUserNamePassword(username, password);

            if (dt != null && dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                return new InternalUser(dr);
            }

            return null;
        }

        public static InternalUser AuthenticateWeChat(string weChatUserId)
        {
            DataTable dt = DataAccess.InternalUser.GetInternalUserByWeChatUserId(weChatUserId);

            if (dt != null && dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                return new InternalUser(dr);
            }

            return null;
        }

        public void Save()
        {
            DataAccess.InternalUser.Update(this.SUR_USERACCOUNT, this.SUR_PASSWORD, this.SUR_DISPLAYNAME, this.SUR_DESCRIPTION,
                this.SUR_CREATETIME, DateTime.Now, this.SUR_GROUP, this.SUR_STATUS, this.SUR_ERRORCOUNT,
                Convert.ToInt16(this.SUR_ISLOOKED), this.SUR_WECHATUSERID);
        }
    }

    public class UserResource
    {
        public UserResource() { }

        public UserResource(DataRow dr)
        {
            InitUserResource(dr);
        }

        private void InitUserResource(DataRow dr)
        {
            if (dr != null)
            {
                SUR_USERACCOUNT = dr["SUR_USERACCOUNT"].ToString();
                SUR_RESOURCECODE = dr["SUR_RESOURCECODE"].ToString();
            }
            else
            {
                throw new Exception("Unable to init User.");
            }
        }

        #region members and propertis

        public string SUR_USERACCOUNT { get; set; }

        public string SUR_RESOURCECODE { get; set; }

        #endregion

        public static List<UserResource> GetUserResourceByUserName(string userName)
        {
            DataTable dt = Shsict.DataAccess.InternalUser.GetUserResourceByUserName(userName);
            List<UserResource> list = new List<UserResource>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new UserResource(dr));
                }
            }

            return list;
        }

    }

    public class PasswordModel
    {
        #region members and propertis

        public string PasswordOld { get; set; }

        public string PasswordNew { get; set; }

        public string PasswordRepeat { get; set; }

        #endregion
    }
}