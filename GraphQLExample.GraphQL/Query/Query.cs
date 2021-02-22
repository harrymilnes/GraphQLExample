using System.Linq;
using GraphQLExample.Data.Context;
using GraphQLExample.Data.Entities;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQLExample.GraphQL.Query
{
    public class Query
    {
        [UseDbContext(typeof(DataContext))]
        [UseProjection]
        public IQueryable<Case> GetCase([ScopedService] DataContext dataContext)
        {
            return dataContext.Case;
        }
    }
}