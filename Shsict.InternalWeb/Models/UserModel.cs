using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Shsict.InternalWeb.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Username { get; set; }

        public virtual string Password
        {
            get { return _password ?? Username; }
            set { _password = value; }
        }
        private string _password;

        public virtual string DisplayName
        {
            get { return _displayName ?? Username; }
            set { _displayName = value; }
        }
        private string _displayName;

        public string EmailAddress { get; set; }

    }
}