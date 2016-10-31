<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZadanieView.aspx.cs" Inherits="ZadanieRL.ZadanieView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Red Link</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:scriptmanager runat="server" />
        <telerik:RadListBox ID="RadListBox1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadListBox1_SelectedIndexChanged" />

        <div>
                <telerik:RadGrid ID="RadGrid1" runat="server" />     
        </div>
        
        <div>
                <telerik:RadDataForm ID="RadDataForm1" runat="server" />
        </div>

                <telerik:RadLabel ID="lblAddNewProduct" Text="Add new product" runat="server" />
                <telerik:RadTextBox ID="txbNewProductName" runat="server" />
                <telerik:RadComboBox ID="cbxCategoryOfNewProduct" runat="server"/>
                <telerik:RadButton ID="btnRadButtonAddNewProduct" runat="server" OnClick="btnRadButtonAddNewProduct_Click" Text="Ok" />
                <telerik:RadLabel ID="RadLabel1" Text="Add new product" Visible="false"  runat="server" />
        
    </form>
</body>
</html>
