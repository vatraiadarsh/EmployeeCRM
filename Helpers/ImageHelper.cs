using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adarsh.EmployeeCRM.Web.Helpers
{
    public class ImageHelper
    {
        public static bool IsValidFile(string type)
        {
            switch (type)
            {
                case "image/jpeg":
                case "image/png":
                case "image/jpg":
                case "image/gif":
                    return true;

            }
            return false;
        }

        public static string GetFileExtension(string type)
        {
            switch (type)
            {
                case "image/jpeg":
                case "image/jpg":
                    return "jpg";
                case "image/png":
                    return "png";
                case "image/gif":
                    return "gif";
                
                    

            }
            return null;
        }

    }
}