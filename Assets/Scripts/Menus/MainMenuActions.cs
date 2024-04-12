using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Assets/Scenes/TestingScene.unity");
    }

    public void OnHover(Image button, Sprite sprite)
    {
        button.sprite = sprite;
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
