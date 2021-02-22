namespace GraphQLExample.Data.Entities
{
    public class Representative : BaseEntity
    {
        public string FullName { get; private init; }

        public static Representative Create(
            int id,
            string fullName)
        {
            return new()
            {
                Id = id,
                FullName = fullName
            };
        }
    }
}