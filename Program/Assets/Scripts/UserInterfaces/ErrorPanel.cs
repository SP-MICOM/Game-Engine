using TMPro;
using UnityEngine;

public class ErrorPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    public void SetMessage(string message)
    {
        textMeshProUGUI.text = message;
    }
}
