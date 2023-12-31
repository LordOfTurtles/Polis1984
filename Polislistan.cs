using System.Text.Json;


namespace Polis_1984
{
    public class PolisLista
    {
        public static List<Polis> listaAvPoliser = new List<Polis>();

        public PolisLista()
        {
            string fileName = "Personal.json";
            string jsonString = File.ReadAllText(fileName);
            listaAvPoliser = JsonSerializer.Deserialize<List<Polis>>(jsonString)!;
        }

        public List<Polis> HämtaPoliser()
        {
            return listaAvPoliser;
        }
        
        public static void PersonalLista()
        {
            string fileName = "Personal.json";
            string jsonString = File.ReadAllText(fileName);
            listaAvPoliser = JsonSerializer.Deserialize<List<Polis>>(jsonString)!;
            
            for(int i = 0; i < listaAvPoliser.Count; i++)
            {
                Console.WriteLine($"{listaAvPoliser[i].Namn} Tjänstenummer: {listaAvPoliser[i].Tjanstenummer}");
            }
        }
        
        public static void NyPersonal()
        {
            string fileName = "Personal.json";
            string jsonString = File.ReadAllText(fileName);
            listaAvPoliser = JsonSerializer.Deserialize<List<Polis>>(jsonString)!;
            
            Console.Write("Ange namn på polis som ska läggas till: ");
            string namn = Console.ReadLine()!;
            Console.Write("Ange tjänstenummer för polis som ska läggas till: ");
            int tjänstenummer = Convert.ToInt32(Console.ReadLine());
            listaAvPoliser.Add(new Polis(namn, tjänstenummer));
            
            jsonString = JsonSerializer.Serialize(listaAvPoliser);
            File.WriteAllText(fileName, jsonString);
        }      
    }
}
