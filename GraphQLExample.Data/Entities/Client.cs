namespace GraphQLExample.Data.Entities
{
    public class Client : BaseEntity
    {
        public string FullName { get; private init; }

        public static Client Create(
            int id,
            string fullName)
        {
            return new()
            {
                Id = id,
                FullName = fullName
            };
        }
        
        public static Client Create(
            string fullName)
        {
            return new()
            {
                FullName = fullName
            };
        }
    }
}