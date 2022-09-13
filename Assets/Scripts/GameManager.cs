//Script:       GameManager
//Author:       Steven Motz
//Date:         9/5/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    List<string> bNames = new List<string>();
    List<string> gNames = new List<string>();
    List<Room> rooms = new List<Room>();

    int numMemes = 4;
    int numRooms = 5;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        CreateNames();
        for (int i = 0; i < bNames.Count; i++)
        {
            //Debug.Log(gNames[i]);
        }
        SendDataToChildren();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateNames()
    {

        if (File.Exists("Assets/Scripts/yob2021.txt"))
        {
            // Read a text file line by line.  
            string[] lines = File.ReadAllLines("Assets/Scripts/yob2021.txt");
            foreach (string line in lines)
            {
                String[] name = line.Split(',');

                if (name[1] == "F") // seperate gender
                    gNames.Add(name[0]);
                else
                {
                    bNames.Add(name[0]);

                }
            }



            System.Random rnd = new System.Random();
            List<int> memeRooms = new List<int>();
            
            //pick meme rooms
            for (int i = 0; i < numMemes; i++)
            {
                bool test = true;
                while (test) // test for multibles
                {
                    int num = rnd.Next(12);
                    if (!memeRooms.Contains(num))
                    {
                        memeRooms.Add(num);
                        test = false;
                    }
                }
            }

            // create room data
            for (int i = 0; i < 12; i++)
            {
                if (rnd.Next() % 2 == 0)
                {
                    rooms.Add(new Room(RemoveName(true, rnd.Next(bNames.Count)), RemoveName(true, rnd.Next(bNames.Count)), RemoveName(true, rnd.Next(bNames.Count)), RemoveName(true, rnd.Next(bNames.Count)), memeRooms.Contains(i) ? rnd.Next(numRooms) : -1));
                }
                else
                {
                    rooms.Add(new Room(RemoveName(false, rnd.Next(gNames.Count)), RemoveName(false, rnd.Next(gNames.Count)), RemoveName(false, rnd.Next(gNames.Count)), RemoveName(false, rnd.Next(gNames.Count)), memeRooms.Contains(i) ? rnd.Next(numRooms) : -1));
                }

            }
            //Debug.Log(rooms[0].newNames[0]);
        }
        
    }
     class Room
    {
        public string[] names;
        public int memeLocation;
        public int memeNum;
        public Room(string name1, string name2, string name3, string name4, int newMemeLocation)
        {
            names = new string[4] {name1,name2, name3, name4};
            memeLocation = newMemeLocation;
            memeNum = 1;
        }
    }

    public string RemoveName(bool M, int num) // return the name and remove from list
    {
        string name;
        if (M)
        {
            name = bNames[num];
            bNames.RemoveAt(num);
        }
        else
        {
            name = gNames[num];
            gNames.RemoveAt(num);
        }
        return name;
    }

    public void SendDataToChildren() // send data to the room creators
    {
        for (int i = 0; i < 12; i++)
        {
            GetComponentInChildren<RoomController>().CreateRoom(rooms[0].names[0], rooms[0].names[1], rooms[0].names[2], rooms[0].names[3], rooms[0].memeLocation, rooms[0].memeNum);
        }
        //Debug.Log(rooms[0].names[0]);
       
    }
    public void collectedMeme(int memeNum)
    {

    }
}
