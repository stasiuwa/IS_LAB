using IS_Lab1_XML;

string xmlpath = Path.Combine("Assets", "data.xml");

// odczyt danych z wykorzystaniem DOM
Console.WriteLine("XML Loaded by DOM Approach");
XMLReadWithDOMApproach.Read(xmlpath);

// odczyt danych z wykorzystaniem SAX
Console.WriteLine("XML Loaded by SAX Approach");
XMLReadWithSAXApproach.Read(xmlpath);

// odczyt danych z wykorzystaniem XPath i DOM
Console.WriteLine("XML Loaded with XPath");
XMLReadWithXLSTDOM.Read(xmlpath);

Console.ReadLine();