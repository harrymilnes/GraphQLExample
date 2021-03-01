using System.ComponentModel.DataAnnotations;

namespace GraphQLExample.GraphQL.Mutations.Models
{
    public class ClientModel
    {
        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }
    }
}