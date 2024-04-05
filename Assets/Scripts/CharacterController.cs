using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    int _health = 5;
    float _maxAngularVelocity;
    float _velocityMultiplier = 3000;

    public int Health { get { return _health; }, set { _health = Mathf.Max(value,0); } }

    Rigidbody2D m_rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            m_rigidBody.angularVelocity = Mathf.Max(-_maxAngularVelocity, m_rigidBody.angularVelocity + (-_velocityMultiplier) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_rigidBody.angularVelocity = Mathf.Min(_maxAngularVelocity, m_rigidBody.angularVelocity + (_velocityMultiplier) * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidBody.velocity = new Vector2(GetComponent<CircleCollider2D>().radius * -m_rigidBody.angularVelocity / 200, 0);
            m_rigidBody.AddForce(new Vector2(0, 210), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
        if(other.gameObject.CompareTag("plant"))
        {
            Debug.Log("Snail: Eating Plant");
            _velocityMultiplier *= 2;
            _maxAngularVelocity *= 1.4f;
        } else if(other.gameObject.CompareTag("Spike"))
        {
            Health--;
        }
    }

    void TakeDamage(int healthPointsToRemove = 1)
    {
        Health--;
        if (Health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
