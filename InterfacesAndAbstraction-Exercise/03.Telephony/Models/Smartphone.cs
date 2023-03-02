using _03.Telephony.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony.Models;

public class Smartphone : ICall, IBrowse
{
    public string Call(string phoneNumber)
    {
        if (!ValidatePhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Calling... {phoneNumber}";
    }


    public string Url(string url)
    {
        if (!ValidateUrl(url))
        {
            throw new ArgumentException("Invalid URL!");
        }

        return $"Browsing: {url}!";
    }

    private bool ValidateUrl(string url) => url.All(c => !char.IsDigit(c));

    private bool ValidatePhoneNumber(string phoneNumber) => phoneNumber.All(c => char.IsDigit(c));
    
}
