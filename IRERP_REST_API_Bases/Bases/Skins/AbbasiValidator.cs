using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MsdLib.ExtensionFuncs.PersianDateTime;

using System.Net;

namespace IRERP_RestAPI.Bases.Skins
{
   public class AbbasiValidator
    {
    public static   bool IpAddressValidator(string ip)
       {
           IPAddress temp;
           Regex regex = new Regex(@"\b(?:\d{1,3}\.){3}\d{1,3}\b");
           Match match = regex.Match(ip.Trim());
           if (match.Success)
           {


               if (IPAddress.TryParse(ip.Trim(), out temp))
                   return true;
               else

                   return false;
           }
           else
               return false;
       
       }

    public static bool EmailValidator(string email)
       {
           Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
           Match match = regex.Match(email.Trim());
           if (match.Success)
               return true;
           else
               return false;
        
       }


    public static bool NatinalCodeValidator(string NatinalCode)
    {
        Regex regex = new Regex(@"^\d{3}-\d{6}-\d{1}$");
        Match match = regex.Match(NatinalCode.Trim());
        if (match.Success)
            return true;
        else
            return false;
    }

    public static bool KhorshidyDate(string KhorshidyDate)
    {
        
        Regex regex = new Regex(@"^\d{4}/\d{2}/\d{2}$");
        Match match = regex.Match(KhorshidyDate.Trim());
        if (match.Success)
        {
            if(KhorshidyDate.Trim().IsPersianDateTime())
            return true;
            else
                return false;
        }
        else
            return false;
    }
    public static bool CallNumber(string CallNumber)
    {

        Regex regex = new Regex(@"^\d+$");
        Match match = regex.Match(CallNumber.Trim());
        if (match.Success)
        {

            return true;
        }
        else
            return false;
    }
    public static bool PostalCode(string PostalCode)
    {

        Regex regex = new Regex(@"^\d{5}-\d{5}$");
        Match match = regex.Match(PostalCode.Trim());
        if (match.Success)
        {

            return true;
        }
        else
            return false;
    }
    public static bool BirthCertificateNumber(string BirthCertificateNumber)
    {

        Regex regex = new Regex(@"^\d+");
        Match match = regex.Match(BirthCertificateNumber.Trim());
        if (match.Success)
        {

            return true;
        }
        else
            return false;
    }
    public static bool BirthCertificateSerial(string BirthCertificateSerial)
    {

        Regex regex = new Regex(@"^\d+\D+\d+$");
        Match match = regex.Match(BirthCertificateSerial.Trim());
        if (match.Success)
        {

            return true;
        }
        else
            return false;
    }
    public static bool FloatValidator(string FloatNumberAsString )
    {
      float temp;
      bool result=  float.TryParse(FloatNumberAsString, out temp);
      return result;
    }
    public static bool mobile(string MobileNumber)
    {

        Regex regex = new Regex(@"^0{1}[1-9]{1}\d{9}$");
        Match match = regex.Match(MobileNumber.Trim());
        if (match.Success)
        {
     return true;

        }
        else
            return false;
    }
    public static bool IsHour(string Hour)
    {

        Regex regex = new Regex(@"^\d\d:\d\d$");
        Match match = regex.Match(Hour.Trim());
        if (match.Success)
        {
            return true;

        }
        else
            return false;
    }
    public static bool IntField(string field)
    {
        int b=0;
        bool a = int.TryParse(field,out b);
       if (a)
        {
            return true;


        }
        else
            return false;
    }


    }
}
