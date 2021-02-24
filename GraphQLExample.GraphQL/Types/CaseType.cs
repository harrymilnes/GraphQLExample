using GraphQLExample.Data.Entities;
using HotChocolate.Types;

namespace GraphQLExample.GraphQL.Types
{
    public class CaseType : ObjectType<Case>
    {
        protected override void Configure(IObjectTypeDescriptor<Case> descriptor)
        {
            descriptor.Description("Legal cases within the system");

            descriptor
                .Field(field => field.Reference)
                .Ignore();

            descriptor
                .Field(field => field.Resolved)
                .Description("Whether or not the case has been resolved");
 
            descriptor
                .Field(field => field.CreatedAt)
                .Description("When the case was initially created");
            
            descriptor
                .Field(field => field.Description)
                .Description("Description regarding the case");
            
            descriptor
                .Field(field => field.RepresentativeId)
                .Description("Id of the representative representing the case");
            
            descriptor
                .Field(field => field.Representative)
                .Description("The representative representing the case");
            
            descriptor
                .Field(field => field.ClientId)
                .Description("Id of the client the case is about");
            
            descriptor
                .Field(field => field.Client)
                .Description("The client the case is about");
            
            descriptor
                .Field(field => field.Id)
                .Description("Id of the case");
        }
    }
}