using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public int powerJump = 500;
    public feet feet;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello world!!!!!!!!!!!!!!!!!!!!!!!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().position += new Vector3(10 * Time.deltaTime, 0 * Time.deltaTime, 0 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().position -= new Vector3(10 * Time.deltaTime, 0 * Time.deltaTime, 0 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && feet.isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * powerJump);
        }

        if (Input.GetKeyDown (KeyCode.E))
        {
            //Sprite sprite = "Circle";
            GameObject go = new GameObject("Ball");
            go.transform.position = new Vector3(0, 0, 0);
            SpriteRenderer truc = go.AddComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer = new SpriteRenderer();
            //go.AddComponent<Rigidbody2D>();
            go.AddComponent<CircleCollider2D>();
        }
        
    }
}
