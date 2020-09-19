using System;
using System.Linq;
using System.Collections.Generic;

namespace TrueTS.Syntax.Text.Models
{
    public class SyntaxTokenBag
    {
        private int Position { get; set; }
        private readonly SyntaxToken[] Tokens;

        public SyntaxToken Current => this.Tokens[this.Position];

        public SyntaxTokenBag(IEnumerable<SyntaxToken> tokens)
        {
            this.Tokens = tokens.ToArray();
            this.Position = 0;
        }

        public bool CanMoveNext()
        {
            return this.Position + 1 < this.Tokens.Length;
        }

        public SyntaxToken Next()
        {
            if (this.CanMoveNext())
                return this.Tokens[++this.Position];
            return null;
        }

        public SyntaxToken Peek(int offset)
        {
            if (this.Position + offset < this.Tokens.Length)
                return this.Tokens[this.Position + offset];
            return null;
        }

        public void PrintTokens()
        {
            foreach(var token in this.Tokens)
            {
                Console.WriteLine(token.ToString());
            }
        }
    }
}
