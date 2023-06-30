using UnityEngine;
namespace Wallet
{
public class PlayerPrefSaver: IValueSaver
{
    const string KeyOffset = "Value_";
    public int Load(ValueKey key){
        return PlayerPrefs.GetInt(KeyOffset + key,0);
    }
    public void Save(ValueKey key, int value){
        PlayerPrefs.SetInt(KeyOffset + key,value);
    }
}
}
