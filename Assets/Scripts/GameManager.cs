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

    List<string> bNames = new List<string>();
    List<string> gNames = new List<string>();
    List<room> rooms = new List<room>();

    int numMemes = 4;
    int numRooms = 5;
    // Start is called before the first frame update
    void Start()
    {

        CreateNames();
        for (int i = 0; i < bNames.Count; i++)
        {
            //Debug.Log(gNames[i]);
        }

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
                
                if (name[1] == "F")
                    gNames.Add(name[0]);
                else
                {
                    bNames.Add(name[0]);

                }
            }
                
        }

        System.Random rnd = new System.Random();
        List<int> memeRooms = new List<int>();
        for (int i = 0; i < numMemes; i++)
        {
            bool test = true;
            while (test)
            {
                int num = rnd.Next(12);
                if (!memeRooms.Contains(num))
                {
                    memeRooms.Add(num);
                    test = false;
                }
            }
        }
        for (int i = 0; i < rooms.Count; i++)
        {
            if(rnd.Next() % 2 == 0)
            {
                rooms.Add(new room(removeName(true, rnd.Next(bNames.Count)), removeName(true, rnd.Next(bNames.Count)), removeName(true, rnd.Next(bNames.Count)), removeName(true, rnd.Next(bNames.Count)), (memeRooms.Contains(i)) ? rnd.Next(numRooms) : -1));
            }
            else
            {
                rooms.Add(new room(removeName(false, rnd.Next(gNames.Count)), removeName(false, rnd.Next(gNames.Count)), removeName(false, rnd.Next(gNames.Count)), removeName(false, rnd.Next(gNames.Count)), (memeRooms.Contains(i)) ? rnd.Next(numRooms) : -1));
            }
            
        }

    }
    class room
    {
        public string[] names;
        public int memeLocation;
        public int memeNum;
        public room(string name1, string name2, string name3, string name4, int newMemeLocation)
        {
            string[] names = new string[4];
            names[0] = name1;
            names[1] = name2;
            names[2] = name3;
            names[3] = name4;
            memeLocation = newMemeLocation;
        }
    }
    public string removeName(bool M, int num)
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
}
