using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Weat.UI.Models;
using Weat.UI.Models.Transverse;
using System.Configuration;
using Newtonsoft.Json;

namespace Weat.UI
{
    //public class EmailService : IIdentityMessageService
    //{
    //    public Task SendAsync(IdentityMessage message)
    //    {
    //        // Indiquez votre service de messagerie ici pour envoyer un e-mail.
    //        return Task.FromResult(0);
    //    }
    //}

    //public class SmsService : IIdentityMessageService
    //{
    //    public Task SendAsync(IdentityMessage message)
    //    {
    //        // Connectez votre service SMS ici pour envoyer un message texte.
    //        return Task.FromResult(0);
    //    }
    //}

    // Configurer l'application que le gestionnaire des utilisateurs a utilisée dans cette application. UserManager est défini dans ASP.NET Identity et est utilisé par l'application.
    public class ApplicationUserManager : UserManager<WeatUser, int>
    {
        public ApplicationUserManager(IUserStore<WeatUser, int> store) : base(store)
        {
            this.UserLockoutEnabledByDefault = false;
            // this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);
            // this.MaxFailedAccessAttemptsBeforeLockout = 10;
            this.UserValidator = new CustomUserValidator<WeatUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            //this.EmailService=new EmailService();
            //this.MaxFailedAccessAttemptsBeforeLockout = int.Parse(ConfigurationManager.AppSettings[ApplicationKeys.SettingsKeys.MaxFailedAccessAttemptsBeforeLockout.ToString()]); ;
        }

        //public ApplicationUserManager(IUserStore<ApplicationUser> store)
        //    : base(store)
        //{
        //}

        //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        //{
        //    var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
        //    // Configure validation logic for usernames
        //    manager.UserValidator = new UserValidator<ApplicationUser>(manager)
        //    {
        //        AllowOnlyAlphanumericUserNames = false,
        //        RequireUniqueEmail = true
        //    };

        //    // Configure validation logic for passwords
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 6,
        //        RequireNonLetterOrDigit = true,
        //        RequireDigit = true,
        //        RequireLowercase = true,
        //        RequireUppercase = true,
        //    };

        //    // Configure user lockout defaults
        //    manager.UserLockoutEnabledByDefault = true;
        //    manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //    manager.MaxFailedAccessAttemptsBeforeLockout = 5;

        //    // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
        //    // You can write your own provider and plug it in here.
        //    manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
        //    {
        //        MessageFormat = "Your security code is {0}"
        //    });
        //    manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
        //    {
        //        Subject = "Security Code",
        //        BodyFormat = "Your security code is {0}"
        //    });
        //    manager.EmailService = new EmailService();
        //    manager.SmsService = new SmsService();
        //    var dataProtectionProvider = options.DataProtectionProvider;
        //    if (dataProtectionProvider != null)
        //    {
        //        manager.UserTokenProvider = 
        //            new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
        //    }
        //    return manager;
        //}
    }

    // Configurer le gestionnaire de connexion d'application qui est utilisé dans cette application.
    //public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    //{
    //    public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
    //        : base(userManager, authenticationManager)
    //    {
    //    }

    //    public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
    //    {
    //        return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
    //    }

    //    public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
    //    {
    //        return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
    //    }
    //}
    public enum WeatSignInStatus
    {
        Failure,
        IsBlocked,
        Inactive,
        PwdEexpired,
        PwdError,
        RequiresLegalNoticeValidation,
        Success,
        RequiresVerification
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<WeatUser, int>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }


        public async Task<Tuple<WeatSignInStatus, int>> WeatPasswordSignInAsync(string userName, string password)
        {
            if (UserManager == null)
            {
                return new Tuple<WeatSignInStatus, int>(WeatSignInStatus.Failure, 0);
            }
            var user = await UserManager.FindByNameAsync(userName);
            if (user == null)
            {
                return new Tuple<WeatSignInStatus, int>(WeatSignInStatus.Failure, 0);
            }
            if (user.IsActive == false)
            {
                return new Tuple<WeatSignInStatus, int>(WeatSignInStatus.Inactive, 0);
            }
            if (user.IsBlocked)
            {
                return new Tuple<WeatSignInStatus, int>(WeatSignInStatus.IsBlocked, 0);
            }
            var userManager = UserManager as ApplicationUserManager;
            if (await UserManager.CheckPasswordAsync(user, password))
            {
                //await userManager.ResetAccessFailedAsync(user.Id);
                return await SignInOrTwoFactor(user, false);
            }
            //if (await userManager.LogInAccessFailedAsync(user.Id))
            //{
            //    return new Tuple<WeatSignInStatus, int>(WeatSignInStatus.IsBlocked, 0);
            //}
            var nbTryPwdRest = 3;
            return new Tuple<WeatSignInStatus, int>(WeatSignInStatus.PwdError, nbTryPwdRest);
        }

