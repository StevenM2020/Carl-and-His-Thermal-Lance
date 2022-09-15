using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject stopPlayerCube;
    public GameObject sparksObject;
    private float waitTime = 3;
    private float openDoorTime = 2.5f;
    private float sparksTime = 2f;
    private bool isDoorOpen = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Carl" && isDoorOpen == false)
        {
            StartCoroutine(cutDoor());
            isDoorOpen = true;
            if(GameObject.Find("Carl").GetComponent<PlayerComtroller>() != null)
            {
                GameObject.Find("Carl").GetComponent<PlayerComtroller>().pausePlayer(waitTime + openDoorTime + sparksTime);
            }
        }
    }

    IEnumerator cutDoor()
    {


        yield return new WaitForSeconds(waitTime);
        sparksObject.SetActive(true);
        yield return new WaitForSeconds(sparksTime);
        GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(openDoorTime);
        stopPlayerCube.SetActive(false);

    }
}
