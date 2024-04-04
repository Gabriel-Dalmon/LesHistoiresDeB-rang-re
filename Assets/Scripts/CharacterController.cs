using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxHorizontalVelocity;

    Rigidbody2D m_rigidBody;
    public Vector2 m_velocity;

    // Start is called before the first frame update
    void Start()
    {
        m_velocity = new Vector2(0, 0);
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            m_velocity.x = Mathf.Min(maxHorizontalVelocity, m_velocity.x + 100 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_velocity.x = Mathf.Max(-maxHorizontalVelocity, m_velocity.x + (-100) * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //
            m_rigidBody.velocity = Vector3.zero;
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_rigidBody.AddForce(new Vector2(0, 210), ForceMode2D.Impulse);
        }

        m_rigidBody.velocity = new Vector2(m_velocity.x, m_rigidBody.velocity.y);
        //m_rigidBody.rotation += -m_velocity.x * 40 * Time.deltaTime;
        if (m_velocity.x != 0)
        {
            m_velocity.x = Mathf.Sign(m_velocity.x) * Mathf.Max(0,Mathf.Abs(m_velocity.x) - 10 * Time.deltaTime);
        }
    }
}
