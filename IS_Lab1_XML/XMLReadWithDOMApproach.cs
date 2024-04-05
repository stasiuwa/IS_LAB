using System.Xml;

namespace IS_Lab1_XML;

public class XMLReadWithDOMApproach
{
    public static void Read(string filepath)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(filepath);

        string postac, sc;
        int count = 0, count2 = 0;
        var drugs = doc.GetElementsByTagName("produktLeczniczy");
        Dictionary<string, List<String>> sameTypes = new Dictionary<string, List<String>>();
        
        foreach (XmlNode d in drugs)
        {
            postac = d.Attributes.GetNamedItem("nazwaPostaciFarmaceutycznej").Value;
            sc = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;
            if (postac == "Krem" && sc == "Mometasoni furoas") count++;
            
            if (sameTypes.ContainsKey(sc)) sameTypes[sc].Add(postac);
            else sameTypes.Add(sc, new List<string>{postac});

        }
        Console.WriteLine("Liczba Produktow lecznicych w postaci kremu, ktorych jedyna substancja czynna jest Mometasoni furoas {0}", count);
        foreach (KeyValuePair<string, List<string>> temp in sameTypes)
        {
            if (temp.Value.Count > 1) count2++;
            // {
            //     Console.WriteLine("Nazwa powszechnie stosowana {0}, ilosc postaci {1}", temp.Key, temp.Value.Count);
            // }
        }
        Console.WriteLine("Liczba preparatow leczniczych o takiej samej nazwie powszechnej, pod różnymi postaciami: {0}", count2);
    }

    public static void Read2(string filepath)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(filepath);

        string postac, sc;
        int count = 0, count2 = 0;
        var drugs = doc.GetElementsByTagName("produktLeczniczy");
        Dictionary<string, List<String>> sameTypes = new Dictionary<string, List<String>>();
        
        foreach (XmlNode d in drugs)
        {
            postac = d.Attributes.GetNamedItem("nazwaPostaciFarmaceutycznej").Value;
            sc = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;
            if (postac == "Krem" && sc == "Mometasoni furoas") count++;
            
            if (sameTypes.ContainsKey(sc)) sameTypes[sc].Add(postac);
            else sameTypes.Add(sc, new List<string>{postac});

        }
        Console.WriteLine("Liczba Produktow lecznicych w postaci kremu, ktorych jedyna substancja czynna jest Mometasoni furoas {0}", count);
        foreach (KeyValuePair<string, List<string>> temp in sameTypes)
        {
            if (temp.Value.Count > 1) count2++;
            // {
            //     Console.WriteLine("Nazwa powszechnie stosowana {0}, ilosc postaci {1}", temp.Key, temp.Value.Count);
            // }
        }
        Console.WriteLine("Liczba preparatow leczniczych o takiej samej nazwie powszechnej, pod różnymi postaciami: {0}", count2);
    }
}