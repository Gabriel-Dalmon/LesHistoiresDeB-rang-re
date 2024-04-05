using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SwitchSnail : MonoBehaviour
{
    public GameObject gameObjects = GameObject.Find("Snail");

    

    // Start is called before the first frame update
    void Start()
    {
        print(gameObjects);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameObject.tag == "SnailFull")
            {
                this.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameObject.tag == "SnailFull")
            {
                this.gameObject.SetActive(true);
            }
        }
    }
}
