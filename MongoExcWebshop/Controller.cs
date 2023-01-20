using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MongoExcWebshop;

internal class Controller
{
    IUI io;
    IDAO dAO;

    public Controller(IUI io, IDAO dAO)
    {
        this.io = io;
        this.dAO = dAO;
    }
    public void Start()
    {
        bool loop = true;
        while (loop)
        {
            io.PrintMenu();

            int choice;
            int.TryParse(io.GetString(), out choice);

            switch (choice)
            {
                case 1:
                    io.Clear();
                    List<Yarn> yarns = dAO.GetAllProducts();
                    if (yarns is not null) io.PrintStringList(yarns);
                    else io.PrintString("Listan är tom eller så uppstod ett oväntat fel.");
                    break;
                
                case 2:
                    io.Clear();
                    var newYarn = io.GetNewYarn();
                    io.Clear();
                    if (dAO.CreateProduct(newYarn)) io.PrintString("Nytt garn tillagt!\n\n");
                    else io.PrintString("Ett oväntat fel uppstod.");
                    break;
                
                case 3:
                    io.Clear();
                    List<Yarn> yarnUpdate = dAO.GetAllProducts();
                    if (yarnUpdate is not null) io.PrintStringList(yarnUpdate);
                    else io.PrintString("Ett oväntat fel uppstod.");
                    io.PrintString("Ange vilket artikelnummer du vill uppdatera:");
                    int articleNr = io.GetInt();
                    io.Clear();
                    while (dAO.GetOne(articleNr) == null)
                    {
                        io.PrintStringList(yarnUpdate);
                        io.PrintString("Felaktigt artikelnummer eller oväntat fel. Försök igen:");
                        articleNr = io.GetInt();
                    }
                    io.Clear();
                    if (dAO.GetOne(articleNr) != null) io.PrintOne(dAO.GetOne(articleNr));
                    else io.PrintString("Ett oväntat fel uppstod.");
                    io.PrintString("Ange vilket fält du vill uppdatera. En siffra mellan 1 och 5:");
                    var field = io.GetField();
                    io.PrintString("Ange värde:");
                    var value = io.GetString();
                    int intValue;
                    io.Clear();
                    if (field.Equals("Price") || field.Equals("Qty"))
                    {
                        int.TryParse(value, out intValue);
                        if (dAO.UpdateProductInt(articleNr, field, intValue)) { io.PrintString($"Produkt med artikelnummer {articleNr} uppdaterad!\n\n"); }
                        else { io.PrintString("Ett oväntat fel uppstod."); }
                        
                    }
                    else
                    {
                    if (dAO.UpdateProduct(articleNr, field, value)) { io.PrintString($"Produkt med artikelnummer {articleNr} uppdaterad!\n\n"); }
                    else io.PrintString("Ett oväntat fel uppstod.");
                    }
                    break;
                
                case 4:
                    io.Clear();
                    List<Yarn> yarnDelete = dAO.GetAllProducts();
                    if (yarnDelete is not null)
                    {
                        io.PrintStringList(yarnDelete);
                        io.PrintString("Ange vilket artikelnummer du vill ta bort:");
                        int articleNrDelete = io.GetInt();
                        io.Clear();
                        while (dAO.GetOne(articleNrDelete) == null)
                        {
                            io.PrintStringList(yarnDelete);
                            io.PrintString("Felaktigt artikelnummer. Försök igen:");
                            articleNrDelete = io.GetInt();
                        }
                        if (dAO.DeleteProduct(articleNrDelete)) { io.PrintString("Produkt borttagen.\n\n"); }
                        else io.PrintString("Ett oväntat fel uppstod.");
                    }
                    else io.PrintString("Det finns inga produkter att ta bort eller så uppstod ett oväntat fel.");
                    break;
                
                case 5:
                    io.Exit();
                    break;
                
                default:
                    io.PrintString("Felaktigt menyval. Prova igen.\n\n");
                    break;
            }
        }
       
    }
}
