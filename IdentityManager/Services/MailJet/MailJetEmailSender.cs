using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.Services.MailJet
{
    public class MailJetEmailSender : IEmailSender
    {
        private readonly MailJetOptions _mailJetOptions;

        public MailJetEmailSender(IConfiguration configuration)
        {
            _mailJetOptions = configuration.GetSection("MailJet").Get<MailJetOptions>();
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey);
            var request = new MailjetRequest
            {
                Resource = Send.Resource
            };

            // TODO: add email configs, like subject, body, etc

            await client.PostAsync(request)
        }
    }
}
