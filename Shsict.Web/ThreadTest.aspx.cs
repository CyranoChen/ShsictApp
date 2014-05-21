using Shsict.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shsict.Web
{
    public partial class ThreadTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            List<Job> lstJobs = new List<Job>();
            lstJobs.Add(new SampleJob());
            lstJobs.Add(new SampleJob2());

            SchedulerManager scheduler = new SchedulerManager(lstJobs);

            Thread myThread = new Thread(new ThreadStart(scheduler.Start));

            myThread.Start(); 
        }
    }
}