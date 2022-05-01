using CQRSDemo.Domain;

namespace CQRSDemo.DB
{
    public class Repo: IRepo
    {
        public List<Todo> Todos() => this.TodoList;

        public void Add(Todo todo)
        {
            this.TodoList.Add(todo);
        }

        public List<Todo> TodoList { get; } = new List<Todo>
        {
            new Todo{Id = 1, Name = "Watch CQRS tutorial", Completed = false},
            new Todo{Id = 2, Name = "Create sample project", Completed = true},
            new Todo{Id = 3, Name = "Go to offroad", Completed = false},
            new Todo{Id = 4, Name = "Go to gym", Completed = true},
            new Todo{Id = 5, Name = "Take a walk", Completed = false},
        };
    }
}
