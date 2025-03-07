namespace Test_Manager.Models
{
    public class ResultatCampagne
    {
        public int Id { get; set; }
        public Campagne campagne { get; set; }
        public List<ResultatTest> resultatTests { get; set; }
    }
}
