using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    public Camera cameraComponent;
    float initialSize;
    bool isActive = false;
    bool isLerping = false;
    public float lerpDuration = 5.0f;
    float lerpStartTime;

    void Update()
    {
        float timeSinceStarted = Time.time - lerpStartTime;
        float percentageComplete = timeSinceStarted / lerpDuration;
        if(isLerping) { 
            if (isActive)
            {
                cameraComponent.orthographicSize = Mathf.Lerp(cameraComponent.orthographicSize, 15.0f, percentageComplete);
            }
            else
            {
                cameraComponent.orthographicSize = Mathf.Lerp(cameraComponent.orthographicSize, initialSize, percentageComplete);
            }

            if(percentageComplete >= 1.0f)
            {
                isLerping = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isActive == false)
        {
            initialSize = cameraComponent.orthographicSize;
            isActive = true;
            lerpStartTime = Time.time;
            isLerping = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isActive == true)
        {
            isActive = false;
            lerpStartTime = Time.time;
            isLerping = true;
        }
    }
}
