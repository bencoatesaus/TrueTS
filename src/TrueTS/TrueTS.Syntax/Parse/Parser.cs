using System;
using System.Collections.Generic;

using TrueTS.Syntax.Text.Models;
using TrueTS.Syntax.Parse.Models;

namespace TrueTS.Syntax.Parse
{
    public class Parser
    {
        private readonly SyntaxTokenBag TokenBag;

        public Parser(SyntaxTokenBag tokenBag)
        {
            this.TokenBag = tokenBag;
        }

        private void ParseExpression()
        {

        }

        public IEnumerable<Node> Parse()
        {
            this.ParseExpression();

            return new Node[] { };
        }
    }
}
