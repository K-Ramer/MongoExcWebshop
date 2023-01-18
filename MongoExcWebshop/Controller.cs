using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    io.PrintStringList(yarns);
                    break;
                
                case 2:
                    io.Clear();
                    var newYarn = io.GetNewYarn();
                    dAO.CreateProduct(newYarn);
                    io.Clear();
                    io.PrintString("Nytt garn tillagt!\n\n");
                    break;
                
                case 3:
                    io.Clear();
                    List<Yarn> yarnUpdate = dAO.GetAllProducts();
                    io.PrintStringList(yarnUpdate);
                    io.PrintString("Ange vilket artikelnummer du vill uppdatera:");
                    int articleNr = io.GetInt();
                    io.Clear();
                    while (dAO.GetOne(articleNr) == null)
                    {
                        io.PrintStringList(yarnUpdate);
                        io.PrintString("Felaktigt artikelnummer. Försök igen:");
                        articleNr = io.GetInt();
                    }
                    io.Clear();
                    io.PrintOne(dAO.GetOne(articleNr));
                    io.PrintString("Ange vilket fält du vill uppdatera. En siffra mellan 1 och 5:");
                    var field = io.GetField();
                    io.PrintString("Ange värde:");
                    var value = io.GetString();
                    int intValue;
                    if (field.Equals("Price") || field.Equals("Qty"))
                    {
                        int.TryParse(value, out intValue);
                        dAO.UpdateProductInt(articleNr, field, intValue);
                    }
                    else
                    {
                    dAO.UpdateProduct(articleNr, field, value);
                    }
                    io.Clear();
                    io.PrintString($"Produkt med artikelnummer {articleNr} uppdaterad!\n\n");
                    break;
                
                case 4:
                    io.Clear();
                    List<Yarn> yarnDelete = dAO.GetAllProducts();
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
                    dAO.DeleteProduct(articleNrDelete);
                    io.PrintString("Produkt borttagen.\n\n");
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
