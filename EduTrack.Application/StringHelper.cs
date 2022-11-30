using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Application
{
    public static class StringHelper
    {
        /// <summary>
        /// Apply Trim() and ToLower()
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ApplyTL(string str)
        {
            return str.Trim().ToLower();
        }
    }
}
