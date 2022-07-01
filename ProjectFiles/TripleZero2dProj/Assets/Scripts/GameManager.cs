using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject instructionImage;
    public bool pauseActive = false;


    // Start is called before the first frame update
    void Start()
    {
        instructionImage.gameObject.SetActive(false);
        pauseActive = false;
    }

    public void OpenPauseMenu()
    {
        instructionImage.gameObject.SetActive(true);
        pauseActive = true;
    }

    public void ClosePauseMenu()
    {
        instructionImage.gameObject.SetActive(false);
        pauseActive = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
