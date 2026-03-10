// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace ECommerce.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("CatalogResource"){ Scopes={"CatalogFullPermission","CatalogReadPermission"}},

            new ApiResource("OrderResource"){Scopes={"OrderFullPermission"}}


        };




        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CatalogFullPermission","Full Authorization For Catalog Operations"),
                new ApiScope("CatalogReadPermission","Read Authorization For Catalog Operations"),
                 new ApiScope("OrderFullPermission","Full Authorization For Order Operations"),
                 new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //Visitor 
                new Client
                {
                    ClientId= "ECommerceVisitorId",
                    ClientName= "ECommerce Visitor",
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    ClientSecrets= {new Secret("ecommercesecret".Sha256())},
                    AllowedScopes= { "CatalogReadPermission",
                    IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.LocalApi.ScopeName}
                },

                //Admin
                new Client
                {
                    ClientId ="ECommerceAdminId",
                    ClientName= "ECommerce Admin",
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    ClientSecrets= {new Secret("ecommercesecret".Sha256()) },
                    AllowedScopes=
                    {
                        "CatalogFullPermission",
                        "OrderFullPermission",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.LocalApi.ScopeName
                    },
                    AccessTokenLifetime= 600,
                    
                    
                    
                    
                }
            };
    }
}