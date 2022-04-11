
namespace ApiContainer
{
    internal class RunProgramme
    {
        public void EnterNames()
        {
            Console.WriteLine("Enter Film: A New Hope");
            string Film = Console.ReadLine();
            Console.WriteLine("Enter Character: Luke Skywalker");
            string Character = Console.ReadLine();

            StartProgramme(Film, Character);
        }

        public static void StartProgramme(string flm, string nme)
        {

            Dictionary<string, string> results = new DataModelling().IdentifiedTitle();
            List<string> filmString = new List<string>();
            List<string> charStrings = new List<string>();

            Dictionary<string, string> charToFilm = new DataModelling().IdentifiedCharToFilm();
            List<string> filmStrings = new List<string>();
            List<string> charString = new List<string>();

            // Split Dictionary
            foreach (var i in results)
            {
                filmString.Add(i.Key);
                charStrings.Add(i.Value);
            }

            int place1 = filmString.IndexOf(flm);


            foreach (var i in charToFilm)
            {
                filmStrings.Add(i.Value);
                charString.Add(i.Key);
            }

            int place2 = charString.IndexOf(nme);

            List<string> pp = charStrings[place1].Split(' ').ToList();
            List<string> splitFilms = filmStrings[place2].Split(' ').ToList();
            string plc1 = filmString[place1];
            string plc2 = charString[place2];

            new DataModelling().ProcessSelection(pp, splitFilms, plc1, plc2);
        }

    }
}
