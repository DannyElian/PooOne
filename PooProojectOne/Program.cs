using System.Xml;
using PooProojectOne;
var userList = new List<user>();
var user = new user();
int mousePrice = 20;
int monitorPrice = 30;
int keyboardPrice = 20;
int headsetsPrice= 20;

Console.WriteLine("Bienvenido al sistema de facturas");
Console.WriteLine();
Console.WriteLine("Precios de los productos: ");
Console.WriteLine();
Console.WriteLine($@"Mouse: {mousePrice}
Monitor: {monitorPrice}
Teclado: {keyboardPrice}
Audifonos: {headsetsPrice}");




bool start = true;
string end = "";
do
{
    Console.WriteLine();
    Console.WriteLine("Ingrese Los siguientes datos:");
    Console.WriteLine();
    Console.WriteLine("Nombre del producto");
    user.Name = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("Color del producto");
    user.Color = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("Cantidad que desea comprar");
    user.Amount = Convert.ToInt32(Console.ReadLine());

    userList.Add(user);

    Console.WriteLine();
    Console.WriteLine("Desea continuar agregando productos");
    Console.WriteLine("Persione \"s\" para si o \"n\" para no");
    end = Console.ReadLine().ToUpper();


    if (string.IsNullOrEmpty(end))
    {
        Console.WriteLine("Has salido");
        break;
    }else if (end == "n".ToUpper())
    {
        Console.WriteLine("Has salido");
        break;
    }



} while (true);


foreach (var item in userList)
{
    XmlWriter xml = XmlWriter.Create("xmlDoc.xml");

    xml.WriteStartDocument();

    xml.WriteStartElement("Invoices");
    xml.WriteStartElement("Invoice");
    xml.WriteEndElement();
    xml.WriteStartElement("ID");
    xml.WriteString("1");
    xml.WriteEndElement();
    xml.WriteStartElement("Date");
    xml.WriteString($"{DateTime.Now}");

    xml.WriteStartElement("InvoiceDetails");
    xml.WriteStartElement("Detail");
    xml.WriteStartElement("DetailId");
    xml.WriteString("001");
    xml.WriteEndElement();
    xml.WriteStartElement("ArticleName");
    xml.WriteString($"{item.Name}");
    xml.WriteEndElement();
    xml.WriteStartElement("Color");
    xml.WriteString($"{item.Color}");
    xml.WriteEndElement();
    xml.WriteStartElement("Amount");
    xml.WriteString($"{item.Amount}");
    xml.WriteEndElement();
    if (item.Name == "Mouse")
    {
        xml.WriteStartElement("Price");
        xml.WriteString($"{ mousePrice}");
        item.Price = item.Amount * mousePrice;
    }
    else if (item.Name == "Teclado")
    {
        xml.WriteStartElement("Price");
        xml.WriteString($"{keyboardPrice}");
        item.Price = item.Amount * keyboardPrice;
    }
    else if(item.Name == "Monitor")
    {
        xml.WriteStartElement("Price");
        xml.WriteString($"{monitorPrice}");
        item.Price = item.Amount * monitorPrice;
    }
    else if (item.Name == "Audifonos")
    {
        xml.WriteStartElement("Price");
        xml.WriteString($"{headsetsPrice}");
        item.Price = item.Amount * headsetsPrice;
    }

    xml.WriteEndElement();
    xml.WriteStartElement("TotalPrice");
    xml.WriteString($"{item.Price}");
    xml.WriteEndElement();
    xml.Close();



}





