using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QueueBackgroundWorkItemLab
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                string root = Server.MapPath("~/Log");
                HostingEnvironment.QueueBackgroundWorkItem(ct => WriteFileLog(root, "Hello world!"));
            }
           
        }

        private async Task WriteFileLog(string root, string message)
        {
            FileStream file = new FileStream(root + "\\" + Guid.NewGuid().ToString("n") + ".txt", FileMode.Create);
            StreamWriter s = new StreamWriter(file);
            await s.WriteAsync(message);
            s.Dispose();
            file.Dispose();
        }
    }
}