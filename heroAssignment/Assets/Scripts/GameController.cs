using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private int maxPlanes = 10;
    private int numberofPlanes = 0;
   // public gameObject Plane;
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

        if(numberofPlanes < maxPlanes)
        {
            //Bounds myBound = GetComponent <Renderer>().bounds;
            CameraSupport s = Camera.main.GetComponent<CameraSupport>();
            GameObject e = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject);
            Vector3 pos;
            pos.x = s.GetWorldBounds().min.x + Random.value * s.GetWorldBounds().size.x;
            pos.y = s.GetWorldBounds().min.y + Random.value * s.GetWorldBounds().size.y;
            pos.z = 0;
            e.transform.localPosition = pos;
            ++numberofPlanes;

        }
        
    }
    public void EnemyDestroyed()
    {
        --numberofPlanes; //decreases the current number of planes when destroyed
    }
}
