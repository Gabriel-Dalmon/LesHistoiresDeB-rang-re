using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public int _health = 5;
    public Transform shellExitTransform;
    public bool isGrounded = false;
    float _maxAngularVelocity = 1000;
    float _velocityMultiplier = 3000;
    Rigidbody2D m_rigidBody;
    bool _isInvincible = false;
    int _isInSpikeTrigger = 0;


    public int Health 
    { 
        get { return _health; } 
        set { _health = Mathf.Max(value, 0); } 
    }

    public bool IsGrounded { 
        get => isGrounded; 
        set {
            isGrounded = value;
            if(isGrounded)
            {
                _velocityMultiplier = 3000;
            }
            else
            {
                _velocityMultiplier = 500;
            }
        } 
    }

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

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            m_rigidBody.velocity = new Vector2(GetComponent<CircleCollider2D>().radius * -m_rigidBody.angularVelocity / 200, 0);
            m_rigidBody.AddForce(new Vector2(0, 210), ForceMode2D.Impulse);
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("plant"))
        {
            Debug.Log("Snail: Eating Plant");
            other.gameObject.SetActive(false);
            _velocityMultiplier *= 2;
            _maxAngularVelocity *= 1.4f;
        } else if(other.gameObject.CompareTag("Spike"))
        {
            _isInSpikeTrigger++;
            TakeDamage();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Spike"))
        {
            _isInSpikeTrigger--;
        }
    }

    void TakeDamage(int healthPointsToRemove = 1)
    {
        Health--;
        if (Health <= 0)
        {
            Debug.Log("Snail: Dead");
            this.gameObject.SetActive(false);
        } else
        {
            GetComponent<Animator>().SetTrigger("Hit");
            StartCoroutine(TemporaryInvincibility(5));
        }
    }

    IEnumerator TemporaryInvincibility(float durationInSeconds)
    {
        _isInvincible = true;
        yield return new WaitForSeconds(durationInSeconds);
        _isInvincible = false;
        if(_isInSpikeTrigger > 0)
        {
            TakeDamage();
        }
    }
}