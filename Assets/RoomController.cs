using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    Room myRoom;
    public GameObject nameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void CreateRoom(string name1, string name2, string name3, string name4, int newMemeLocation, int newMemeNum, Material mat)
    {
        Debug.Log(newMemeNum);
        Room myRoom = new Room(name1, name2, name3, name4, newMemeLocation, newMemeNum, mat);
        for( int i = 0; i < 4; i++)
        {
            GameObject roomText = Instantiate(nameText);
            roomText.GetComponent<TextMeshPro>().text = myRoom.names[i];
            roomText.transform.position = roomText.transform.position + Vector3.down*4*i;
        }

        //transform.GetChild(0).gameObject.GetComponent
        
    }


    public class Room
    {
        public string[] names;
        public int memeLocation;
        public int memeNum;
        //public int intMemeFile;
        public Material mat;
        public Room(string name1, string name2, string name3, string name4, int newMemeLocation, int intMeme, Material newMat)
        {
            names = new string[4] { name1, name2, name3, name4 };
            memeLocation = newMemeLocation;
            memeNum = intMeme;
            mat = newMat;
            
        }
    }

}
