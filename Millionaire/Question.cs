using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millionaire
{
    public class Question
    {
        public string Text { get; set; }
        public List<String> Variants { get; set; }
        public int Right { get; set; }
    }
}