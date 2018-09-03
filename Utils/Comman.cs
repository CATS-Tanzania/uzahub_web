using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Web.Security;
using System.IO;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
using System.Reflection;
using Microsoft.VisualBasic;
using System.Net;
using System.Net.Mail;

namespace Utils
{
    public static class Comman
    {
        public static void FillHours(DropDownList ddl)
        {
            for (int i = 0; i < 24; i++)
            {
                ddl.Items.Add(new ListItem((i < 10) ? ("0" + i.ToString()) : i.ToString(), (i < 10) ? ("0" + i.ToString()) : i.ToString()));
            }
            ddl.SelectedIndex = -1;
        }
        public static void FillMinutes(DropDownList ddl)
        {
            for (int i = 0; i < 60; i++)
            {
                ddl.Items.Add(new ListItem((i < 10) ? ("0" + i.ToString()) : i.ToString(), (i < 10) ? ("0" + i.ToString()) : i.ToString()));
            }
            ddl.SelectedIndex = -1;
        }
        public static void FillFuel(DropDownList ddl)
        {
            for (int i = 0; i < 1000; i++)
            {
                ddl.Items.Add(new ListItem((i < 10) ? ("0" + i.ToString()) : i.ToString(), (i < 10) ? ("0" + i.ToString()) : i.ToString()));
            }
            ddl.SelectedIndex = -1;
        }
        public static void FillFuelConditional(DropDownList ddl, int cnt)
        {
            for (int i = 0; i <= cnt; i++)
            {
                ddl.Items.Add(new ListItem((i < 10) ? ("0" + i.ToString()) : i.ToString(), (i < 10) ? ("0" + i.ToString()) : i.ToString()));
            }
            ddl.SelectedIndex = -1;
        }
        public static string GetDateFromString(string sDateText)
        {
            char chr;
            chr = Convert.ToChar("/");
            string[] arrDT;
            sDateText = sDateText.Replace(".", "/");
            arrDT = sDateText.Split(chr);
            return arrDT[0] + "/" + arrDT[1] + "/" + arrDT[2];
        }
        public static void InsertDefaultItem(DropDownList source, string defaultText, string defaultValue)
        {
            source.Items.Insert(0, new ListItem(defaultText, defaultValue));
        }
        public static string createFolder(string rootfolder, string subfolder, string fileName)
        {
            string pathString = "";
            pathString = System.IO.Path.Combine(rootfolder, subfolder);
            System.IO.Directory.CreateDirectory(pathString);
            pathString = System.IO.Path.Combine(pathString, fileName);
            return pathString;
        }
        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
        public static string GenerateFileName(string context)
        {
            return context + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff").ToString();
        }
    }
}
