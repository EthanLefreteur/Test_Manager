namespace Test_Manager.Models
{
    public class BaseQuestion
    {
        public int Id { get; set; }
        public string question { get; set; }
        public Test test { get; set; }
    }
}
