using System;

namespace GraphQLExample.Data.Entities
{
    public class Case : BaseEntity
    {
        public string Reference { get; private init; }
        public DateTime CreatedAt { get; private init; }
        public string Description { get; private init;}      
        public bool Resolved { get; private init; }

        public int RepresentativeId { get; private init; }
        public virtual Representative Representative { get; private init; }
        
        public int ClientId { get; private init; }
        public virtual Client Client { get; private init; }
        public static Case Create(
            int id,
            string reference,
            string description,
            bool resolved, 
            int representativeId, 
            int clientId)
        {
            return new()
            {
                Id = id,
                Reference = reference,
                CreatedAt = DateTime.UtcNow,
                Description = description,
                Resolved = resolved,
                RepresentativeId = representativeId,
                ClientId = clientId
            };
        }
    }
}