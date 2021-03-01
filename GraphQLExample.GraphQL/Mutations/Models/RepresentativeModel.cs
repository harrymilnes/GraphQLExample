using System.ComponentModel.DataAnnotations;

namespace GraphQLExample.GraphQL.Mutations.Models
{
    public class RepresentativeModel
    {
        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }
    }
}