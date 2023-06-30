using System.IO;
using System;
namespace Wallet
{
public class TextFileSaver: IValueSaver
{
    const string Path = "Assets/Wallet/Data/Text";
    const string KeyOffset = "Text_";
    const int DefaultInteger = 0;
    public int Load(ValueKey key){
        if(!File.Exists(GetFullPath(key))) return DefaultInteger;
        
        return  Convert.ToInt32(File.ReadAllText(GetFullPath(key)));
    }
    public void Save(ValueKey key, int value){
        if(!Directory.Exists(Path)) Directory.CreateDirectory(Path);
        File.WriteAllText(GetFullPath(key), $"{value}");
    }

    string GetFullPath(ValueKey key){
        return Path + "/" + KeyOffset + key + ".txt";
    }
}
}
