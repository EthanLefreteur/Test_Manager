namespace Test_Manager.Models
{
    public class QuestionQCM : BaseQuestion
    {
        public List<string> reponse_possibles { get; set; }
        public List<int> reponse_correctes { get; set; }
    }
}
