<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
        <%=all %>
    <form id="form1" runat="server">
        <div>
           <select name="o" id="o" size="1">key strokes
                <option>website - "web","url"</option>
                <option>command - just the command</option>
                <option>key strokes - a string</option>
            </select>
            <input type="text" id="txt" name="txt" />
            <input type="submit" id="submit" name="submit" value="submit" />
        </div>
        [system.Diagnostics.Process]::Start("msedge/chrome/firefox", <"URL">)
    </form>
    </center>

</body>
</html>
