using UnityEngine;

public class PanelManager : Singleton<PanelManager>
{
    public void Open(string message)
    {
        Debug.Log(message);
    }
}
