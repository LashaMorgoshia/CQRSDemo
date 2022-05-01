using CQRSDemo.Domain;

namespace CQRSDemo.DB
{
    public interface IRepo
    {
        List<Todo> Todos();
    }
}
