using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
namespace Wallet
{
public class BinaryFileSaver : IValueSaver
{
    const string Path = "Assets/Wallet/Data/Binary";
    const string KeyOffset = "Binary_";
    const int DefaultInteger = 0;
    public int Load(ValueKey key){
        if(!File.Exists(GetFullPath(key))) return DefaultInteger;
        
        
        BinaryFormatter formatter = new BinaryFormatter();
        
        FileStream saveFile = File.Open(GetFullPath(key), FileMode.Open);
        
        int output = (int)formatter.Deserialize(saveFile);
        
        saveFile.Close();
        
        return output;
    }
    public void Save(ValueKey key, int value){
        if(!Directory.Exists(Path)) Directory.CreateDirectory(Path);
        
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Create(GetFullPath(key));

        formatter.Serialize(saveFile, value);
        Debug.Log("Binary Saved On" + GetFullPath(key));
        saveFile.Close();
    }

    string GetFullPath(ValueKey key){
        return Path + "/" + KeyOffset + key + ".bin";
    }
}
}
