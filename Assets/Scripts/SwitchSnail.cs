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
        
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Shell.activeSelf)
            {
                camera.GetComponent<CameraController>().parentTransform = Snail.transform;

                Snail.GetComponent<Transform>().position = Shell.GetComponent<Transform>().position;
                Shell.SetActive(!Shell.activeSelf);
                Snail.SetActive(!Snail.activeSelf);
            } else if  (! Shell.activeSelf)
            {
                camera.GetComponent<CameraController>().parentTransform = Shell.transform;

                Shell.GetComponent<Transform>().position = Snail.GetComponent<Transform>().position;
                Shell.SetActive(!Shell.activeSelf);
                Snail.SetActive(!Snail.activeSelf);
            }
        }
    }
}
