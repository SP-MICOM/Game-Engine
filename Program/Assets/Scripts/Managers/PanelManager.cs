using UnityEngine;
using System.Collections.Generic;

public class PanelManager : Singleton<PanelManager>
{
    [SerializeField] GameObject clone = null;

    Dictionary<Panel, GameObject> dictionary = new Dictionary<Panel, GameObject>();
    
    public void Open(Panel panel)
    {
        if (dictionary.TryGetValue(panel, out clone) == false)
        {
            clone = (GameObject)Instantiate(Resources.Load(panel.ToString()));

            clone.name = clone.name.Replace("(Clone)", "");

            dictionary.Add(panel, clone);

            DontDestroyOnLoad(clone);
        }
        else
        {
            clone = dictionary[panel];

            clone.SetActive(true);
        }
    }

    public void Open(Panel panel, string message)
    {
        if (dictionary.TryGetValue(panel, out clone) == false)
        {
            clone = (GameObject)Instantiate(Resources.Load(panel.ToString()));

            clone.name = clone.name.Replace("(Clone)", "");

            dictionary.Add(panel, clone);

            DontDestroyOnLoad(clone);
        }
        else
        {
            clone = dictionary[panel];

            clone.SetActive(true);
        }

        clone.GetComponent<ErrorPanel>().SetMessage(message);
    }

}
