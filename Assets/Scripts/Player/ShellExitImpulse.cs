using UnityEngine;

public class ShellExitImpulse : MonoBehaviour
{
    public ShellController _shellController;
    public AudioClip[] _spittingSounds;
    public AudioClip _bubblesSound;
    public float _COOLDOWN;
    public int _COUNT;
    int _remainingCount;
    float _remainingCooldown = 0;

    Rigidbody2D _rigidBody;
    ParticleSystem _particleSystem;
    AudioSource[] _audioSources;
    // Start is called before the first frame update
    void Start()
    {
        _shellController.remainingSpitCount = _COUNT;
        _rigidBody = _shellController.GetComponent<Rigidbody2D>();
        _particleSystem = GetComponent<ParticleSystem>();
        _audioSources = GetComponents<AudioSource>();
        if(_audioSources.Length < 2)
        {
            Debug.LogWarning("Not enough audio sources found in ShellExitImpulse");
        } else
        {
            _audioSources[0].clip = _bubblesSound;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _remainingCooldown <= 0 && _shellController.remainingSpitCount != 0) //Negative = unlimited
        {
            _audioSources[0].Play();
            _audioSources[1].clip = _spittingSounds[Random.Range(0, _spittingSounds.Length)];
            _audioSources[1].Play();
            _particleSystem.Play();
            float angle = Mathf.Deg2Rad * transform.eulerAngles.z;
            Vector2 force = new Vector2((float)Mathf.Cos(angle), (float)Mathf.Sin(angle)).normalized * 250;
            //_rigidBody.AddForceAtPosition(force, transform.position, ForceMode2D.Impulse);
            _rigidBody.velocity = _rigidBody.velocity * 0.2f;//Vector2.zero;
            _rigidBody.AddForce(force, ForceMode2D.Impulse);
            _shellController.remainingSpitCount--;
            _remainingCooldown = _COOLDOWN;
        }
        _remainingCooldown -= Time.deltaTime;
    }
}
