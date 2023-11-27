using ASPN.Models;

namespace ASPN.Services
{
    public class Storage
    {
        public List<ItemModel> Items { get; set; }
        public Storage()
        {
            Items = new List<ItemModel>();

            Items.Add(new ItemModel { Id = 1, Name = "WorkItem", Description = "Item for testing", AddTime = DateTime.Now });
            Items.Add(new ItemModel { Id = 2, Name = "SuperItem", Description = "Item Make God Things", AddTime = DateTime.Now });
        }
    }
}
