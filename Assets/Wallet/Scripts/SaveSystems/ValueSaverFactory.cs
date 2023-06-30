using System.Collections.Generic;
namespace Wallet
{
public class ValueSaverFactory
{
    Dictionary<SaveType,IValueSaver> _saverPool;
    Dictionary<ValueKey,SaveType> _savePreferences;
    SaveType _defaultSaveType = SaveType.PlayerPrefs;

    public ValueSaverFactory(){
        SerializeSaverPool();
    }    
    public ValueSaverFactory(SaveType type){
        _defaultSaveType = type;
        SerializeSaverPool();
    }
    public void ChangeSavePreference(ValueKey key, SaveType saveType){
        if(_savePreferences.ContainsKey(key)) _savePreferences[key] = saveType;
        _savePreferences.Add(key,saveType);
    }
    
    public IValueSaver GetSaverForKey(ValueKey key){
        if(_savePreferences.ContainsKey(key)) return _saverPool[_savePreferences[key]];
        return _saverPool[_defaultSaveType];
    }

    void SerializeSaverPool(){
        //Add each IValueSaver
        _saverPool = new Dictionary<SaveType,IValueSaver>{
            {SaveType.PlayerPrefs,new PlayerPrefSaver()},
            {SaveType.TextFile,new TextFileSaver()},
            {SaveType.BinaryFile,new BinaryFileSaver()}
        };
        //Default Preferences (You may delete this part)
        _savePreferences = new Dictionary<ValueKey,SaveType>{
            // {ValueKey.Crystals,SaveType.TextFile},
            // {ValueKey.Coins,SaveType.PlayerPrefs}
        };
    }
}
}