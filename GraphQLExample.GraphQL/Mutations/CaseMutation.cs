using System.Threading.Tasks;
using GraphQLExample.Data.Context;
using GraphQLExample.Data.Entities;
using GraphQLExample.GraphQL.Mutations.Models;
using GraphQLExample.GraphQL.Subscriptions;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace GraphQLExample.GraphQL.Mutations
{
    public class CaseMutation
    {
        [UseDbContext(typeof(DataContext))]
        public async Task<Case> CreateCaseAsync(
            CreateCaseModel createCaseModel, 
            [ScopedService] DataContext dataContext,
            [Service] ITopicEventSender topicEventSender)
        {
            var representativeEntity = Representative.Create(createCaseModel.Representative.FullName);
            var clientEntity = Client.Create(createCaseModel.Client.FullName);
            
            var caseEntity = Case.Create(
                createCaseModel.Reference, 
                createCaseModel.Description,
                representativeEntity,
                clientEntity
            );

            var addedEntity = await dataContext.Case.AddAsync(caseEntity);
            await dataContext.SaveChangesAsync();

            var persistedCase = addedEntity.Entity;
            await topicEventSender.SendAsync(nameof(CaseSubscription.CaseCreatedSubscription), persistedCase);
            return persistedCase;
        }
    }
}