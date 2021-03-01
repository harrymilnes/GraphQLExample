using System.Threading.Tasks;
using GraphQLExample.Data.Context;
using GraphQLExample.Data.Entities;
using GraphQLExample.GraphQL.Mutations.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQLExample.GraphQL.Mutations
{
    public class CaseMutation
    {
        [UseDbContext(typeof(DataContext))]
        public async Task<Case> CreateCaseAsync(CreateCaseModel createCaseModel, [ScopedService] DataContext dataContext)
        {
            var representativeEntity = Representative.Create(createCaseModel.Representative.FullName);
            var clientEntity = Client.Create(createCaseModel.Client.FullName);
            
            var caseEntity = Case.Create(
                createCaseModel.Reference, 
                createCaseModel.Description,
                representativeEntity,
                clientEntity
            );

            await dataContext.Case.AddAsync(caseEntity);
            await dataContext.SaveChangesAsync();
            return caseEntity;
        }
    }
}