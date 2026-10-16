using LW2.Interfaces;

namespace LW2.Repository
{
    internal class DBItem<T> where T : IEntity
    {
        private int counter = 1;

        public List<T> Items { get; set; } = new();

        public int AddItem(T item)
        {
            item.Id = counter++;
            Items.Add(item);

            return item.Id;
        }

        public T? GetById(int id)
        {
            return Items.Find(item => item.Id == id);
        }
    }
}
