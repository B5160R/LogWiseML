namespace DataProcessing.Application.Commands.Interfaces
{
    public interface IPrepForAnalysis<T>
    {
        Task<string> Prep(T dto);
    }
}