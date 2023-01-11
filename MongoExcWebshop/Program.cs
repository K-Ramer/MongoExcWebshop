using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoExcWebshop;
internal class Program
{
    static void Main(string[] args)
    {
        MongoClient dbClient = new MongoClient("mongodb+srv://sample:Lbgp6Mpbn0D4AA9S@cluster0.nglqlri.mongodb.net/?retryWrites=true&w=majority");

        var database = dbClient.GetDatabase("Webshop");
        var collection = database.GetCollection<BsonDocument>("equipment");
    }

    void AddOneYarn()
    {
        MongoClient dbClient = new MongoClient("mongodb+srv://sample:Lbgp6Mpbn0D4AA9S@cluster0.nglqlri.mongodb.net/?retryWrites=true&w=majority");

        var database = dbClient.GetDatabase("Webshop");
        var collection = database.GetCollection<BsonDocument>("yarns");

        var document = new BsonDocument
        {
            {"name", "" },
            {"brand", "" },
            {"material", "" },
            {"colour", "" },
            {"price", 25 },
            {"qty", 5 }
        };

        collection.InsertOne(document);

        Console.WriteLine("Yarn added!");
    }
    void AddOneEquipment()
    {
        MongoClient dbClient = new MongoClient("mongodb+srv://sample:Lbgp6Mpbn0D4AA9S@cluster0.nglqlri.mongodb.net/?retryWrites=true&w=majority");

        var database = dbClient.GetDatabase("Webshop");
        var collection = database.GetCollection<BsonDocument>("equipment");

        var document = new BsonDocument
        {
            {"name", "" },
            {"material", "" },
            {"colour", "" },
            {"price", 25 },
            {"qty", 5 }
        };

        collection.InsertOne(document);

        Console.WriteLine("Equipment added!");
    }
}