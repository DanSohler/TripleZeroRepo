using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    public string resetSceneTo;
    
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(resetSceneTo);
        }
    }
}
