using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EmailService
{
    public interface IEmailService
    {
        Task SendEmail(EmailDto request, List<string> recipents);
    }
}
