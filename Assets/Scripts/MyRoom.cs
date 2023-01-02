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
    //���� ����
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

        //��ư �Է� ��Ȱ��ȭ
        joinButton.interactable = false;
        connectionInfoText.text = "Online : Connected to Master Server";

    }
    //������ ������ ������ �Ǿ����� ����
    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "Online : Connected to Master Server";
    }
    //�����ͼ����� ������ ���������� ����
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = $"offline : Connection Disabled {cause.ToString()}-Try reconnecting...";

        PhotonNetwork.ConnectUsingSettings();
    }

    //���� ��ư�� ��������
    public void Connected()
    {
        joinButton.interactable = false;
        room.MaxPlayers = 2;

        //�����ͼ����� ����Ǿ������� 
        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "Connecting to Random Room...";
            byte maxPlayers = byte.Parse("2");
            room.MaxPlayers = maxPlayers;
            room.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();

            PhotonNetwork.JoinRandomOrCreateRoom(
                      expectedCustomRoomProperties: new ExitGames.Client.Photon.Hashtable(), expectedMaxPlayers: maxPlayers, // ������ ���� ����.
                      roomOptions: room // ������ ���� ����.
                  );
        }
        else
        {
            connectionInfoText.text = "offline : Connection Disabled -Try reconnecting...";

            PhotonNetwork.ConnectUsingSettings();
        }

    }

    //�������� �Ǹ� �ڵ����� ����Ǵ� �޼���
    //public override void OnJoinedRoom()
    //{



    //    Debug.Log("���� �� �ο���" + PhotonNetwork.CurrentRoom.PlayerCount);
    //    Debug.Log("�ƽ� �� �ο���" + PhotonNetwork.CurrentRoom.MaxPlayers);


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