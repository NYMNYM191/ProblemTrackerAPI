namespace ProblemTrackerAPI.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
