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
    }
}
