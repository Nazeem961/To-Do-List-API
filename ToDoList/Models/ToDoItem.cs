namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; }
        public string Title { get; set; }
        public bool Status { get; set; }

        public ToDoItem(int id, string title, bool status)
        {
            Id = id;
            Title = title;
            Status = status;
        }
    }
}
