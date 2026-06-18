using UnityEngine;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class SubScribePanel: MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField[] inputFields = new TMP_InputField[3];

    public void Awake()
    {
        inputFields = GetComponentsInChildren<TMP_InputField>();
    }

    public void Subscribe()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Username = inputFields[0].text,
            Email = inputFields[1].text,
            Password = inputFields[2].text,
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, Sucess, Failed);
    }

    public void Sucess(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        gameObject.SetActive(false);
    }

    public void Failed(PlayFabError playFabError)
    {
        playFabError.GenerateErrorReport();

        PanelManager.Instance.Open(playFabError.GenerateErrorReport());
    }

}