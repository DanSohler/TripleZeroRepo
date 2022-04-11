using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text pauseText;
    [SerializeField]
    private Image instructionImage;
    [SerializeField]
    private Button resume;
    [SerializeField]
    private Button quit;


    // Start is called before the first frame update
    void Start()
    {
        pauseText.gameObject.SetActive(false);
        instructionImage.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseMenu ()
    {
        pauseText.gameObject.SetActive(!pauseText.IsActive());
        instructionImage.gameObject.SetActive(!instructionImage.IsActive());
        resume.gameObject.SetActive(!resume.IsActive());
        quit.gameObject.SetActive(!quit.IsActive());
    }
}
