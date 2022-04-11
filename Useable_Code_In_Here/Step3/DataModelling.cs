
using Newtonsoft.Json;

namespace ApiContainer
{
    internal class DataModelling
    {
        public void ProcessSelection(List<string> pp, List<string> splitFilms, string plc1, string plc2)
        {

            string filmChars = String.Empty;

            for (var i = 0; i < pp.Count - 1; i++)
            {
                filmChars += new APIMethods().IdentifiedName(pp[i]);
                if (i != pp.Count - 2)
                {
                    filmChars += ", ";
                }
            }
            filmChars = plc1 + ": " + filmChars;




            string charFilms = String.Empty;

            for (var i = 0; i < splitFilms.Count - 1; i++)
            {
                charFilms += new APIMethods().IdentifiedTitle(splitFilms[i]);
                if (i != splitFilms.Count - 2)
                {
                    charFilms += ", ";
                }
            }
            charFilms = plc2 + ": " + charFilms;
            Console.WriteLine(filmChars + "; " + charFilms);
        }

        public Dictionary<string, string> IdentifiedTitle()
        {
            Task<string> result = new APIMethods().GetResponseString();
            var jsonResult = result.Result;
            //for the object storage
            var js = JsonConvert.DeserializeObject<Organisation.RootTitle>(jsonResult);

            string titleString = String.Empty;

            Dictionary<string, string> results = new Dictionary<string, string>();

            foreach (Organisation.ResultsTitle item in js.results)
            {

                titleString = String.Empty;

                foreach (var ch in item.characters)
                {
                    titleString += ch + " ";
                }

                results.Add(item.title, titleString);
            }

            return results;
        }

        public Dictionary<string, string> IdentifiedCharToFilm()
        {
            Dictionary<string, string> ggg = new Dictionary<string, string>();
            string filmsStr = String.Empty;

            Task<string> result = new APIMethods().GetResponseCharString("https://challenges.hackajob.co/swapi/api/people/");
            var jsonResult = result.Result;
            var js = JsonConvert.DeserializeObject<Organisation.RootCharacters>(jsonResult);

            foreach (Organisation.ResultsChar item in js.results)
            {
                filmsStr = String.Empty;

                foreach (var i in item.films)
                {
                    filmsStr += i + " ";
                }
                ggg.Add(item.name, filmsStr);
            }

            return ggg;
        }
    }
}
