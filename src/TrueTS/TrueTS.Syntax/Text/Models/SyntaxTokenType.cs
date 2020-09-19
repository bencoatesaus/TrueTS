using System;

namespace TrueTS.Syntax.Text.Models
{
    public enum SyntaxTokenType
    {
        Semicolon,
        KwVar,
        KwConst,
        KwLet,
        KwIf,
        KwWhile,
        OpAssignment,
        OpCompareEq,
        OpCompareNe,
        OpCompareGt,
        OpCompareGe,
        OpCompareLt,
        OpCompareLe,
        OpIncrement,
        OpDecrement,
        OpIncrementAssign,
        OpDecrementAssign,
        OpMultiplyAssign,
        OpDivideAssign,
        OpCompareAnd,
        OpCompareOr,
        OpAdd,
        OpSubtract,
        OpMultiply,
        OpDivide,
        OpMod,
        OpShiftLeft,
        OpShiftRight,
        ControlBracketLeft,
        ControlBracketRight,
        LiteralNumber,
        LiteralString,
        Identifier
    }

    public static class SyntaxTokenTypeExtensions
    {
        public static bool IsOperator(this SyntaxTokenType token)
        {
            switch (token)
            {
                case SyntaxTokenType.OpAdd:
                case SyntaxTokenType.OpSubtract:
                case SyntaxTokenType.OpMod:
                case SyntaxTokenType.OpDivide:
                case SyntaxTokenType.OpMultiply:
                case SyntaxTokenType.OpCompareAnd:
                case SyntaxTokenType.OpCompareOr:
                case SyntaxTokenType.OpCompareLe:
                case SyntaxTokenType.OpCompareLt:
                case SyntaxTokenType.OpCompareGe:
                case SyntaxTokenType.OpCompareGt:
                case SyntaxTokenType.OpCompareEq:
                case SyntaxTokenType.OpCompareNe:
                case SyntaxTokenType.OpAssignment:
                case SyntaxTokenType.OpDecrementAssign:
                case SyntaxTokenType.OpShiftLeft:
                case SyntaxTokenType.OpShiftRight:
                    return true;

                default:
                    return false;
            }
        }
    }
}