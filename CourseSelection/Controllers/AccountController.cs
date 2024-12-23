﻿using CourseSelection.Models;
using CourseSelection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CourseSelection.Controllers
{
    [Controller]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Login
        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }

        // POST: Login
        [HttpPost("LoginUser")]

        public async Task<ActionResult> LoginUser(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == model.Username && u.PasswordHash == model.PasswordHash && u.Role == model.Role);

                if (user != null)
                {
                    // Kullanıcı başarıyla giriş yaptı
                    if (user.Role == "Student")
                    {
                        return RedirectToAction("Index", "Student", new { id = user.RelatedID });
                    }
                    else if (user.Role == "Advisor")
                    {
                        return RedirectToAction("Index", "Advisors", new { id = user.RelatedID });
                    }
                }
                else
                {
                    ViewBag.Message = "Invalid username, password, or role.";
                }
            }
            return View(model);
        }

        // GET: ForgotPassword
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: ForgotPassword
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user != null)
                {
                    // Şifre sıfırlama işlemini başlat
                    // Örnek: Kullanıcıya şifre sıfırlama bağlantısı gönderme
                    string resetLink = Url.Action("ResetPassword", "Account", new { email = model.Email }, Request.Scheme);

                    

                    ViewBag.Message = "A password reset link has been sent to your email.";
                }
                else
                {
                    ViewBag.Message = "Email address not found.";
                }
            }

            return View(model);
        }
    }
}
