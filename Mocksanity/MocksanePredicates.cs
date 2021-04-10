using System;
using System.Linq.Expressions;

namespace RealGoodApps.Mocksanity
{
    /// <summary>
    /// Mocksane predicates are used when generating smart predicates for mock matches.
    /// The implementations here are not actually used by the framework.
    /// Instead, they purely exist to ensure the return type of the expression matches
    /// the parameter (aka TParameter).
    /// </summary>
    public static class MocksanePredicates
    {
        private static readonly NotSupportedException IncorrectUsageException =
            new NotSupportedException("You must be using these predicates from your setup expression.");

        public static TParameter Any<TParameter>()
        {
            throw IncorrectUsageException;
        }

        public static TParameter Matches<TParameter>(Func<TParameter, bool> matchPredicate)
        {
            throw IncorrectUsageException;
        }
    }
}
