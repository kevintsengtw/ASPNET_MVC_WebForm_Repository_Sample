<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Sample.Web.WebForm.Employee.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" />
            <asp:BoundField DataField="HireDate" HeaderText="HireDate" />
            <asp:TemplateField HeaderText="Option">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink_Details" runat="server" Text="Details"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
