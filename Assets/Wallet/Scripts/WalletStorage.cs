using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Wallet
{
public class WalletStorage : MonoBehaviour
{
    #region Instance
    public static WalletStorage Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<WalletStorage>(); // Eewww
                if (_instance == null)
                {
                    _instance = new GameObject("Spawned WalletStorage", typeof(WalletStorage)).GetComponent<WalletStorage>();
                }
            }
            return _instance;
        }
    }
    private static WalletStorage _instance;
    #endregion    
    [SerializeField] bool _dontDestroyOnLoad = false;
    ValueSaverFactory _valueSaverFactory;
    Dictionary<ValueKey,int> _storage = new Dictionary<ValueKey, int>();

    void Awake(){
        if(WalletStorage.Instance != null && WalletStorage.Instance != this){
            Destroy(gameObject);
        } else{
            _instance = this;
        }
        if(_dontDestroyOnLoad) DontDestroyOnLoad(gameObject);
        _valueSaverFactory = new ValueSaverFactory();

    }

    public int GetValue(ValueKey key){
        if(_storage.ContainsKey(key) == false) LoadAndStore(key);
        return _storage[key];
    }
    public void SetValue(ValueKey key, int value){
        if(_storage.ContainsKey(key) == false) LoadAndStore(key);
        _storage[key] = value;
    }
    public void AddToValue(ValueKey key, int value){
        if(_storage.ContainsKey(key) == false) LoadAndStore(key);
        _storage[key] += value;
    }

    private void LoadAndStore(ValueKey key){
        _storage.Add(key,_valueSaverFactory.GetSaverForKey(key).Load(key));
    }

    private void SaveStorage(){
        foreach (KeyValuePair<ValueKey,int> pair in _storage){
            _valueSaverFactory.GetSaverForKey(pair.Key).Save(pair.Key,pair.Value);
        }

    }

    void OnDestroy(){
        SaveStorage();
    }
}
}
