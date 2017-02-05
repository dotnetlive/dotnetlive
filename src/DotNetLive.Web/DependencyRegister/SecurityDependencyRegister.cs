using DotNetLive.Framework.DependencyManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.Web.DependencyRegister
{
    public class SecurityDependencyRegister : IDependencyRegister
    {
        public void Register(IServiceCollection services, IHostingEnvironment hostingEnvironment)
        {
            services.AddScoped<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();

            services.Configure<IdentityOptions>(options =>
            {
                var dataProtectionPath = Path.Combine(@"d:\dotnetlive", "identity-artifacts");
                options.Cookies.ApplicationCookie.AuthenticationScheme = "ApplicationCookie";
                options.Cookies.ApplicationCookie.DataProtectionProvider = DataProtectionProvider.Create(dataProtectionPath);
                options.Cookies.ApplicationCookie.CookieDomain = "";
                options.Cookies.ApplicationCookie.CookieName = "dnl-auth";
                options.Cookies.ApplicationCookie.CookieHttpOnly = false;
                options.Lockout.AllowedForNewUsers = true;
                var applicationCookie = options.Cookies.ApplicationCookie;


                applicationCookie.Events = new CookieAuthenticationEvents();
            });

            // Services used by identity
            services.AddAuthentication(options =>
            {
                // This is the Default value for ExternalCookieAuthenticationScheme
                options.SignInScheme = new IdentityCookieOptions().ExternalCookieAuthenticationScheme;
            });

            services.TryAddScoped<IdentityMarkerService>();
            services.TryAddScoped<IUserValidator<ApplicationUser>, UserValidator<ApplicationUser>>();
            services.TryAddScoped<IPasswordValidator<ApplicationUser>, PasswordValidator<ApplicationUser>>();
            services.TryAddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
            services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.TryAddScoped<IdentityErrorDescriber>();
            services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<ApplicationUser>>();
            services.TryAddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserClaimsPrincipalFactory<ApplicationUser>>();
            services.TryAddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
            services.TryAddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();

            AddDefaultTokenProviders(services);
        }

        private void AddDefaultTokenProviders(IServiceCollection services)
        {
            var dataProtectionProviderType = typeof(DataProtectorTokenProvider<>).MakeGenericType(typeof(ApplicationUser));
            var phoneNumberProviderType = typeof(PhoneNumberTokenProvider<>).MakeGenericType(typeof(ApplicationUser));
            var emailTokenProviderType = typeof(EmailTokenProvider<>).MakeGenericType(typeof(ApplicationUser));
            AddTokenProvider(services, TokenOptions.DefaultProvider, dataProtectionProviderType);
            AddTokenProvider(services, TokenOptions.DefaultEmailProvider, emailTokenProviderType);
            AddTokenProvider(services, TokenOptions.DefaultPhoneProvider, phoneNumberProviderType);
        }

        private void AddTokenProvider(IServiceCollection services, string providerName, Type provider)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Tokens.ProviderMap[providerName] = new TokenProviderDescriptor(provider);
            });

            services.AddSingleton(provider);
        }
    }
}
