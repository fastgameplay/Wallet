using UnityEngine;
using System;
using Wallet;
public class ValueTester : MonoBehaviour
{
    public event Action OnValueChange;
    [SerializeField] ValueKey _key;
    public int Value {
        get{
            return WalletStorage.Instance.GetValue(_key);
        }
        private set{
            WalletStorage.Instance.SetValue(_key, value);
        }
    }
    public void IncreaseByOne(){
        Value += 1;
        OnValueChange?.Invoke();
    }
    public void Reset(){
        Value = 0;
        OnValueChange?.Invoke();
    }
}
