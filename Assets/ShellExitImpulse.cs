using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExitImpulse : MonoBehaviour
{
    public ShellController shellController;
    Rigidbody2D m_rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = shellController.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            float angle = Mathf.Deg2Rad * transform.eulerAngles.z;
            Vector2 force = new Vector2((float)Mathf.Cos(angle), (float)Mathf.Sin(angle)).normalized * 200;
            m_rigidBody.AddForceAtPosition(force, transform.position, ForceMode2D.Impulse);
            //m_rigidBody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
