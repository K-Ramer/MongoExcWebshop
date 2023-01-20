using DnsClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MongoExcWebshop;

internal class StringIO : IUI
{
    

    public void Clear()
    {
        Console.Clear();
    }
    public void Exit()
    {
        System.Environment.Exit(0);
    }
    public Yarn GetNewYarn()
    {
        string id = "";
        PrintString("Skapa ny produkt\n\nSkriv in artikelnummer:");
        int articleNr;
        while (!int.TryParse(GetString(), out articleNr))
            PrintString("Endast heltal tack!");
        PrintString("Skriv in produktnamn:");
        string name = GetString();
        while (string.IsNullOrWhiteSpace(name))
            { PrintString("Skriv in produktnamn:"); name = GetString(); }
        PrintString("Skriv in material:");
        string material = GetString();
        while (string.IsNullOrWhiteSpace(material))
            { PrintString("Skriv in material:"); material = GetString(); }
        PrintString("Skriv in pris:");
        int price;
        while (!int.TryParse(GetString(), out price))
            PrintString("Endast heltal tack!");
        PrintString("Skriv in antal i lager:");
        int qty;
        while (!int.TryParse(GetString(), out qty))
            PrintString("Endast heltal tack!");

        Yarn yarn = new Yarn(id, articleNr, name, material, price, qty);
        return yarn;
    }
    public string GetString()
    {
        return Console.ReadLine();
    }
    public string GetField()
    {
        int input;
        string field = "";
        while (!int.TryParse(GetString(), out input) || input < 1 || input > 5)
            PrintString("Ange fält. En siffra mellan 1 och 5. Endast heltal tack!:");
        if (input == 1)
            field = "ArticleNr";
        else if (input == 2)
            field = "Name";
        else if (input == 3)
            field = "Material";
        else if (input == 4)
            field = "Price";
        else if (input == 5)
            field = "Qty";
        return field;
    }
    
    public int GetInt()
    {
        int value;
        int.TryParse(GetString(), out value);
        return value;
    }

    public void PrintMenu()
    {
        PrintString("1. Se alla produkter.\n2. Lägg till produkt.\n3. Uppdatera produkt\n4. Ta bort produkt.\n5.Exit.");
    }
    public void PrintOne(Yarn yarn)
    {
        PrintString($"1 Article nr : {yarn.ArticleNr}\n2 Name: {yarn.Name}\n3 Material: {yarn.Material}\n4 Price: {yarn.Price}\n5 Qty: {yarn.Qty}\n\n");
    }
    public void PrintString(string output)
    {
        Console.WriteLine(output);
    }

    public void PrintStringList(List<Yarn> output)
    {
        foreach(Yarn yarn in output)
        {
            PrintString($"Article nr : {yarn.ArticleNr}\nName: {yarn.Name}\nMaterial: {yarn.Material}\nPrice: {yarn.Price}\nQty: {yarn.Qty}\n\n");
        }
    }
}
