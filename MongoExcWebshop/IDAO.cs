using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExcWebshop;

internal interface IDAO
{
    public void CreateProduct(Yarn yarn);
    public void DeleteProduct(int articleNr);
    public List<Yarn> GetAllProducts();
    public Yarn GetOne(int articleNr);
    public void UpdateProduct(int articleNr, string field, string value);
    public void UpdateProductInt(int articleNr, string field, int intValue);
}
