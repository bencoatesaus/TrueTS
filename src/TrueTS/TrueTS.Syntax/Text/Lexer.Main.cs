using System;
using System.Linq;
using System.Collections.Generic;

using TrueTS.Syntax.Text.Extensions;
using TrueTS.Syntax.Text.Models;
using TrueTS.Syntax.Text.Models.Exceptions;

namespace TrueTS.Syntax.Text
{
    public partial class Lexer
    {
        private readonly string SourceText;
        private readonly int[] LinePositions;
        private int Position { get; set; }

        public int NumberOfLines => this.LinePositions.Length;


        public Lexer(string sourceText)
        {
            this.SourceText = sourceText;
            this.LinePositions = this.GetLinePositions(sourceText).ToArray();
            this.Position = 0;
        }

        public SyntaxTokenBag Lex()
        {
            return new SyntaxTokenBag(this.GetTokens());
        }

        public IEnumerable<SyntaxToken> GetTokens()
        {
            var tokens = new List<SyntaxToken>();
            while (!this.IsDone())
            {
                var token = this.NextToken();

                // we've hit the EOF, just go ahead and skip this
                // parse, IsDone() will now return true...
                if (token == null)
                    continue;

                if (token.IsValid())
                    yield return token;
            }
        }

        private SyntaxToken NextToken()
        {
            int pos = this.Position;

            switch (this.Current)
            {
                case '-':
                    this.MoveNext();
                    switch (this.Current)
                    {
                        case '-':
                            this.MoveNext();
                            return new SyntaxToken("--", pos, SyntaxTokenType.OpDecrement);
                        case '=':
                            this.MoveNext();
                            return new SyntaxToken("-=", pos, SyntaxTokenType.OpDecrementAssign);
                        default:
                            return new SyntaxToken("-", pos, SyntaxTokenType.OpSubtract);
                    }

                case '+':
                    this.MoveNext();
                    switch (this.Current)
                    {
                        case '+':
                            this.MoveNext();
                            return new SyntaxToken("++", pos, SyntaxTokenType.OpIncrement);
                        case '=':
                            this.MoveNext();
                            return new SyntaxToken("+=", pos, SyntaxTokenType.OpIncrementAssign);
                        default:
                            return new SyntaxToken("+", pos, SyntaxTokenType.OpAdd);
                    }

                case '*':
                    this.MoveNext();
                    switch (this.Current)
                    {
                        case '=':
                            this.MoveNext();
                            return new SyntaxToken("*=", pos, SyntaxTokenType.OpMultiplyAssign);
                        default:
                            return new SyntaxToken("*", pos, SyntaxTokenType.OpMultiply);
                    }

                case '/':
                    this.MoveNext();
                    switch (this.Current)
                    {
                        case '=':
                            this.MoveNext();
                            return new SyntaxToken("/=", pos, SyntaxTokenType.OpDivideAssign);
                        default:
                            return new SyntaxToken("/", pos, SyntaxTokenType.OpDivide);
                    }

                case '=':
                    this.MoveNext();
                    switch (this.Current)
                    {
                        case '=':
                            this.MoveNext();
                            return new SyntaxToken("==", pos, SyntaxTokenType.OpCompareEq);

                        default:
                            return new SyntaxToken("=", pos, SyntaxTokenType.OpAssignment);
                    }

                case ';':
                    this.MoveNext();
                    return new SyntaxToken(";", pos, SyntaxTokenType.Semicolon);

                default:
                    // check we may have an integer
                    if (this.Current.IsNumber())
                        return this.ReadNumber();
                    if (this.Current.IsLetter())
                        return this.ReadWord(); // identifiers, keywords, etc.

                    throw new InvalidSyntaxTokenException(this.CurrentLine, this.Current);
            }
        }

        private SyntaxToken ReadWord()
        {
            int pos = this.Position;
            string buffer = $"{this.Current}";
            while (this.MoveNext(false) && this.Current.IsAlphaNumeric())
                buffer += this.Current;

            this.ConsumeWhitespace(); // this will leave us with whitespace
                                      // that won't parse as a token, so just consume

            switch (buffer)
            {
                case "if": return new SyntaxToken(buffer, pos, SyntaxTokenType.KwIf);
                case "var": return new SyntaxToken(buffer, pos, SyntaxTokenType.KwVar);
                case "const": return new SyntaxToken(buffer, pos, SyntaxTokenType.KwConst);
                case "let": return new SyntaxToken(buffer, pos, SyntaxTokenType.KwLet);
                default: return new SyntaxToken(buffer, pos, SyntaxTokenType.Identifier);
            }
        }

        private SyntaxToken ReadNumber()
        {
            int pos = this.Position;
            string buffer = $"{this.Current}";
            while (this.MoveNext() && (this.Current.IsNumber() || this.Current == '.'))
                buffer += this.Current;

            // sanity check our output
            if (!decimal.TryParse(buffer, out decimal temp))
            {
                throw new InvalidSyntaxTokenException(this.CurrentLine);
            }
            return new SyntaxToken(buffer, pos, SyntaxTokenType.LiteralNumber);
        }
    }
}
