namespace ConPrgrmFinalProject.Models
{
    public class PetInfo
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public bool IsVaccinated { get; set; }
    }
}