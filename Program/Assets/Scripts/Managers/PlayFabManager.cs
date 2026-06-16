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

        StartCoroutine(ConnectRoutine());
    }

    public void Success(GetAccountInfoResult getAccountInfoResult)
    {
        PhotonNetwork.LocalPlayer.NickName = getAccountInfoResult.AccountInfo.Username;
    }

    public void Failed(PlayFabError playFabError)
    {
        Debug.Log(playFabError.GenerateErrorReport());
    }
    
    private IEnumerator ConnectRoutine()
    {
        // Master Server로 연결하는 함수
        PhotonNetwork.ConnectUsingSettings();

        // 서버 연결이 완료되거나 시간이 초과될 때까지 대기합니다.
        while (PhotonNetwork.IsConnectedAndReady == false)
        {
            yield return null;
        }

        // 특정 로비를 생성하여 진입하는 함수
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
