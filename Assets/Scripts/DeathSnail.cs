using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSnail : MonoBehaviour
{
    public GameObject snail;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            snail.GetComponent<Transform>().position = new Vector3(-3, -3, 0);
        }
    }
}
