<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to select all rows except disabled on the client side</title>

    <script type="text/javascript" src="Scripts/JScript.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="dsGrid"
            ClientInstanceName="grid" KeyFieldName="ProductID" OnCommandButtonInitialize="grid_CommandButtonInitialize"
            OnCustomJSProperties="grid_CustomJSProperties" OnCustomCallback="grid_CustomCallback"
            OnDataBound="grid_DataBound">
            <Settings ShowFilterRow="true" />
            <Columns>
                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                    <HeaderTemplate>
                        <dx:ASPxCheckBox ID="cbAll" runat="server" ClientInstanceName="cbAll" ToolTip="Select all rows"
                            BackColor="White" OnInit="cbAll_Init">
                            <ClientSideEvents CheckedChanged="OnAllCheckedChanged" />
                        </dx:ASPxCheckBox>
                        <dx:ASPxCheckBox ID="cbPage" runat="server" ClientInstanceName="cbPage" ToolTip="Select all rows within the page">
                            <ClientSideEvents CheckedChanged="OnPageCheckedChanged" />
                        </dx:ASPxCheckBox>
                    </HeaderTemplate>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Visible="true" FieldName="CategoryID">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="QuantityPerUnit" VisibleIndex="4">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="5">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UnitsInStock" VisibleIndex="6">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="UnitsOnOrder" VisibleIndex="7">
                </dx:GridViewDataTextColumn>
            </Columns>
            <ClientSideEvents SelectionChanged="OnGridSelectionChanged" EndCallback="OnGridEndCallback" />
        </dx:ASPxGridView>
        <asp:AccessDataSource ID="dsGrid" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder] FROM [Products]">
        </asp:AccessDataSource>
    </div>
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Sellect ALL rows" OnClick="ASPxButton1_Click">
    </dx:ASPxButton>
    </form>
</body>
</html>
