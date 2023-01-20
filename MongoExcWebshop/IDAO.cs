using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExcWebshop;

internal interface IDAO
{
    public bool CreateProduct(Yarn yarn);
    public bool DeleteProduct(int articleNr);
    public List<Yarn> GetAllProducts();
    public Yarn GetOne(int articleNr);
    public bool UpdateProduct(int articleNr, string field, string value);
    public bool UpdateProductInt(int articleNr, string field, int intValue);
}
