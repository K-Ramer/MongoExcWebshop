using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExcWebshop;

internal interface IUI
{
    public void Clear();
    public string GetField();
    public int GetInt();
    public Yarn GetNewYarn();
    public string GetString();
    public void PrintMenu();
    public void PrintOne(Yarn yarn);
    public void PrintString(string output);
    public void PrintStringList(List<Yarn> output);
    public void Exit();
}
