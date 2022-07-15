using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        static string deyer=null;
        public static  string Added
        {
            get
            {
                return $"{deyer} Added";
            }
            set
            {
                deyer=value;
            }
        }
        public static string Get
        {
            get
            {
                return $"{deyer} Received";
            }
            set
            {
                deyer = value;
            }
        }
        public static string Updated
        {
            get
            {
                return $"{deyer} Updated";
            }
            set
            {
                deyer = value;
            }
        }
        public static string Deleted
        {
            get
            {
                return $"{deyer} Deleted";
            }
            set
            {
                deyer = value;
            }
        }
    }
}
