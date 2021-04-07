using System.Linq.Expressions;

namespace RealGoodApps.Mocksanity
{
    internal class MocksaneExpression
    {
        private MocksaneExpression()
        {
        }

        public int ParameterCount => 0;

        internal static MocksaneExpression Evaluate(Expression expression)
        {
            // TODO: Do something.
            return new MocksaneExpression();
        }
    }
}
