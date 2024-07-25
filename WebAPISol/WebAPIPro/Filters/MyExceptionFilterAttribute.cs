using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIPro.Filters
{
    public class MyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static String ErrorlineNo, Errormsg, extype, ErrorLocation;

        public static void SendErrorToText(Exception ex)
        {
            var line = Environment.NewLine + Environment.NewLine;

            ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            Errormsg = ex.Message.ToString();
            extype = ex.GetType().ToString();
            ErrorLocation = ex.GetType().Name.ToString();

            try
            {
                System.IO.Directory.GetCurrentDirectory();
                string filepath = Path.GetFullPath("ErrorLogFile/");  //Text File Path

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                filepath = filepath + "ErrorLog-" + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation + line + " Error Page Url:" + " " + line + "User Host IP:" + " " + line;
                    sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        public override void OnException(ExceptionContext context)
        {
            // Write Any Logics to Log the Issue and Handling Exception
            Exception ex = context.Exception;

            // Logging Exception into a Text File
            SendErrorToText(ex);

            context.Result = new ObjectResult("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!")
            {
                StatusCode = 400
            };
            context.ExceptionHandled = true;
        }
    }
}
