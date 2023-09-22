namespace Bookstore.Application.ViewModel.Book
{
    public class EditorBookViewModel
    {
        public EditorBookViewModel(int? id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
        public int? Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
    }
}