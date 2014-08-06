<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Sample.Web.WebForm.Employee.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Details</h2>
    <fieldset>
        <legend>Employee</legend>
        <div class="display-label">
            EmployeeID
        </div>
        <div class="display-field">
            <asp:Label ID="Label_EmployeeID" runat="server"></asp:Label>
        </div>
        <div class="display-label">
            LastName
        </div>
        <div class="display-field">
            <asp:TextBox ID="TextBox_LastName" runat="server"></asp:TextBox>
        </div>
        <div class="display-label">
            FirstName
        </div>
        <div class="display-field">
            <asp:TextBox ID="TextBox_FirstName" runat="server"></asp:TextBox>
        </div>
        <div class="display-label">
            Title
        </div>
        <div class="display-field">
            <asp:TextBox ID="TextBox_Title" runat="server"></asp:TextBox>
        </div>
        <div class="display-label">
            BirthDate
        </div>
        <div class="display-field">
            <asp:TextBox ID="TextBox_BirthDate" runat="server"></asp:TextBox>
        </div>
        <div class="display-label">
            HireDate
        </div>
        <div class="display-field">
            <asp:TextBox ID="TextBox_HireDate" runat="server"></asp:TextBox>
        </div>
    </fieldset>
    <br />
    <asp:HyperLink ID="HyperLink_List" runat="server" NavigateUrl="List.aspx">Back to List</asp:HyperLink>

</asp:Content>
