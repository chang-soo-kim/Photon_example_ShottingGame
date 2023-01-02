using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class MyRoom : MonoBehaviourPunCallbacks
{
    //게임 버전
    private readonly string gameVersion = "1";
    public TextMeshProUGUI connectionInfoText;
    public Button joinButton;
    RoomOptions room = new RoomOptions();
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        //버튼 입력 비활성화
        joinButton.interactable = false;
        connectionInfoText.text = "Online : Connected to Master Server";

    }
    //마스터 서버에 연결이 되었을때 실행
    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "Online : Connected to Master Server";
    }
    //마스터서버의 연결이 실패했을때 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = $"offline : Connection Disabled {cause.ToString()}-Try reconnecting...";

        PhotonNetwork.ConnectUsingSettings();
    }

    //접속 버튼을 눌렀을때
    public void Connected()
    {
        joinButton.interactable = false;
        room.MaxPlayers = 2;

        //마스터서버와 연결되어있을때 
        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "Connecting to Random Room...";
            byte maxPlayers = byte.Parse("2");
            room.MaxPlayers = maxPlayers;
            room.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();

            PhotonNetwork.JoinRandomOrCreateRoom(
                      expectedCustomRoomProperties: new ExitGames.Client.Photon.Hashtable(), expectedMaxPlayers: maxPlayers, // 참가할 때의 기준.
                      roomOptions: room // 생성할 때의 기준.
                  );
        }
        else
        {
            connectionInfoText.text = "offline : Connection Disabled -Try reconnecting...";

            PhotonNetwork.ConnectUsingSettings();
        }

    }

    //방참가가 되면 자동으로 실행되는 메서드
    //public override void OnJoinedRoom()
    //{



    //    Debug.Log("현재 방 인원수" + PhotonNetwork.CurrentRoom.PlayerCount);
    //    Debug.Log("맥스 방 인원수" + PhotonNetwork.CurrentRoom.MaxPlayers);


    //}

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        connectionInfoText.text = "metching";

        if (PhotonNetwork.IsMasterClient)
        {
            connectionInfoText.text = "Connected with Room.";
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
                PhotonNetwork.LoadLevel("GameScene");
            }
        }
    }






}