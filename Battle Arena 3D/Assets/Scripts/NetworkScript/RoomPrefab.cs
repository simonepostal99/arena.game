using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomPrefab : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI roomName;
    [SerializeField] int roomId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void SetRoomName(string value)
    {
        roomName.text = value;
    }

    public void SetRoomId(int value)
    {
        roomId = value;
    }

    public void Join()
    {
        GameLobby.instance.JoinButton(roomId);
    }
}
