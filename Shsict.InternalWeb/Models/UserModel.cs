using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Contracts;

namespace Shsict.InternalWeb.Models
{
    public class User
    {
        public User() { }

        public User(DataRow dr)
        {
            InitUser(dr);
        }

        private void InitUser(DataRow dr)
        {
            if (dr != null)
            {
                Usercd = dr["usercd"].ToString();
                Username = dr["username"].ToString();
                Userpasswd = dr["userpasswd"].ToString();
            }
            else
            {
                throw new Exception("Unable to init User.");
            }
        }

        public void Select()
        {
            DataRow dr = Shsict.DataAccess.ContainerPlanUser.GetContainerPlanUserByID(Username, Userpasswd);

            if (dr != null)
            {
                InitUser(dr);
            }
        }

        public static List<User> GetContainerPlanUsers()
        {
            DataTable dt = Shsict.DataAccess.ContainerPlanUser.GetContainerPlanUsers();
            List<User> list = new List<User>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new User(dr));
                }
            }

            return list;
        }


        public string Usercd { get; set; }

        public string Username { get; set; }

        public string Userpasswd { get; set; }

    }
}