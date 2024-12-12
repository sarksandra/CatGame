﻿using Cat.Core.Dto;
using Cat.Core.ServiceInterFace;
using Cat.Models.Emails;
using Microsoft.AspNetCore.Mvc;

namespace Cat.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailsServices _emailsServices;

        public EmailController(IEmailsServices emailsServices)
        {
            _emailsServices = emailsServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel viewModel)
        {
            var dto = new EmailDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
            };
            _emailsServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult SendTokenEmail(EmailViewModel viewModel, string token)
        {
            var dto = new EmailTokenDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
                Token = token
            };
            _emailsServices.SendEmailToken(dto, token);
            return RedirectToAction(nameof(Index));

        }
    }
}
