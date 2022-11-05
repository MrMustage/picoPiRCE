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
    protected void Page_Load(object sender, EventArgs e)
    {
        string db = "C:\\Users\\noamr\\Desktop\\picoInject\\picoPiSwerver\\App_Data\\Database.mdf";
        string commandPath = "C:\\Users\\noamr\\Desktop\\picoInject\\picoPiSwerver\\command.txt";

        if (Request.Form["submit"] != null)
        {
            injection = Request.Form["txt"];
            
            MyAdoHelper.DoQuery(db,"update[Table] set str = '"+injection+"'");
        }
        else
        {
            injection = null;
            MyAdoHelper.DoQuery(db, "update[Table] set str = 'null'");
        }


        using (StreamWriter writer = new StreamWriter(commandPath))
        {
            writer.WriteLine(injection);
        }
        // Read a file  
        string readText = File.ReadAllText(commandPath);
        Console.WriteLine(readText);


        tbl = MyAdoHelper.printDataTable(db);
    }
}