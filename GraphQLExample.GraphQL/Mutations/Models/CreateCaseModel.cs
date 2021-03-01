using System.ComponentModel.DataAnnotations;

namespace GraphQLExample.GraphQL.Mutations.Models
{
    public class CreateCaseModel
    {
        [Required]
        public string Reference { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public ClientModel Client { get; set; }
        
        [Required]
        public RepresentativeModel Representative { get; set; }
    }
}