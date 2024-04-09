using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSnail : MonoBehaviour
{
    public bool test = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            test = true;
        }
    }
}
