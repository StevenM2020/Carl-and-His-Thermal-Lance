using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject stopPlayerCube;
    public GameObject sparksObject;
    private float waitTime = 10;
    private float openDoorTime = 2.5f;
    private bool isDoorOpen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        StartCoroutine(cutDoor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "player" && isDoorOpen == false)
        {
            StartCoroutine(cutDoor());
            isDoorOpen = true;
        }
    }

    IEnumerator cutDoor()
    {

        Debug.Log("start1");
        yield return new WaitForSeconds(waitTime);
        sparksObject.SetActive(true);
        GetComponent<Animator>().enabled = true;
        Debug.Log("start2");
        yield return new WaitForSeconds(openDoorTime);
        stopPlayerCube.SetActive(false);
        Debug.Log("start3");
    }
}
