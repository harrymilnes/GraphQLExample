using GraphQLExample.Data.Entities;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQLExample.GraphQL.Subscriptions
{
    public class CaseSubscription
    {
        [Topic]
        [Subscribe]
        public Case CaseCreatedSubscription([EventMessage] Case createdCase)
        {
            return createdCase;
        }
    }
}