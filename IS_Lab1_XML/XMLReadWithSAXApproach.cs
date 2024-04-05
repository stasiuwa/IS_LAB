using System.Xml;

namespace IS_Lab1_XML;

public class XMLReadWithSAXApproach
{
    public static void Read(string filepath)
    {
         // konfiguracja początkowa dla XMLReadera
         XmlReaderSettings settings = new XmlReaderSettings();
         settings.IgnoreComments = true;
         settings.IgnoreProcessingInstructions = true;
         settings.IgnoreWhitespace = true;
         
         // odczyt zawartości dokumentu
         XmlReader reader = XmlReader.Create(filepath, settings);
         
        // zmienne pomocnicze
        int count = 0, count2=0;
        string postac = "", sc = "";

        Dictionary<string, List<String>> sameTypes = new Dictionary<string, List<String>>();
        
        reader.MoveToContent();
        
        // analiza każdego z węzłów dokumentu
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "produktLeczniczy")
            {
                postac = reader.GetAttribute("nazwaPostaciFarmaceutycznej");
                sc = reader.GetAttribute("nazwaPowszechnieStosowana");
                if (postac == "Krem" && sc == "Mometasoni furoas") count++;
                
                if (sameTypes.ContainsKey(sc)) sameTypes[sc].Add(postac);
                else sameTypes.Add(sc, new List<string>{postac});
            }
        }
        Console.WriteLine($"Liczba produktow leczniczych w postaci kremu, ktorych jednya substancja czynna jest Mometasoni furoas {count}");
        //1.3.2 nie robic
        foreach (KeyValuePair<string, List<string>> temp in sameTypes) if (temp.Value.Count > 1) count2++;
        Console.WriteLine($"Liczba preparatow leczniczych o takiej samej nazwie powszechnej, pod różnymi postaciami: {count2}");
    }
}