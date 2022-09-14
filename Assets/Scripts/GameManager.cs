//Script:       GameManager
//Author:       Steven Motz
//Date:         9/5/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    List<string> bNames = new List<string>();
    List<string> gNames = new List<string>();
    List<Room> rooms = new List<Room>();
    List<GameObject> objectives = new List<GameObject>();
    public List<Material> mats = new List<Material>();
    public List<Sprite> sprites = new List<Sprite>();

    public GameObject memeObjectivePrefab;
    public GameObject snapchat;

    int numMemes = 4;
    int numMemeFiles = 21;
    int numRooms = 5;
    int intMemesCollected = 0;
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
            int num1 = 0;
            // create room data
            for (int i = 0; i < 12; i++)
            {
                int meme = rnd.Next(mats.Count);
                if (rnd.Next() % 2 == 0)
                {
                    rooms.Add(new Room(RemoveName(true, rnd.Next(bNames.Count)), RemoveName(true, rnd.Next(bNames.Count)), RemoveName(true, rnd.Next(bNames.Count)), RemoveName(true, rnd.Next(bNames.Count)), memeRooms.Contains(i) ? rnd.Next(numRooms) : -1,i,  mats[meme] ));
                }
                else
                {
                    rooms.Add(new Room(RemoveName(false, rnd.Next(gNames.Count)), RemoveName(false, rnd.Next(gNames.Count)), RemoveName(false, rnd.Next(gNames.Count)), RemoveName(false, rnd.Next(gNames.Count)), memeRooms.Contains(i) ? rnd.Next(numRooms) : -1, i, mats[meme]));
                }
                if (memeRooms.Contains(i))
                {
                    GameObject memeObjective = Instantiate(memeObjectivePrefab);
                    memeObjective.transform.SetParent(snapchat.transform);
                    memeObjective.transform.position = new Vector2(900 ,490 - 115*num1);
                    rooms[i].obj = memeObjective;
                    rooms[i].memeSetUp(sprites[meme], rnd.Next(4));
                    num1++;
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
        //public int intMemeFile;
        public Material mat;
        public GameObject obj;
        public Room(string name1, string name2, string name3, string name4, int newMemeLocation, int intMeme, Material newMat)
        {
            names = new string[4] { name1, name2, name3, name4 };
            memeLocation = newMemeLocation;
            memeNum = intMeme;
            mat = newMat;

        }
        public void memeSetUp(Sprite sprite, int num)
        {
            obj.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
            //Debug.Log(obj.transform.GetChild(2).name);
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = names[num];
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


        //GetComponentInChildren<RoomController>().CreateRoom(rooms[0].names[0], rooms[0].names[1], rooms[0].names[2], rooms[0].names[3], rooms[0].memeLocation, rooms[0].memeNum);

        int i = 0;
        foreach (Transform child in transform)
        {
            Debug.Log(child.name);
            child.GetComponent<RoomController>().CreateRoom(rooms[i].names[0], rooms[i].names[1], rooms[i].names[2], rooms[i].names[3], rooms[i].memeLocation, rooms[i].memeNum, rooms[i].mat);
            i++;
        }
        //Debug.Log(rooms[0].names[0]);

    }
    public void collectedMeme(int memeNum)
    {
        foreach (Room room in rooms)
        {
            if(room.memeNum == memeNum)
            {
                room.obj.transform.GetChild(3).gameObject.SetActive(true);
                intMemesCollected++;
                if(intMemesCollected == 4)
                {
                    SceneManager.LoadScene("winscene");
                }
            }
        }
    }
}
