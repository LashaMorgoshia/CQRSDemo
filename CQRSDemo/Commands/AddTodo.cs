using CQRSDemo.DB;
using MediatR;

namespace CQRSDemo.Commands
{
    public static class AddTodo
    {
        // command
        public record Command(int id, string name): IRequest<int>;

        // handler
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly IRepo _repo;

            public Handler(IRepo repo)
            {
                _repo = repo;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                _repo.Add(new Domain.Todo() { Id = request.id, Name = request.name });
                return request.id;
            }
        }
    }
}
