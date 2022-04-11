using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text pauseText;

    // Start is called before the first frame update
    void Start()
    {
        pauseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseMenu ()
    {
        pauseText.gameObject.SetActive(!pauseText.IsActive());
    }
}
