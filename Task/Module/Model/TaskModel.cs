namespace Task.Module.Model
{
    public class TaskModel
    {
        public int Id { get; set; }
        public required string Name  { get; set; }
        public int ProjectId { get; set; }
    }
}
