namespace Siteware.Domain.Entities.Base
{
    public abstract class Entity
    {
        protected Entity(int id)
        {
            Id = id;
        }

        protected Entity()
        {
        }

        public int Id { get; set; }
    }
}
