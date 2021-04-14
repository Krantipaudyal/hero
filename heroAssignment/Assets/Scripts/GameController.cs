using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
    #if UNITY_EDITOR
            //Application.Quit();  doesnt work in the editor so
            //UnityEditor.EditorApplication.isPlaying need to be set to  flase

            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
        }
        
    }
}
