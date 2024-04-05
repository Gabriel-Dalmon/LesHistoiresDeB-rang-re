using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public int powerJump = 5000;
    public int movementSpeed;
    public feet feet;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello world!!!!!!!!!!!!!!!!!!!!!!!");
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentVelocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKey(KeyCode.D))
        {
            currentVelocity.x += movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentVelocity.x -= movementSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = currentVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && feet.isGrounded == true)
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
