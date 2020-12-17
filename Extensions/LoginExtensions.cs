using System;
using System.Runtime.CompilerServices;
using System.Net.Mime;
using System.Threading.Tasks;
using password_manager.Entities;

namespace password_manager.Extensions
{
    public static class LoginExtensions
    {
        public static void CopyToClipboard(this Login login)
        {
            var data = $"{login.UserName} -- {login.Password}";

            TextCopy.ClipboardService.SetText(data);
        }
    }
}