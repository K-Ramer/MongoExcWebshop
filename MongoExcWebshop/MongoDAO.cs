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

    public bool CreateProduct(Yarn yarn)
    {
        try { collection.InsertOne(yarn); return true; }
        catch(Exception) { return false; }
    }

    public bool DeleteProduct(int articleNr)
    {
        var deleteFilter = Builders<Yarn>.Filter.Eq("ArticleNr", articleNr);

        try { collection.DeleteOne(deleteFilter); return true; }
        catch(Exception) { return false; }
    }

    public List<Yarn> GetAllProducts()
    {
        try { return collection.Find(y => true).ToList(); }
        catch(Exception) { return null; }
    }

    public Yarn GetOne(int articleNr)
    {
        try { return collection.Find(y => y.ArticleNr == articleNr).SingleOrDefault(); }
        catch(Exception) { return null; }
    }

    public bool UpdateProduct(int articleNr, string field, string value)
    {
        var updateFilter = Builders<Yarn>.Filter.Eq("ArticleNr", articleNr);
        var update = Builders<Yarn>.Update.Set(field, value);

        try { collection.UpdateOne(updateFilter, update); return true; }
        catch(Exception) { return false; }
    }
    public bool UpdateProductInt(int articleNr, string field, int intValue)
    {
        var updateFilter = Builders<Yarn>.Filter.Eq("ArticleNr", articleNr);
        var update = Builders<Yarn>.Update.Set(field, intValue);
        
        try { collection.UpdateOne(updateFilter, update); return true; }
        catch (Exception) { return false; }
    }
}
