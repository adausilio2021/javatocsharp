using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace adausiliojavaandcsharp
{
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            // use to call c# in java
            webBrowser1.ObjectForScripting = this;
            webBrowser1.ScriptErrorsSuppressed = false;

            //disable right click
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.AllowWebBrowserDrop = false;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get current directory
            string CurrentDirectory = Directory.GetCurrentDirectory();

            //call HTML Page using navigate
            webBrowser1.Navigate(Path.Combine(CurrentDirectory, "HTMLPageFOrJavaScript.html"));
        }

        private void Report()
        {
            //get html pg fr div from id of div
            HtmlElement div = webBrowser1.Document.GetElementById("reportContent");
            //create simple html content
            StringBuilder sb = new StringBuilder();
            sb.Append("<table");
            sb.Append("<tr><td><B> Hi this is my report demo</B></td></tr>");
            sb.Append("</table>");
            //assign content to HTML page div display browser control
            div.InnerHtml = sb.ToString();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // when form loads focus on web browser control
            webBrowser1.Focus();

            //call report method
            Report();
        }

        private void PrintReport()
        {
            //show print dialouge
            DialogResult dr = printDialog1.ShowDialog();
            if(dr.ToString() =="OK")
            {
                webBrowser1.Print();
            }
            else
            {
                return;
            }

        }
            
    }
}
