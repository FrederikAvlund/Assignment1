using Xunit;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void Resolution_takes_1404x2495_returns_1404_2495()
        {

            IEnumerable<(int width, int hight)> output = RegExpr.Resolution("1404x2495");

            Assert.Equal(new[] { (1404, 2495) }, output);
        }

        [Fact]
        public void Resolution_takes_string_with_spaces_and_nondigit_returns_touples_with_integers()
        {

            IEnumerable<(int width, int hight)> output = RegExpr.Resolution("1920x1080 \n 1024x768, 800x600, 640x480 \n 320x200, 320x240, 800x600 \n 1280x960");

            Assert.Equal(new[] { (1920, 1080), (1024, 768), (800, 600), (640, 480), (320, 200), (320, 240), (800, 600), (1280, 960) }, output);
        }

        [Fact]
        public void InnerText_takes_HTML_tag__with_innertext_helloWorld_and_returns_innerText()
        {
            IEnumerable<string> output = RegExpr.InnerText("<div> Hello World </div>", "div");

            Assert.Equal(new[] { "Hello World" }, output);
        }

        [Fact]
        public void InnerText_takes_html_tag__with_innertext_and_returns_innerText_by_tag_span()
        {
            IEnumerable<string> output = RegExpr.InnerText("<div> I am a div </div> \n <span> I am a span. </span> \n <input> I am an input </input> \n <span> I am also a span </span>", "span");

            Assert.Equal(new[] { "I am a span.", "I am also a span" }, output);
        }

        [Fact]
        public void InnerText_takes_html_returns_innertext_by_tag_a()
        {
            IEnumerable<string> output = RegExpr.InnerText("<div> \n <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href='/wiki/Theoretical_computer_science' title='Theoretical computer science'>theoretical computer science</a> and <a href='/wiki/Formal_language' title='Formal language'>formal language</a> theory, a sequence of <a href='/wiki/Character_(computing)' title='Character (computing)'>characters</a> that define a <i>search <a href='/wiki/Pattern_matching' title='Pattern matching'>pattern</a></i>. Usually this pattern is then used by <a href='/wiki/String_searching_algorithm' title='String searching algorithm'>string searching algorithms</a> for 'find' or 'find and replace' operations on <a href='/wiki/String_(computer_science)' title='String (computer science)'>strings</a>.</p> \n </div>", "a");

            Assert.Equal(new[] { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" }, output);
        }

        [Fact]
        public void InnerText_takes_html_returns_innertext_by_tag_p()
        {

            IEnumerable<string> output = RegExpr.InnerText("<div> \n <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>\n</div>", "p");

            Assert.Equal(new[] { "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." }, output);
        }

    }
}
