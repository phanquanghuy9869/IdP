﻿using Microsoft.AspNetCore.Authorization;

namespace ImageGallery.Authorization
{
    public static class AuthorizationPolicies
    {
        public static AuthorizationPolicy CanAddImage()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("country", "usa")
                .RequireRole("PayingUser")
                .Build();
        }
    }
}