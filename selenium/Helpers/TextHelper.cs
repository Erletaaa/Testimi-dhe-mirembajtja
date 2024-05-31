using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gjirafa50SeleniumWebProject.Helpers
{
    public static class TextHelper
    {
        public static string CleanUpQuotes(string text)
        {
            return text.Replace("\"", "");
        }
    }
}
