using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Bump : MonoBehaviour
{
    public bool isBounced;
    private bool bounce;

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounce")
        {
            collision.transform.parent.GetComponent<Animator>().SetTrigger("Bounce");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bounce)
        {

        }        
    }
}
