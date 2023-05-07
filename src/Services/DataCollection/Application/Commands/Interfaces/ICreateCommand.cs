using System.Threading.Tasks;

namespace DataCollection.Application.Commands.Interfaces
{
    public interface ICreateCommand<T>
    {
        void Create(T dto);
    }
}