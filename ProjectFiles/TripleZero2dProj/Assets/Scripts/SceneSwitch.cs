using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public bool isDeathBox = false;
    public GameObject winMenu;
    public GameObject button1;
    public GameObject button2;


    private void Start()
    {
        winMenu.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDeathBox == true)
        {
            SceneManager.LoadScene(2);
        }
        else if (!isDeathBox)
        {
            winMenu.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }


    public void PlayLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
