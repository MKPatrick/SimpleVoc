namespace SimpleVoc.Domain.Shared.Kernel
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
