// See https://aka.ms/new-console-template for more information

using IS_Lab5_SOAPCS.MyFirsstWSService;

Console.WriteLine("My First SOAP Client!");

MyFirstSoapInterfaceClient client = new MyFirstSoapInterfaceClient();

string text = await client.getHelloWorldAsStringAsync("Pawel");
long days = await client.getDaysBetweenDatesAsync("20 03 2024", "22 03 2024");

Console.WriteLine(text);
Console.WriteLine("Dni pomiedzy: " + days);
Console.Read();