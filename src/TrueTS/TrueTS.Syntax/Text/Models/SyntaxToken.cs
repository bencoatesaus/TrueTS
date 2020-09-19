using System;

using TrueTS.Syntax.Text.Extensions;

namespace TrueTS.Syntax.Text.Models
{
    public class SyntaxToken
    {
        public readonly string Text;
        public readonly int Position;
        public readonly SyntaxTokenType TokenType;

        public SyntaxToken(string text, int position, SyntaxTokenType tokenType)
        {
            this.Text = text;
            this.Position = position;
            this.TokenType = tokenType;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Text);
        }

        public override string ToString()
        {
            return $"[{this.TokenType, 15}]:\t{this.Text}";
        }
    }
}
