using System.Threading.Tasks;

namespace DataCollection.Application.Queries.Interfaces
{
    public interface IGetAllQuery<T>
    {
        T LogGetAll();
    }
}