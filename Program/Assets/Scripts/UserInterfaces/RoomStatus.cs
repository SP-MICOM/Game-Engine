using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomStatus : MonoBehaviourPunCallbacks
{
    [SerializeField] Data data = new Data();

    [SerializeField] TextMeshProUGUI roomNameText;
    [SerializeField] TextMeshProUGUI roomIndexText;
    [SerializeField] TextMeshProUGUI roomPersonnelText;

    [SerializeField] Button button;

    private void Start()
    {
        button.onClick.AddListener(() => PhotonNetwork.JoinRoom(data.Name));
    }

    public void Refresh(RoomInfo roomInfo, int index)
    {
        data.Name = roomInfo.Name;
        data.Index = index + 1;
        data.PlayerCount = roomInfo.PlayerCount;
        data.MaxPlayers = roomInfo.MaxPlayers;

        roomNameText.text = roomInfo.Name;
        roomIndexText.text = data.Index.ToString();
        roomPersonnelText.text = $"({roomInfo.PlayerCount} / {data.MaxPlayers})";
    }
}
