using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExcWebshop
{
    public class Yarn
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int ArticleNr { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public Yarn(string BsonId, int articleNr, string name, string material, int price, int qty)
        {
            Id = BsonId;
            ArticleNr = articleNr;
            Name = name;
            Material = material;
            Price = price;
            Qty = qty;
        }
    }
}
