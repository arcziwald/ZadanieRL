<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZadanieView.aspx.cs" Inherits="ZadanieRL.ZadanieView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Red Link</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:scriptmanager runat="server"></asp:scriptmanager>

        <telerik:RadListBox ID="RadListBox1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadListBox1_SelectedIndexChanged"></telerik:RadListBox>
        <div>
                <telerik:RadGrid ID="RadGrid1" runat="server"></telerik:RadGrid>
        </div>
        <telerik:RadDataForm ID="RadDataForm1" runat="server"></telerik:RadDataForm>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
