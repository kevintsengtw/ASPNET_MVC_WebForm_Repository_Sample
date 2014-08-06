<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="Sample.Web.WebForm.Account.OpenAuthProviders" %>

<fieldset class="open-auth-providers">
    <legend>使用其他服務登入</legend>
    
    <asp:ListView runat="server" ID="providerDetails" ItemType="Microsoft.AspNet.Membership.OpenAuth.ProviderDetails"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <button type="submit" name="provider" value="<%#: Item.ProviderName %>"
                title="使用您的帳戶<%#: Item.ProviderDisplayName %>登入。">
                <%#: Item.ProviderDisplayName %>
            </button>
        </ItemTemplate>
    
        <EmptyDataTemplate>
            <div class="message-info">
                <p>未設定任何外部驗證服務。請參閱<a href="http://go.microsoft.com/fwlink/?LinkId=252803">本文</a>，取得設定此 ASP.NET 應用程式的詳細資料，以支援透過外部服務進行登入。</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</fieldset>