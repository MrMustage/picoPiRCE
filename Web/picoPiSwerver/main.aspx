<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
        <%=injection %>
    <form id="form1" runat="server">
        <div>
            <input type="text" id="txt" name="txt" />
            <input type="submit" id="submit" name="submit" value="submit" />
        </div>
        [system.Diagnostics.Process]::Start("msedge/chrome/firefox", <"URL">)
    </form>
        <%=tbl %>
    </center>

</body>
</html>
