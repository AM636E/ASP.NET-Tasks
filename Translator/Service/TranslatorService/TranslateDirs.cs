using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Translator.Service.TranslatorService
{
    public class TranslateDirs
    {
        public List<string> dirs { get; set; }

        public Dictionary<string, string> langs { get; set; }
    }
}