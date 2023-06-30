using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class CurrencyText : MonoBehaviour
{

    [SerializeField] ValueTester _currentTester;
    TextMeshProUGUI _currentText;
    void Start(){
        UpdateText();
    }

    void UpdateText(){
        if(_currentText == null) _currentText = GetComponent<TextMeshProUGUI>();
        _currentText.text = $"{_currentTester.Value}";
    }
    void OnEnable(){
        _currentTester.OnValueChange += UpdateText;
    }
    void OnDisable(){
        _currentTester.OnValueChange -= UpdateText;
    }
}
