using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemeCollectable : MonoBehaviour
{
    private float rot = .05f;
    public GameObject sideMeme1, sideMeme2;
    private int memeNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, transform.rotation.y + rot, 0f));
    }
    public void SetMemes(Material mat, int num)
    {
        sideMeme1.GetComponent<Renderer>().material = mat;
        sideMeme2.GetComponent<Renderer>().material = mat;
        memeNum = num;
    }
     private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "player" )
        {
            Debug.Log("player");
            GameManager.Instance.collectedMeme(memeNum);
            Destroy(gameObject);
        }
    }
}
