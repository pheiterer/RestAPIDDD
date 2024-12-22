namespace RestAPIDDD.Infrastructure.Data.Interfaces
{
    public interface ISqlContext
    {
        void SetModified(object entity);
    }
}
