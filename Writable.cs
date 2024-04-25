using System;
using System.Collections.Generic;

namespace BaseProject
{
    internal static class Writable
    {
        internal static object GetWritableValue(string value)
        {
            if(value == "True") return "true";
            if(value == "False") return "false";
            return value.Replace(";", "&qt$").Replace(" ", "&spc$");
        }

        internal static object GetOriginalFromWritable(string value)
        {
            if (value == "true") return true;
            if (value == "false") return false;
            return value.Replace("&qt$", ";").Replace("&spc$", " ");
        }
    }
}
