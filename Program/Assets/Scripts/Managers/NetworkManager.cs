using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform createPosition;

    private void Start()
    {
        Create();
    }

    public void Create()
    {
        PhotonNetwork.Instantiate("Character", createPosition.position, Quaternion.identity);
    }

}