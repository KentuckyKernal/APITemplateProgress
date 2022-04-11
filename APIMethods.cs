
using Newtonsoft.Json;

namespace ApiContainer
{
    internal class APIMethods
    {

        public string IdentifiedName(string newUri)
        {
            Task<string> result = GetResponseCharString(newUri);
            var jsonResult = result.Result;
            var js = JsonConvert.DeserializeObject<Organisation.ResultsChar>(jsonResult);

            return js.name;
        }

        public string IdentifiedTitle(string newUri)
        {
            Task<string> result = GetResponseCharString(newUri);
            var jsonResult = result.Result;
            var js = JsonConvert.DeserializeObject<Organisation.ResultsTitle>(jsonResult);

            return js.title;
        }

        public async Task<string> GetResponseCharString(string uriString)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uriString);
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }

        public async Task<string> GetResponseString()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://challenges.hackajob.co/swapi/api/films/");
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }





    }
}
