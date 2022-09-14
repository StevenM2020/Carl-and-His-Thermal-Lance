using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeSpawner : MonoBehaviour
{
    public GameObject memePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawn(Material mat, int num)
    {
        GameObject collectable = Instantiate(memePrefab);
        collectable.GetComponent<MemeCollectable>().SetMemes(mat, num);

    }
}
