using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using NABD.Areas.Identity;
using NABD.Data; 
using NABD.Models.Domain;
using System.Security.Policy;

public class AccountsController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IEmailSender _emailSender;
    private readonly ApplicationDbContext _context;

    public AccountsController(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              IEmailSender emailSender,
                              ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
        _context = context;
    }

    [HttpPost("register-user")]
    public async Task<IActionResult> Register([FromBody] NABD.Areas.InputModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FullName = model.FullName,
            Gender = model.Gender,
            DateOfBirth = model.DateOfBirth,
            NationalId = model.NationalId,
            PhoneNumber = model.PhoneNumber,
            UserType = model.UserType,
            Specialty = model.UserType.ToLower() == "doctor" ? model.Specialty : null
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            // Save to Doctor or Patient table
            if (user.UserType.ToLower() == "doctor")
            {
                var doctor = new Doctor
                {
                    SSN = user.NationalId,
                    Name = user.FullName,
                    Email = user.Email,
                    Role = "Doctor",
                    Specialization = user.Specialty ?? "General"
                };

                _context.Doctors.Add(doctor);
            }
            else if (user.UserType.ToLower() == "patient")
            {
                var patient = new Patient
                {
                    SSN = user.NationalId,
                    Name = user.FullName,
                    BirthDate = user.DateOfBirth,
                    Gender = user.Gender,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    ToolId = 2
                };

                _context.Patients.Add(patient);
            }

            await _context.SaveChangesAsync();

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Auth", new { userId = user.Id, token }, Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                $"Please confirm your account by clicking <a href='{confirmationLink}'>here</a>.");

            if (!_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(new { Message = "User registered and signed in successfully!" });
            }

            return Ok(new { Message = "User registered successfully. Please check your email to confirm your account." });
        }

        return BadRequest(result.Errors);
    }
}
