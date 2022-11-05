using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class main : System.Web.UI.Page
{
    public string injection;
    public string tbl;
    public string option;
    public string all = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string db = "C:\\Users\\noamr\\Documents\\GitHub\\picoPiPCE\\Web\\picoPiSwerver\\App_Data\\Database.mdf";
        string Path = "C:\\Users\\noamr\\Documents\\GitHub\\picoPiRCE\\Web\\picoPiSwerver\\";

        if (Request.Form["submit"] != null)
        {
            injection = Request.Form["txt"];
            option = Request.Form["o"];
            if(option == "website - \"web\",\"url\"")
            {
                all = "[system.Diagnostics.Process]::Start(" + injection + ")"; 
            }
            if(option == "command - just the command")
            {
                all = injection;
            }
            if(option == "key strokes - a string")
            {

            }

            if(Request.Form["txt"] == "")
            {
                all = null;
            }

            //MyAdoHelper.DoQuery(db,"update[Table] set str = '"+all+"'");
        }
        else
        {
            all = "";
            //MyAdoHelper.DoQuery(db, "update[Table] set str = 'null'");
        }


        using (StreamWriter writer = new StreamWriter(Path+ "command.txt"))
        {
            writer.WriteLine(injection);
        }
        // Read a file  
        string readText = File.ReadAllText(Path+ "command.txt");
        Console.WriteLine(readText);


        tbl = MyAdoHelper.printDataTable(db);
    }
}