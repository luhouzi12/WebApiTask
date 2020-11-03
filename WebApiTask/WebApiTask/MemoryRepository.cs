using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTask
{
    public class MemoryRepository:IRepository
    {
        private readonly Dictionary<long, ToDoItem> _dic = new Dictionary<long, ToDoItem>();

        public MemoryRepository()
        {
            Init();
        }

        public async Task<ToDoItem> GetAsync(long id)
        {
            _dic.TryGetValue(id, out ToDoItem item);
            return item;
        }

        public async Task UpsertAsync(ToDoItem model)
        {
            _dic[model.Id] = model;
        }


        public async Task<List<ToDoItem>> QueryAsync(
            long id)
        {
            IEnumerable<ToDoItem> models = _dic.Values.ToList();
            models = models.Where(v => v.Id == id);
            return models.ToList();
        }

        public async Task<List<ToDoItem>> QueryAllAsync(
        )
        {
            IEnumerable<ToDoItem> models = _dic.Values.ToList();
            return models.ToList();
        }

       
        private void Init()
        {
            for (var i = 0; i < 2; i++)
            {
                var item = new ToDoItem()
                {
                    Id = i,
                    Name = $"test item {i}",
                    IsComplete = false,
                };
                _dic[item.Id] = item;
            }
        }


    }
}
