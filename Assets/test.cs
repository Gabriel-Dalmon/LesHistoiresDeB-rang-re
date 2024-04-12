using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public int powerJump = 5000;
    public int movementSpeed = 3;
    public feet feet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentVelocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKey(KeyCode.D))
        {
            // !!! THIS CODE WORK ASSUMING THAT THE MOVING OBJECT ALWAYS HAS A PARENT THAT'S A SOFT BODY CONTAINER !!!
            // Changes the direction we are facing to Right if we were facing Left
            // !!!
            if (this.gameObject.GetComponentInParent<SoftBody>().FacingLeft == true)
                this.gameObject.GetComponentInParent<SoftBody>().FacingLeft = false;
            else
                currentVelocity.x += movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.GetComponentInParent<SoftBody>().FacingLeft == false)
                this.gameObject.GetComponentInParent<SoftBody>().FacingLeft = true;
            else
                currentVelocity.x -= movementSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = currentVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && feet.isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * powerJump);
        }

        /*if (Input.GetKeyDown (KeyCode.E))
        {
            //Sprite sprite = "Circle";
            GameObject go = new GameObject("Ball");
            go.transform.position = new Vector3(0, 0, 0);
            SpriteRenderer truc = go.AddComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer = new SpriteRenderer();
            //go.AddComponent<Rigidbody2D>();
            go.AddComponent<CircleCollider2D>();
        }*/
        
    }
}
