using System;

namespace TrueTS.Syntax.Text.Models.Exceptions
{
    public class InvalidSyntaxTokenException : Exception
    {
        public InvalidSyntaxTokenException(int lineNum)
            : base($"Error on line {lineNum}: Unexpected token")
        {
        }

        public InvalidSyntaxTokenException(int lineNum, char token)
            : base($"Error on line {lineNum}: Unexpected token `{token}`")
        {
        }
    }
}
