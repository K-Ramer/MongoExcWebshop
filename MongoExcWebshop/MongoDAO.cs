using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MongoExcWebshop;

internal class MongoDAO : IDAO
{
    MongoClient dbClient;
    IMongoDatabase database;
    IMongoCollection<Yarn> collection;

    public MongoDAO(string connectionString, string database, string collection)
    {
        dbClient = new MongoClient(connectionString);
        this.database = dbClient.GetDatabase(database);
        this.collection = this.database.GetCollection<Yarn>(collection);
    }

    public void CreateProduct(Yarn yarn)
    {
        collection.InsertOne(yarn);
    }

    public void DeleteProduct(int articleNr)
    {
        var deleteFilter = Builders<Yarn>.Filter.Eq("ArticleNr", articleNr);

        collection.DeleteOne(deleteFilter);
    }

    public List<Yarn> GetAllProducts()
    {
        return collection.Find(y => true).ToList();
    }

    public Yarn GetOne(int articleNr)
    {
        return collection.Find(y => y.ArticleNr == articleNr).SingleOrDefault();
    }

    public void UpdateProduct(int articleNr, string field, string value)
    {
        var updateFilter = Builders<Yarn>.Filter.Eq("ArticleNr", articleNr);
        var update = Builders<Yarn>.Update.Set(field, value);
        collection.UpdateOne(updateFilter, update);
    }
    public void UpdateProductInt(int articleNr, string field, int intValue)
    {
        var updateFilter = Builders<Yarn>.Filter.Eq("ArticleNr", articleNr);
        var update = Builders<Yarn>.Update.Set(field, intValue);
        collection.UpdateOne(updateFilter, update);
    }
}
