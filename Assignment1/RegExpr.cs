using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {

        static void Main(string[] args)
        {
        }
        
       public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            string strRegex = "[^a-zA-Z0-9]";
            foreach (string s in lines) {
                foreach (var match in Regex.Split(s, strRegex))
                {
                    yield return match;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            string pattern = @"(?<firstYear>\d+)([x])(?<secondYear>\d+)";

            foreach (Match match in Regex.Matches(resolutions, pattern))
            {
                yield return (Int32.Parse(match.Groups["firstYear"].Value), Int32.Parse(match.Groups["secondYear"].Value));
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            string pattern = @$"<{tag}.*?>(.*?)<\/{tag}>*";

            string removesOtherTags = @"<\/?[a-z]{0,10}>";

            foreach (Match match in Regex.Matches(html, pattern))
            {
                yield return Regex.Replace(match.Groups[1].Value, removesOtherTags, "").Trim();
            }
        }
    }
}
