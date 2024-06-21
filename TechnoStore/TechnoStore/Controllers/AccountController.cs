using Business.Enums;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using TechnoStore.ViewModels;

namespace TechnoStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterVm memberRegisterVm)
        {
            if (!ModelState.IsValid)
                return View();



           var appUser = await _userManager.FindByEmailAsync(memberRegisterVm.Email);

            if (appUser != null)
            {
                ModelState.AddModelError("Email", "Email already exist");
                return View();
            }

            appUser = new()
            {
                Name = memberRegisterVm.Name,
                Surname = memberRegisterVm.Surname,
                UserName = memberRegisterVm.Email,
                Email = memberRegisterVm.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, memberRegisterVm.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(memberRegisterVm);
            }

            await _userManager.AddToRoleAsync(appUser, RoleEnum.Member.ToString());

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var url = Url.Action(nameof(VerifyEmail), "Account", new
            {
                email = appUser.Email,
                token
            }, Request.Scheme, Request.Host.ToString());
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("memmedovfuad75@gmail.com", "TechnoStore");
            mailMessage.To.Add(new MailAddress(appUser.Email));
            mailMessage.Subject = "Verify Email";
            string body = string.Empty;

            using (StreamReader streamReader = new StreamReader("wwwroot/template/htmlpage.html"))
            {
                body = streamReader.ReadToEnd();
            };

            mailMessage.Body = body.Replace("{{link}}", url);
            
               
          
            
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("memmedovfuad75@gmail.com", "ibcxodjvmxfoilhu");
            smtpClient.Send(mailMessage);



            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> VerifyEmail(string email,string token)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);


            if (email == null)
                return NotFound();


            await _userManager.ConfirmEmailAsync(appUser, token);
            await _signInManager.SignInAsync(appUser,true);

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginVm memberLoginVm, string? ReturnUrl)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser user = await _userManager.FindByEmailAsync(memberLoginVm.Email);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(memberLoginVm.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Email or password is wrong!");
                    return View(memberLoginVm);
                }
            }

            var result = await _signInManager.PasswordSignInAsync(user, memberLoginVm.Password, memberLoginVm.RememberMe, true);

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("Verify", "Waiting for confirm");
                return View();
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account is blocked!");
                return View(memberLoginVm);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(memberLoginVm);
            }

            await _signInManager.SignInAsync(user, memberLoginVm.RememberMe);

            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var item in roles)
            {
                if (item == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(RoleEnum)))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
            }

            return Content("Roles created!");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVm forgetPasswordVm)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(forgetPasswordVm.appUser.Email);
            
            if(appUser == null)
            {
                ModelState.AddModelError("Error", "Bele bir email yoxdur");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            var link = Url.Action(nameof(ResetPassword), "Account", new
            {
                email = appUser.Email,
                token
            }, Request.Scheme, Request.Host.ToString());

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("memmedovfuad75@gmail.com", "TechnoStore");
            mailMessage.To.Add(new MailAddress(appUser.Email));
            mailMessage.Subject = "Reset Password";
            mailMessage.Body = $"< a href={link}>Please click Here</a>";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("memmedovfuad75@gmail.com", "ibcxodjvmxfoilhu");
            smtpClient.Send(mailMessage);


            return RedirectToAction("index","home");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string token,string email,ForgetPasswordVm forgetPasswordVm)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);

            if(appUser == null)
            return BadRequest();

            if (!ModelState.IsValid)
                return View();

            await _userManager.ResetPasswordAsync(appUser, token, forgetPasswordVm.Password);


            return RedirectToAction("Login");
        }


    }
}
