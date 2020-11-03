using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiTask
{
    public interface IRepository
    {
        Task<ToDoItem> GetAsync(long id);

        Task<List<ToDoItem>> QueryAsync(long id);
        Task<List<ToDoItem>> QueryAllAsync();
        Task UpsertAsync(ToDoItem model);
    }
}