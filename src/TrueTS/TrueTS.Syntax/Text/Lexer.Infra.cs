using System;
using System.Collections.Generic;

using TrueTS.Syntax.Text.Extensions;

namespace TrueTS.Syntax.Text
{
    public partial class Lexer
    {
        public char Current => this.GetCharAt(this.Position);
        private int CurrentLine => this.GetLineFromPos(this.Position);

        private char GetCharAt(int offset)
        {
            if (offset < this.SourceText.Length)
            {
                return this.SourceText[offset];
            }
            return '\0'; // return EOF
        }

        private void ConsumeWhitespace()
        {
            while (this.Current.IsWhiteSpace())
                this.Position++;
        }

        private bool MoveNext(bool skipSpaces = true)
        {
            do
            {
                this.Position++;
            } while (this.Position < this.SourceText.Length && (skipSpaces && this.Current.IsWhiteSpace()));

            return this.Position < this.SourceText.Length;
        }

        private char PeekNext(int peekAheadAmt = 1)
        {
            return this.GetCharAt(this.Position + peekAheadAmt);
        }

        private bool CanMoveNext()
        {
            return this.Position + 1 < this.SourceText.Length;
        }

        private bool IsDone()
        {
            return this.Position >= this.SourceText.Length;
        }

        private IEnumerable<int> GetLinePositions(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                // if we encounter start of line or a line break
                if (i == 0 || c == '\n')
                {
                    yield return i;
                }
            }
        }

        private int GetLineFromPos(int position)
        {
            for (int lineIndex = 0; lineIndex < this.LinePositions.Length; lineIndex++)
            {
                if (this.LinePositions[lineIndex] >= position)
                    return lineIndex + 1;
            }
            return 1;
        }
    }
}
