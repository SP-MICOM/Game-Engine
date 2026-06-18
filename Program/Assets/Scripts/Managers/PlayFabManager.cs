using UnityEngine;
using Photon.Pun;
using PlayFab.ClientModels;
using TMPro;
using PlayFab;
using System.Collections;

public class PlayFabManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string version;
    [SerializeField] TMP_InputField addressInputField;
    [SerializeField] TMP_InputField passwordInputField;

    public void Request()
    {
        PlayFabSettings.staticSettings.TitleId = "133089";

        var request = new LoginWithEmailAddressRequest
        {
            Email = addressInputField.text,
            Password = passwordInputField.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request,Success, Failed);
    }

    public void Success(LoginResult loginResult)
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), Success, Failed);

        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = version;

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void Success(GetAccountInfoResult getAccountInfoResult)
    {
        PhotonNetwork.LocalPlayer.NickName = getAccountInfoResult.AccountInfo.Username;
    }

    public void Failed(PlayFabError playFabError)
    {
        PanelManager.Instance.Open(Panel.Error, playFabError.GenerateErrorReport());
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
