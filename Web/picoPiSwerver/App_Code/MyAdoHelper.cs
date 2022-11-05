using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MyAdoHelper
/// פעולות עזר לשימוש במסד נתונים  מסוג 
/// SQL SERVER
///  App_Data המסד ממוקם בתקיה 
/// </summary>

public class MyAdoHelper
{
    public MyAdoHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }





    public static SqlConnection ConnectToDb(string fileName)
    {
        string path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד בפורוייקט
        path += fileName;
        //string path = HttpContext.Current.Server.MapPath("App_Data/" + fileName);//מאתר את מיקום מסד הנתונים מהשורש ועד התקייה בה ממוקם המסד
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\noamr\Documents\GitHub\picoPiRCE\Web\picoPiSwerver\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connString);
        return conn;

    }

    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומבצעת את הפעולה על המסד
    /// </summary>

    public static void DoQuery(string fileName, string sql)//הפעולה מקבלת שם מסד נתונים ומחרוזת מחיקה/ הוספה/ עדכון
    //ומבצעת את הפקודה על המסד הפיזי
    {

        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        com.ExecuteNonQuery();
        com.Dispose();
        conn.Close();

    }


    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומחזירה את מספר השורות שהושפעו מביצוע הפעולה
    /// </summary>
    public static int RowsAffected(string fileName, string sql)//הפעולה מקבלת מסלול מסד נתונים ופקודת עדכון
    //ומבצעת את הפקודה על המסד הפיזי
    {

        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        int rowsA = com.ExecuteNonQuery();
        conn.Close();
        return rowsA;
    }

    /// <summary>
    /// הפעולה מקבלת שם קובץ ומשפט לחיפוש ערך - מחזירה אמת אם הערך נמצא ושקר אחרת
    /// </summary>
    public static bool IsExist(string fileName, string sql)//הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
    {

        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        SqlDataReader data = com.ExecuteReader();
        bool found;
        found = (bool)data.Read();// אם יש נתונים לקריאה יושם אמת אחרת שקר - הערך קיים במסד הנתונים
        conn.Close();
        return found;

    }

    public static bool IsExistByUname(string fileName, string Uname)//this function gets a username and the Database name, it makes an sql query from the usernme and if there is any row that comes up on the query it returns true. it return ture;
    {
        string sql = "SELECT * FROM Info WHERE Uname='" + Uname + "'";
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        SqlDataReader data = com.ExecuteReader();
        bool found;
        found = (bool)data.Read();// אם יש נתונים לקריאה יושם אמת אחרת שקר - הערך קיים במסד הנתונים
        conn.Close();
        return found;

    }


    public static DataTable ExecuteDataTable(string fileName, string sql)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlDataAdapter tableAdapter = new SqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        tableAdapter.Fill(dt);
        return dt;
    }


    public static void ExecuteNonQuery(string fileName, string sql)
    {
        SqlConnection conn = ConnectToDb(fileName);
        conn.Open();
        SqlCommand command = new SqlCommand(sql, conn);
        command.ExecuteNonQuery();
        conn.Close();
    }

    public static string printDataTable(string fileName, string sql)//הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
    {//nice comment copying :)


        DataTable dt = ExecuteDataTable(fileName, sql);

        string printStr = "<table border='1'>";
        //adds a top layer to the table

        foreach (DataRow row in dt.Rows)
        {
            printStr += "<tr>";
            foreach (object myItemArray in row.ItemArray)
            {
                printStr += "<td>" + myItemArray.ToString() + "</td>";
            }
            printStr += "</tr>";
        }
        printStr += "</table>";

        return printStr;
    }


    public static string printDataTable(string fileName)//הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
    {//nice comment copying :)

        string sql = "select * from [Table]";

        DataTable dt = ExecuteDataTable(fileName, sql);

        string printStr = "<table border='1'>";
        //adds a top layer to the table

        foreach (DataRow row in dt.Rows)
        {
            printStr += "<tr>";
            foreach (object myItemArray in row.ItemArray)
            {
                printStr += "<td>" + myItemArray.ToString() + "</td>";
            }
            printStr += "</tr>";
        }
        printStr += "</table>";

        return printStr;
    }


    public static string printUsersDataTable(string fileName, string sql)
    {//prints the data table but adding a top layer of the nolumns names

        DataTable dt = ExecuteDataTable(fileName, sql);

        string printStr = "<table border='1'>";
        //adds a top layer to the table
        printStr += "<tr><td>ID </td><td>First name </td><td>Last name </td><td>User name </td><td>Password </td><td>Age </td><td>Phone number </td><td>Gender </td><td>E-mail </td> <td>Hobbies </td></tr>";

        foreach (DataRow row in dt.Rows)
        {
            printStr += "<tr>";
            foreach (object myItemArray in row.ItemArray)
            {
                printStr += "<td>" + myItemArray.ToString() + "</td>";
            }
            printStr += "</tr>";
        }
        printStr += "</table>";

        return printStr;
    }
    public static string printIdeaTable(string fileName, string sql)
    {

        DataTable dt = ExecuteDataTable(fileName, sql);

        string printStr = "<table border='1'>";
        //adds a top layer to the table
        printStr += "<tr><td>Ideas</td></tr>";
        foreach (DataRow row in dt.Rows)
        {
            printStr += "<tr>";
            foreach (object myItemArray in row.ItemArray)
            {
                printStr += "<td>" + myItemArray.ToString() + "</td>";
            }
            printStr += "</tr>";
        }
        printStr += "</table>";

        return printStr;
    }
    public static string returnValue(string fileName, string sql)//A function that returns the first value it stumbles upon
    {


        DataTable dt = ExecuteDataTable(fileName, sql);

        foreach (DataRow row in dt.Rows)
        {
            foreach (object myItemArray in row.ItemArray)
            {
                return myItemArray.ToString();
            }
        }
        return "";
    }
}