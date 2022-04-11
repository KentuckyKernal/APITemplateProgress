
namespace ApiContainer
{
    internal class Organisation
    {

        public class RootTitle
        {
            public List<ResultsTitle> results { get; set; }
        }

        public class ResultsTitle
        {
            public string title { get; set; }   //film title
            public string[] characters { get; set; }
        }

        public class RootCharacters
        {
            public List<ResultsChar> results { get; set; }
        }

        public class ResultsChar
        {
            public string name { get; set; }   // char name
            public string[] films { get; set; }

        }
    }
}
