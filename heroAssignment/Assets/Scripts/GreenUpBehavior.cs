using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenUpBehavior : MonoBehaviour
{

    public Text mEnemyCountTexxt = null;
    private int mPlanesTouched = 0;

    public float speed = 20f;
    public float mHeroRotateSpeed = 90f/2f; //90 degrees in 2 sec

    public float cooldown = 0.2f; // .2 seconds of cooldown
    public float fireNext = 0f;
    public bool mFollowMousePosition  = false; 

    private GameController mGameController = null;

    // Start is called before the first frame update
    void Start()
    {
        mGameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
 void Update()
    {
         Vector3 pos = transform.position;

        if(Input.GetKeyDown(KeyCode.M))
        {
            mFollowMousePosition = !mFollowMousePosition;

        }

        if(mFollowMousePosition)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f; //
        }
        else{

            if (Input.GetKey(KeyCode.W))
            {
                pos += ((speed * Time.smoothDeltaTime) * transform.up);
            }

            if (Input.GetKey(KeyCode.S))
            {
                pos -= ((speed * Time.smoothDeltaTime) * transform.up);        }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
                //transform.Rotate(0,0,-mHeroRotateSpeed*Time.smoothDeltaTime);

            
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
                //transform.Rotate(0,0,mHeroRotateSpeed*Time.smoothDeltaTime);

            }
        }
        triggerEggs();
        transform.position = pos;
    }

    private void triggerEggs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > fireNext )
        {
            // Prefab MUST BE locaed in Resources/Prefab folder!
            GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); 
            e.transform.localPosition = transform.localPosition;
            e.transform.rotation = transform.rotation;
            fireNext = Time.time + cooldown;
        }
    }

    private void onTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hero X Plane: onTriggerEnter2D");
        if(collision.gameObject.tag == "Enemy")
        {
            mPlanesTouched += 1;
           // mEnemyCountTexxt = " Planes touched = " + mPlanesTouched;
            Destroy(collision.gameObject);
            mGameController.EnemyDestroyed();
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class GreenUpBehaviour : MonoBehaviour
// {
//     public Text mEnemyCountText = null;
//     public float speed = 10f;
//     public float mHeroRotateSpeed = 100f / 2f; // 90-degrees in 2 seconds
//     public bool mFollowMousePosition = true;
//     // Start is called before the first frame update

//     private int mPlanesTouched = 0;

//     private GameController mGameGameController = null;

//     void Start()
//     {
//         mGameGameController = FindObjectOfType<GameController>();
//     }

//     // Update is called once per frame

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.M))
//         {
//             mFollowMousePosition = !mFollowMousePosition;
//         }
//         Vector3 pos = transform.position;

//         if (mFollowMousePosition)
//         {
//             pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             // Debug.Log("Position is " + pos);
//             pos.z = 0f;  // <-- this is VERY IMPORTANT!
//             // Debug.Log("Screen Point:" + Input.mousePosition + "  World Point:" + p);
//         }
//         else
//         {
//             if (Input.GetKey(KeyCode.W))
//             {
//                 pos += ((speed * Time.smoothDeltaTime) * transform.up);
//             }

//             if (Input.GetKey(KeyCode.S))
//             {
//                 pos -= ((speed * Time.smoothDeltaTime) * transform.up);
//             }

//             if (Input.GetKey(KeyCode.D))
//             {
//                 transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);
//             }

//             if (Input.GetKey(KeyCode.A))
//             {
//                 transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);
//             }
//         }
//         if (Input.GetKey(KeyCode.Space))
//         {
//             // Prefab MUST BE locaed in Resources/Prefab folder!
//             GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); 
//             e.transform.localPosition = transform.localPosition;
//             e.transform.rotation = transform.rotation;
//             Debug.Log("Spawn Eggs:" + e.transform.localPosition);
//         }
//         transform.position = pos;
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         Debug.Log("Here x Plane: OnTriggerEnter2D");
//         mPlanesTouched = mPlanesTouched + 1;
//         mEnemyCountText.text = "Planes touched = " + mPlanesTouched;
//         Destroy(collision.gameObject);
//         mGameGameController.EnemyDestroyed();
//     }

//     private void OnTriggerStay2D(Collider2D collision) 
//     {
//         Debug.Log("Here x Plane: OnTriggerStay2D");
//     }
// }