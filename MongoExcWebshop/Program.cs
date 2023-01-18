using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoExcWebshop;
internal class Program
{
    static void Main(string[] args)
    {
        IUI io;
        IDAO dAO;

        io = new StringIO();
        dAO = new MongoDAO("mongodb+srv://sample:Lbgp6Mpbn0D4AA9S@cluster0.nglqlri.mongodb.net/?retryWrites=true&w=majority", "Webshop", "yarns");

        Controller controller = new Controller(io, dAO);
        controller.Start();
    }

   
   
}