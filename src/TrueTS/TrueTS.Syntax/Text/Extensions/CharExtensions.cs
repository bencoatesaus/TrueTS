using System;

namespace TrueTS.Syntax.Text.Extensions
{
    public static class CharExtensions
    {
        public static bool IsNumber(this char c)
        {
            switch (c)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsEOF(this char c)
        {
            return c == '\0';
        }

        public static bool IsOperator(this char c)
        {
            return c == '+' ||
                c == '-' ||
                c == '*' ||
                c == '%' ||
                c == '~' ||
                c == '/' ||
                c == '>' ||
                c == '<' ||
                c == '=' ||
                c == '!' ||
                c == '^' ||
                c == '&' ||
                c == '|';
        }

        public static bool IsLetter(this char c)
        {
            return char.IsLetter(c);
        }

        public static bool IsAlphaNumeric(this char c)
        {
            return char.IsLetterOrDigit(c);
        }

        public static bool IsQuote(this char c)
        {
            return c == '\'' || c == '"';
        }

        public static bool IsDelimiter(this char c)
        {
            if (c.IsOperator())
                return true;
            
            switch (c)
            {
                case ':':
                case ';':
                case ' ':
                case '{':
                case '}':
                case '(':
                case ')':
                case '\n':
                case '\r':
                case '.':
                case ',':
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsWhiteSpace(this char c)
        {
            return char.IsWhiteSpace(c);
        }
    }
}
