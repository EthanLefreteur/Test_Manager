namespace Test_Manager.Models
{
    public class ResultatTest : BaseResultat
    {
        public int Id { get; set; }
        public Test test { get; set; }
        public List<BaseReponse> reponses { get; set; }
    }
}
