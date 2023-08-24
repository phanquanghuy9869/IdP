using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles",
                "Your role(s)",
                new [] { "role" }),
            new IdentityResource("country", "Your country", new List<string> { "country" })
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("imagegalleryapi",
                "Image Gallery Api",
                new [] { "role", "country" })
            {
                Scopes = { "imagegalleryapi.read", "imagegalleryapi.write" }
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        { 
            new ApiScope("imagegalleryapi.read"),
            new ApiScope("imagegalleryapi.write")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
            {
                new Client()
                {
                    ClientName = "Image gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris =
                    {
                        "https://localhost:7184/signin-oidc"
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "imagegalleryapi.read",
                        "imagegalleryapi.write",
                        "country"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RequireConsent = true,
                    // add this so will redirect to idp's login page after single sign out
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7184/signout-callback-oidc"
                    },
                    // Include all claims in id token, not recommended because of heavier
                    //AlwaysIncludeUserClaimsInIdToken = true,
                },
                //new Client()
                //{
                //    ClientName = "Image api",
                //    ClientId = "imagegalleryclient",
                //    AllowedGrantTypes = GrantTypes.Code,
                //    RedirectUris =
                //    {
                //        "https://localhost:7184/signin-oidc"
                //    },
                //    AllowedScopes = {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile
                //    },
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    RequireConsent = true
                //}
            };
}