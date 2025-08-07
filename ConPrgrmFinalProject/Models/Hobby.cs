namespace ConPrgrmFinalProject.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SkillLevel { get; set; }
        public bool IsSoloActivity { get; set; }
        public int HoursPerWeek { get; set; }
    }
}
