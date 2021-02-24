using System.Linq;
using GraphQLExample.Data.Context;
using GraphQLExample.Data.Entities;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQLExample.GraphQL.Query
{
    public class CaseQuery
    {
        [UseDbContext(typeof(DataContext))]
        [UseProjection]
        [UseFiltering]
        public IQueryable<Case> GetCase([ScopedService] DataContext dataContext)
        {
            return dataContext.Case;
        }
    }
}