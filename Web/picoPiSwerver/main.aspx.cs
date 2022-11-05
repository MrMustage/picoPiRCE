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
        string db = "C:\\Users\\noamr\\Documents\\GitHub\\picoPiRCE\\Web\\picoPiSwerver\\App_Data\\Database.mdf";
        string Path = "C:\\Users\\noamr\\Documents\\GitHub\\picoPiRCE\\Web\\picoPiSwerver\\";

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


        using (StreamWriter writer = new StreamWriter(Path+ "command.txt"))
        {
            writer.WriteLine(injection);
        }
        // Read a file  
        string readText = File.ReadAllText(Path+ "command.txtA");
        Console.WriteLine(readText);


        tbl = MyAdoHelper.printDataTable(db);
    }
}