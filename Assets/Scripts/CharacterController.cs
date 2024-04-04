using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxHorizontalVelocity;

    Rigidbody2D m_rigidBody;
    public Vector3 m_velocity;

    // Start is called before the first frame update
    void Start()
    {
        m_velocity = new Vector3(0, 0, 0);
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

        transform.position += m_velocity * Time.deltaTime;
        if(m_velocity.x != 0)
        {
            m_velocity.x = Mathf.Sign(m_velocity.x) * Mathf.Max(0,Mathf.Abs(m_velocity.x) - 10 * Time.deltaTime);
        }
        //m_velocity.x -= Mathf.Sign(m_velocity.x) 2;
    }
}
