using System.Collections;
using UnityEngine;

public abstract class SnailController : MonoBehaviour
{
    public int _health = 5;
    public int _speedMultiplier = 1;
    public int _maxSpeedMultiplier = 1;
    protected bool _isGrounded = false;
    protected Rigidbody2D _rigidBody;
    protected Animator _animator;
    protected bool _isInvincible = false;
    protected int _isInSpikeTrigger = 0;
    protected PlantScript _currentPlantScript;

    public virtual int Health
    {
        get { return _health; }
        set { _health = Mathf.Max(value, 0); }
    }

    public virtual bool IsGrounded { get; set; }

    public int SpeedMultiplier { get { return _speedMultiplier; } set { _speedMultiplier = value; } }
    public int MaxSpeedMultiplier { get { return _maxSpeedMultiplier; } set { _maxSpeedMultiplier = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void TakeDamage(int healthPointsToRemove = 1)
    {
        Health--;
        if (Health <= 0)
        {
            Debug.Log("Snail: Dead");
            this.gameObject.SetActive(false);
        }
        else
        {
            _animator.SetTrigger("Hit");
            StartCoroutine(TemporaryInvincibility(5));
        }
    }

    IEnumerator TemporaryInvincibility(float durationInSeconds)
    {
        _isInvincible = true;
        yield return new WaitForSeconds(durationInSeconds);
        _isInvincible = false;
        if (_isInSpikeTrigger > 0)
        {
            TakeDamage();
        }
    }
    void OnTriggerEnter2D(Collider2D other) // Called twice because of the colliders in child entities.
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            if (other.gameObject.activeInHierarchy)
            {
                _currentPlantScript?.RemovePlantEffect(this); //This only prevents the case at start when _currentPlantScript is null,
                                                              //should set a default effect less plant instead
                _currentPlantScript = other.gameObject.GetComponent<PlantScriptLinker>().Get();
                _currentPlantScript.AddPlantEffect(this); // Call plant script to add the plant effect to the player
            }

        }
        else if (other.gameObject.CompareTag("Spike"))
        {
            _isInSpikeTrigger++;
            if (!_isInvincible)
            {
                TakeDamage();
            }
        }
    }
}