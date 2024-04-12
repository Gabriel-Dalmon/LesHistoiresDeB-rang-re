using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SwitchSnail : MonoBehaviour
{
    public GameObject Shell;
    public GameObject Snail;

    public GameObject camera;
       

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Shell.activeSelf)
            {
                camera.GetComponent<CameraController>().parentTransform = Snail.transform;

                Snail.transform.position = Shell.GetComponent<Transform>().position;
                Snail.transform.eulerAngles = new Vector3(0, 0, 0);
                Snail.GetComponent<Rigidbody2D>().velocity = Shell.GetComponent<Rigidbody2D>().velocity;
                Shell.SetActive(false);
                Snail.SetActive(true);
            } else if  (! Shell.activeSelf)
            {
                camera.GetComponent<CameraController>().parentTransform = Shell.transform;

                Shell.GetComponent<Transform>().position = Snail.GetComponent<Transform>().position;
                Shell.GetComponent<Rigidbody2D>().velocity = Snail.GetComponent<Rigidbody2D>().velocity;
                Shell.transform.eulerAngles = Snail.transform.eulerAngles;
                Shell.SetActive(!Shell.activeSelf);
                Snail.SetActive(!Snail.activeSelf);
            }
        }
    }
}
