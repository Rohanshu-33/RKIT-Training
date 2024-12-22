using Microsoft.AspNetCore.Http.Features;
using WebApiApplication1.Models;

namespace WebApiApplication1.Data
{
    public class TodoRepository
    {
        private static List<TodoItem> items = new List<TodoItem>();
        private static int autoId = 1;

        public List<TodoItem> GetAllItems()
        {
            return items;
        }

        public TodoItem AddItem(TodoItem itm)
        {
            itm.Id = autoId++;
            itm.CreatedDate = DateTime.Now;
            items.Add(itm);
            return itm;
        }

        public bool DeleteItem(int id)
        {
            foreach (var itms in items)
            {
                Console.WriteLine(itms.Id);
            }

            TodoItem itm = items.FirstOrDefault(e => e.Id == id);
            if (itm != null)
            {
                items.Remove(itm);
                return true;
            }
            return false;
        }
    }
}
