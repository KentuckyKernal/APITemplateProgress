
using Newtonsoft.Json;

namespace ApiContainer.SimpleTemplate
{
    public class Container
    {
        public class RootObject
        {
            public List<Results> results { get; set; }
        }

        public class Results
        {
            public string name { get; set; }  //"name": "Tatooine",
            public string rotation_period { get; set; } //"rotation_period": "23",
            public string orbital_period { get; set; } //"orbital_period": "304",
            public string diameter { get; set; } //"diameter": "10465",
            public string climate { get; set; } //"climate": "arid",
            public string gravity { get; set; } //"gravity": "1 standard",
            public string terrain { get; set; } //"terrain": "desert",
            public string surface_water { get; set; } //"surface_water": "1",
            public string population { get; set; } //"population": "200000",
            public string[] residents { get; set; } //"residents": [
            public string[] films { get; set; } //"films": [
            public string created { get; set; } //"created": "2014-12-09T13:50:49.641Z",
            public string edited { get; set; } //"edited": "2014-12-20T20:58:18.411Z",
            public string url { get; set; } //"url": "https://challenges.hackajob.co/swapi/api/planets/1/"

        }
    }

    internal class StarWars
    {
        public void RunProgramme()
        {
            IdentifiedObject();
            // RawResults();
        }

        static public void IdentifiedObject()
        {
            Task<string> result = GetResponseString();
            var jsonResult = result.Result;
            //for the object storage
            var js = JsonConvert.DeserializeObject<Container.RootObject>(jsonResult);



            ListNamesInResult(js);
            Console.WriteLine("-----------------");
            Console.WriteLine("Enter Film Name: ");
            string enteredName = Console.ReadLine();
            SelectFilmCountFromName(js, enteredName);
            Console.WriteLine("-----------------");
        }

        static public void ListNamesInResult(Container.RootObject rootObj)
        {
            foreach (Container.Results k in rootObj.results)
            {
                Console.WriteLine("name: " + k.name + " # Of Films: " + k.films.Length);
            }


        }

        public static void SelectFilmCountFromName(Container.RootObject rootObj, string Name)
        {

            int namePosition = 0;

            for (var i = 0; i < rootObj.results.Count; i++)
            {
                if (rootObj.results[i].name == Name)
                {
                    namePosition = i;
                }
            }

            string[] nameFilms = rootObj.results[namePosition].films;

            Console.WriteLine("Name: " + Name + " No. Of Films: " + nameFilms.Length);
        }


        static public void RawResults()
        {
            //Identify shape
            Task<string> result = GetResponseString();
            var jsonResult = result.Result;
            var js = JsonConvert.DeserializeObject(jsonResult);
            Console.WriteLine(js);
        }

        static public async Task<string> GetResponseString()
        {
            var httpClient = new HttpClient();

            //var response = await httpClient.GetAsync("https://challenges.hackajob.co/swapi/api/planets/1/");
            var response = await httpClient.GetAsync("https://challenges.hackajob.co/swapi/api/planets/");
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }
    }
}
