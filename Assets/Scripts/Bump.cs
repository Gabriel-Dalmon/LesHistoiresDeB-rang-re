using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Bump : MonoBehaviour
{
    public bool isBounced;
    public Rigidbody2D rb;
    public float launchForce = 2.0f;

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounce")
        {
            collision.transform.parent.GetComponent<Animator>().SetTrigger("Bounce");
            rb.AddForce(Vector2.up * launchForce); 
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounce")
        {
            isBounced = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounce")
        {
            isBounced = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isBounced)
        {
                //bounce.SetTrigger("")
            

        }        
    }
}
