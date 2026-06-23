using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class RoomPanel : MonoBehaviourPunCallbacks
{
    [SerializeField] int personnel = 0;
    [SerializeField] Toggle[] toggles;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] Button CreateRoomButton;

    public void Start()
    {
        Select();
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = personnel;

        roomOptions.IsOpen = true;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);

        gameObject.SetActive(false);
    }

    public void OnRoomNameChanged()
    {
        CreateRoomButton.interactable = string.IsNullOrWhiteSpace(roomNameInputField.text) == false;
    }

    public void Select()
    {
        for(int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                personnel = i + 2;

                break;
            }
        }
    }
}
