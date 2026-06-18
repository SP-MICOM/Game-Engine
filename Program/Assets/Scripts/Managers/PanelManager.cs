using UnityEngine;
using System.Collections.Generic;

public class PanelManager : Singleton<PanelManager>
{
    [SerializeField] GameObject clone = null;

    Dictionary<Panel, GameObject> dictionary = new Dictionary<Panel, GameObject>();

    public void Open(string message)
    {
        Debug.Log(message);
    }
}