        private async Task<Tuple<WeatSignInStatus, int>> SignInOrTwoFactor(WeatUser user, bool isPersistent)
        {
            var id = Convert.ToString(user.Id);
            await SignInAsync(user, isPersistent, false);
            //if (!user.IsActive && !string.IsNullOrEmpty(user.ActivationCode) && user.ActivationDate.HasValue)
            //    return new Tuple<WeatSignInStatus, int>(WeatSignInStatus.RequiresVerification, 0);
            return new Tuple<WeatSignInStatus, int>(WeatSignInStatus.Success, 0);
        }

        public override async Task SignInAsync(WeatUser user, bool isPersistent, bool rememberBrowser)
        {
            ClaimsIdentity userIdentity = await CreateUserIdentityAsync(user);
            // Clear any partial cookies from external or two factor partial sign ins
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie,
                DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = isPersistent,
                ExpiresUtc = new DateTime(DateTime.Now.Ticks + DateTime.Now.Ticks)
            }
                , userIdentity);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(WeatUser user)
        {
            var claims = new List<Claim>();

            // create *required* claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Mail));

            // serialized AppUserState object
            claims.Add(new Claim("UserState", JsonConvert.SerializeObject(user)));

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            return Task.FromResult(identity);
        }
    }

    //public class ApplicationRoleManager : RoleManager<ApplicationRole, int>
    //{
    //    public ApplicationRoleManager(IRoleStore<ApplicationRole, int> store) : base(store)
    //    {
    //        this.RoleValidator = new RoleValidator<ApplicationRole, int>(this);
    //    }
    //}

    public class CustomUserValidator<TUser, TKey> : IIdentityValidator<TUser>
        where TUser : class, IUser<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="manager"></param>
        public CustomUserValidator(UserManager<TUser, TKey> manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("manager");
            }
            AllowOnlyAlphanumericUserNames = true;
            Manager = manager;
        }

        /// <summary>
        ///     Only allow [A-Za-z0-9@_] in UserNames
        /// </summary>
        public bool AllowOnlyAlphanumericUserNames { get; set; }

        /// <summary>
        ///     If set, enforces that emails are non empty, valid, and unique
        /// </summary>
        public bool RequireUniqueEmail { get; set; }

        private UserManager<TUser, TKey> Manager { get; set; }

        /// <summary>
        ///     Validates a user before saving
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual IdentityResult Validate(TUser item)
        {
            //if (item == null)
            //{
            //    throw new ArgumentNullException("item");
            //}
            //var errors = new List<string>();
            //await ValidateUserName(item, errors);
            ////if (RequireUniqueEmail)
            ////{
            ////    await ValidateEmailAsync(item, errors);
            ////}
            //if (errors.Count > 0)
            //{
            //    return IdentityResult.Failed(errors.ToArray());
            //}
            return IdentityResult.Success;
        }
        public Task<IdentityResult> ValidateAsync(TUser item)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        //private async Task ValidateUserName(TUser user, List<string> errors)
        //{
        //    if (string.IsNullOrWhiteSpace(user.UserName))
        //    {
        //        errors.Add(Dds.Resources.Resources.Resource.UI_Account_Register_ERR_10004);
        //    }
        //    else if (AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, @"^[A-Za-z0-9@_\.]+$"))
        //    {
        //        // If any characters are not letters or digits, its an illegal user name
        //        errors.Add(Dds.Resources.Resources.Resource.UI_Account_Register_ERR_10005);
        //    }
        //    else
        //    {
        //        var owner = await Manager.FindByNameAsync(user.UserName);
        //        if (owner != null && !EqualityComparer<TKey>.Default.Equals(owner.Id, user.Id))
        //        {
        //            errors.Add(Dds.Resources.Resources.Resource.UI_Account_Register_ERR_10012);
        //        }
        //    }
        //}

        // make sure email is not empty, valid, and unique
        //private async Task ValidateEmailAsync(TUser user, List<string> errors)
        //{
        //    var email = await Manager.GetEmailStore().GetEmailAsync(user);
        //    if (string.IsNullOrWhiteSpace(email))
        //    {
        //        errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.PropertyTooShort, "Email"));
        //        return;
        //    }
        //    try
        //    {
        //        var m = new MailAddress(email);
        //    }
        //    catch (FormatException)
        //    {
        //        errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.InvalidEmail, email));
        //        return;
        //    }
        //    var owner = await Manager.FindByEmailAsync(email).WithCurrentCulture();
        //    if (owner != null && !EqualityComparer<TKey>.Default.Equals(owner.Id, user.Id))
        //    {
        //        errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.DuplicateEmail, email));
        //    }
        //}

    }
}
