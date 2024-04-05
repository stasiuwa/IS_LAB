using System.Xml;
using System.Xml.XPath;

namespace IS_Lab1_XML;

public class XMLReadWithXLSTDOM
{
    public static void Read(string filepath)
    {
        XPathDocument document = new XPathDocument(filepath);
        XPathNavigator navigator = document.CreateNavigator();

        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("x", "http://rejestrymedyczne.ezdrowie.gov.pl/rpl/eksport-danych-v1.0");

        XPathExpression query =
            navigator.Compile(
                "/x:produktyLecznicze/x:produktLeczniczy[@nazwaPostaciFarmaceutycznej='Krem' and @nazwaPowszechnieStosowana='Mometasoni furoas']");
        query.SetContext(manager);
        int count = navigator.Select(query).Count;

        string sc, postac;
        Dictionary<string, List<string>> sameTypes = new Dictionary<string, List<string>>();
        
        XPathExpression query2 = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy");
        query2.SetContext(manager);
        
        XPathNodeIterator iterator = navigator.Select(query2);
        while (iterator.MoveNext())
        {
            sc = iterator.Current.GetAttribute("nazwaPowszechnieStosowana", "");
            postac = iterator.Current.GetAttribute("nazwaPostaciFarmaceutycznej", ""); 
            
            if (sameTypes.ContainsKey(sc)) sameTypes[sc].Add(postac);
            else sameTypes.Add(sc, new List<string>{postac});
        }

        int count2 = sameTypes.Count(pair => pair.Value.Count > 1);
        // foreach (KeyValuePair<string, List<string>> temp in sameTypes.Where(temp => temp.Value.Count > 1)) count2++;
        // foreach (KeyValuePair<string, List<string>> temp in sameTypes) if (temp.Value.Count > 1) count2++;
        
        Console.WriteLine($"Liczba produktów leczniczych w postacikremu, których jedyną substancją czynną jest Mometasoni furoas {count}");
        Console.WriteLine($"Liczba preparatow leczniczych o takiej samej nazwie powszechnej, pod różnymi postaciami: {count2}");
    }
}