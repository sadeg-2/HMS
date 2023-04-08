using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Services
{
    public interface IEmailService
    {
        Task Send(string to, string subject, string body);
    }
}
