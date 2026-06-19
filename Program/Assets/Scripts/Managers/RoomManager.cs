using Photon.Pun;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    public override void OnRoomListUpdate(List<RoomInfo> roomIist)
    { 

    }
}
