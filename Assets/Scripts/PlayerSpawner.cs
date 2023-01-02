using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawner : MonoBehaviourPun
{
    [SerializeField]Transform[] PlayerPos;

    private void Start()
    {

        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        int PlayerIndex = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        GameObject instPlayer = PhotonNetwork.Instantiate("Player", PlayerPos[PlayerIndex].position, PlayerPos[PlayerIndex].rotation);

        Camera.main.transform.SetParent(instPlayer.transform);
        Camera.main.transform.rotation = PlayerPos[PlayerIndex].rotation;
        Camera.main.transform.localPosition = new Vector3(0, 0.5f, 0.5f);

    }
}
