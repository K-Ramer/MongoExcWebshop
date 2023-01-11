using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBEx_local;
internal class Program
{
    static void Main(string[] args)
    {
        MongoClient dbClient = new MongoClient("mongodb+srv://sample:Lbgp6Mpbn0D4AA9S@cluster0.nglqlri.mongodb.net/?retryWrites=true&w=majority");

        var database = dbClient.GetDatabase("Webshop");
        var collection = database.GetCollection<BsonDocument>("equipment");

        var document = new BsonDocument
        {
            {"name", "Scissor" },
            {"colour", "Pink" },
            {"price", 25 },
            {"qty", 5 }
        };

        collection.InsertOne(document);

        Console.WriteLine("Document inserted!");

    }
}