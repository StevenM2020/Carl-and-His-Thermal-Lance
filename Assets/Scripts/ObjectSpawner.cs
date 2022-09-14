using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public bool min90 = true;
    public bool spawnPC = false;
    public List<GameObject> objects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        System.Random r = new System.Random();
        GameObject obj;
        if (spawnPC)
            obj = Instantiate(r.Next(2) == 1 ? objects[objects.Count - 1] : objects[r.Next(objects.Count)]);
        else
             obj = Instantiate(objects[r.Next(objects.Count)]);
        obj.transform.parent = transform;
        obj.transform.position = transform.position;
        if (min90)
        {
            Vector3 rot = new Vector3(-90, transform.rotation.y, transform.rotation.z);
            obj.transform.rotation = Quaternion.Euler(rot);
        }
    }

}
