using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : SnailController
{
    public Transform shellExitTransform;
    float _maxAngularVelocity = 1000;
    float _velocityMultiplier = 3000;

    public new bool IsGrounded { 
        get => _isGrounded; 
        set {
            _isGrounded = value;
            if(_isGrounded)
            {
                _velocityMultiplier = 3000;
                _rigidBody.gravityScale = 0;
            }
            else
            {
                _velocityMultiplier = 500;
                _rigidBody.gravityScale = 1;
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            _rigidBody.angularVelocity = Mathf.Max(-_maxAngularVelocity, _rigidBody.angularVelocity + (-_velocityMultiplier) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rigidBody.angularVelocity = Mathf.Min(_maxAngularVelocity, _rigidBody.angularVelocity + (_velocityMultiplier) * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _rigidBody.angularDrag *= 16;
        } else if (Input.GetKeyUp(KeyCode.S))
        {
            _rigidBody.angularDrag *= 0.0625f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            _rigidBody.velocity = new Vector2(GetComponent<CircleCollider2D>().radius * -_rigidBody.angularVelocity / 200, 0);
            _rigidBody.AddForce(new Vector2(0, 210), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _rigidBody.gravityScale *= -1;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            _rigidBody.gravityScale = 1 - Mathf.Abs(_rigidBody.gravityScale);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Spike"))
        {
            _isInSpikeTrigger = Mathf.Max(0, _isInSpikeTrigger - 1);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGrounded == false)
        {
            return;
        }
        ContactPoint2D[] contacts = new ContactPoint2D[collision.contactCount];
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (IsGrounded == false) 
        {
            return;
        }
        ContactPoint2D[] contacts = new ContactPoint2D[collision.contactCount];
        collision.GetContacts(contacts);
        for(int i = 0; i < contacts.Length; i++)
        {
            Vector2 stickyForce = new Vector2(contacts[i].point.x - transform.position.x, contacts[i].point.y - transform.position.y).normalized * 10 * Time.deltaTime;
            _rigidBody.velocity += stickyForce;
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