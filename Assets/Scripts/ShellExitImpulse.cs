using UnityEngine;

public class ShellExitImpulse : MonoBehaviour
{
    public ShellController shellController;
    public AudioClip[] spittingSounds;
    public AudioClip bubblesSound;

    Rigidbody2D _rigidBody;
    ParticleSystem _particleSystem;
    AudioSource[] _audioSources;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = shellController.GetComponent<Rigidbody2D>();
        _particleSystem = GetComponent<ParticleSystem>();
        _audioSources = GetComponents<AudioSource>();
        if(_audioSources.Length < 2)
        {
            Debug.LogWarning("Not enough audio sources found in ShellExitImpulse");
        } else
        {
            _audioSources[0].clip = bubblesSound;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _audioSources[0].Play();
            _audioSources[1].clip = spittingSounds[Random.Range(0, spittingSounds.Length)];
            _audioSources[1].Play();
            _particleSystem.Play();
            float angle = Mathf.Deg2Rad * transform.eulerAngles.z;
            Vector2 force = new Vector2((float)Mathf.Cos(angle), (float)Mathf.Sin(angle)).normalized * 200;
            //_rigidBody.AddForceAtPosition(force, transform.position, ForceMode2D.Impulse);
            _rigidBody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
