namespace Test_Manager.Models
{
    public class Gestionnaire : User
    {
        public List<BaseTest> tests { get; set; }
        public List<Candidat> candidats { get; set; }
        public Entreprise entreprise { get; set; }
    }
}
