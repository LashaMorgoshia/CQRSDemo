using CQRSDemo.DB;
using MediatR;

namespace CQRSDemo.Queries
{
    public class GetTodoById
    {
        // Query / Command
        public record Query(int id): IRequest<Response>;

        // Handler
        public class Handler : IRequestHandler<Query, Response>
        {
            public readonly IRepo Repo;

            public Handler(IRepo repo)
            {
                Repo = repo;
            }

            public async Task<Response?> Handle(Query request, CancellationToken cancellationToken)
            {
                var todo = Repo.Todos().FirstOrDefault(x => x.Id == request.id);
                return todo != null ? new Response(todo.Id, todo.Name, todo.Completed) : null;
            }
        }

        // Response
        public record Response(int id, string name, bool completed);
    }
}
