// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Alpata.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_meetingResource"){Scopes={ "Meeting_fullpermission" } },
            new ApiResource("resource_user_meetingResource"){Scopes={ "Meeting_read" } },          
            new ApiResource("resource_gateway"){Scopes={ "Gateway_fullpermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){Name="roles",DisplayName ="Roles",Description ="Kullanıcı Rolleri", UserClaims= new[]{"role" } }

                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
          new ApiScope("Meeting_fullpermission", "Meeting API için Full Erişim"),
          new ApiScope("Meeting_read", "Meeting API için okuma yetkisi"),         
          new ApiScope("Gateway_fullpermission","Gateway API için Full Erişim"),
          new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {

                new Client
                {

                    ClientName ="Admin",
                    ClientId = "AdminAlpata",
                    AllowOfflineAccess =true,
                    ClientSecrets ={ new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    { "Meeting_fullpermission",
                        "Gateway_fullpermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,"roles"
                    },
                    AccessTokenLifetime =1*60*60,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60) - DateTime.Now)
                    .TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse
                },

                 new Client
                {

                    ClientName ="User",
                    ClientId = "UserAlpata",
                    AllowOfflineAccess =true,
                    ClientSecrets ={ new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    { "Meeting_read",
                         "Gateway_fullpermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,"roles"
                    },
                    AccessTokenLifetime =1*60*60,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60) - DateTime.Now)
                    .TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse
                }

            };
    }
}