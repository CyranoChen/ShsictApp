﻿using System;

namespace Shsict.Web
{
    public partial class Portal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IMaster master = this.Master as IMaster;

            master.setHeaderBtnVisible(false);
        }
    }
}