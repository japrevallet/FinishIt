using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinishIt.Services
{
    public class NullEmailService : IEmailService
    {
        private readonly ILogger<NullEmailService> _logger;

        public NullEmailService(ILogger<NullEmailService> logger)
        {
            _logger = logger;
        }


        public void SendMessage(string to, string subject, string body)
        {
            _logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}
