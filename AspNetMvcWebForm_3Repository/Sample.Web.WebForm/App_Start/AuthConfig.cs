using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Membership.OpenAuth;

namespace Sample.Web.WebForm
{
    internal static class AuthConfig
    {
        public static void RegisterOpenAuth()
        {
            // 請參閱 http://go.microsoft.com/fwlink/?LinkId=252803，取得設定此 ASP.NET 應用程式的詳細資料，
            //以支援透過外部服務進行登入。

            //OpenAuth.AuthenticationClients.AddTwitter(
            //    consumerKey: "您的 Twitter 使用者金鑰",
            //    consumerSecret: "您的 Twitter 使用者密碼");

            //OpenAuth.AuthenticationClients.AddFacebook(
            //    appId: "您的 Facebook 應用程式識別碼",
            //    appSecret: "您的 Facebook 應用程式密碼");

            //OpenAuth.AuthenticationClients.AddMicrosoft(
            //    clientId: "您的 Microsoft 帳戶用戶端識別碼",
            //    clientSecret: "您的 Microsoft 帳戶用戶端密碼");

            //OpenAuth.AuthenticationClients.AddGoogle();
        }
    }
}