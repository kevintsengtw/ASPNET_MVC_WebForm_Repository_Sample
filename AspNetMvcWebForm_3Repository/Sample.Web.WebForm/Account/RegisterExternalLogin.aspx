<%@ Page Language="C#" Title="註冊外部登入" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="Sample.Web.WebForm.Account.RegisterExternalLogin" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>註冊您的 <%: ProviderDisplayName %> 帳戶</h1>
        <h2><%: ProviderUserName %>.</h2>
    </hgroup>

    
    <asp:ModelErrorMessage runat="server" ModelStateKey="Provider" CssClass="field-validation-error" />
    

    <asp:PlaceHolder runat="server" ID="userNameForm">
        <fieldset>
            <legend>關聯表單</legend>
            <p>
                您已經以 <strong><%: ProviderUserName %></strong> 身分
                驗證 <strong><%: ProviderDisplayName %></strong>。請在下面輸入目前站台的使用者名稱，
                然後按一下 [登入] 按鈕。
            </p>
            <ol>
                <li class="email">
                    <asp:Label runat="server" AssociatedControlID="userName">使用者名稱</asp:Label>
                    <asp:TextBox runat="server" ID="userName" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="userName"
                        Display="Dynamic" ErrorMessage="需要使用者名稱" ValidationGroup="NewUser" />
                    
                    <asp:ModelErrorMessage runat="server" ModelStateKey="UserName" CssClass="field-validation-error" />
                    
                </li>
            </ol>
            <asp:Button runat="server" Text="登入" ValidationGroup="NewUser" OnClick="logIn_Click" />
            <asp:Button runat="server" Text="取消" CausesValidation="false" OnClick="cancel_Click" />
        </fieldset>
    </asp:PlaceHolder>
</asp:Content>
