﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist_windows_form
{
    [Serializable()]
    class Settings
    {
        private
            String _serverURL;
            String _user;
            String _password;

        public String ServerURL {
            get { return _serverURL; }
            set { _serverURL = value; }
        }
        public String User
        {
            get { return _user; }
            set { _user = value; }
        }
        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Settings() {
            _serverURL = String.Empty;
            _user = String.Empty;
            _password = String.Empty;
        }

    }
}