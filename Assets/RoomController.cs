using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    room myRoom;
    public GameObject nameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void CreateRoom(string name1, string name2, string name3, string name4, int newMemeLocation, int newMemeNum)
    {
        room myRoom = new room(name1, name2, name3, name4, newMemeLocation, newMemeNum);
        for( int i = 0; i < 4; i++)
        {
            GameObject roomText = Instantiate(nameText);
            roomText.GetComponent<TextMeshPro>().text = myRoom.names[i];
            roomText.transform.position = roomText.transform.position + Vector3.left*20*i;
        }
        
    }


    public class room
    {
        public string[] names;
        public int memeLocation;
        public int memeNum;
        public room(string name1, string name2, string name3, string name4, int newMemeLocation, int newMemeNum)
        {
             names = new string[4] { name1, name2, name3, name4 };
            memeLocation = newMemeLocation;
            memeNum = newMemeNum;
        }
    }

}
