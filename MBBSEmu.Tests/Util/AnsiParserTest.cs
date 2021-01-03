using MBBSEmu.Util;
using FluentAssertions;
using System.Text;
using Xunit;

namespace MBBSEmu.Tests.Util
{
  public class AnsiParserTest
  {
    /*
    private static String createBoldColor(AnsiColor foreground, AnsiColor background) {
      return String.format("\u001B[1;%d;%dm", 40 + background.ordinal(), 30 + foreground.ordinal());
    }
    */

    [Theory]
    [InlineData("", "")]
    [InlineData("This is really cool.\r\nYep", "This is really cool.\r\nYep")]
    [InlineData("\u001B[30;31;32;40;4;41;45m", "")]
    [InlineData("\u001B[K\u001B[2J\u001B[4;5H\u001B[=55h\u001B[=56l", "")]
    [InlineData("\u001B[1;40;30mThis is a \u001B[1;41;31mtest", "This is a test")]
    // YO + colors
    public void ParseAnsiTest(string src, string expected)
    {
      var toPrint = new AnsiParser().ParseAnsiString(Encoding.ASCII.GetBytes(src));
      Encoding.ASCII.GetString(toPrint).Should().BeEquivalentTo(expected);
    }
  }
}
