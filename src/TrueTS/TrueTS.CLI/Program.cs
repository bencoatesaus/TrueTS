using System;
using System.IO;

using TrueTS.Syntax.Text;
using TrueTS.Syntax.Parse;

namespace TrueTS.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilename = "/Users/bencoates/Documents/dev/ts-src/index.ts";

            // go ahead and grab tokens
            var lexer = new Lexer(File.ReadAllText(inputFilename));
            var tokenBag = lexer.Lex();

            tokenBag.PrintTokens();
        }
    }
}
