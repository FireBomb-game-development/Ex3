//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class GameOverOnTrigger2D : MonoBehaviour
//{
//    [Tooltip("Every object tagged with this tag will trigger game over")]
//    [SerializeField] string triggeringTag;
    
   
//    bool shild = false;
//    Health stats;
//    private void Start()
//    {  
//        stats = gameObject.GetComponent<Health>();
//    }



//    public void damage()
//    {

//        if (stats.hit(1)<=0)
//        {
            
//            Destroy(gameObject);
            
//            Debug.Log("Game over!");
//            Application.Quit();
//            // UnityEditor.EditorApplication.isPlaying = false;  # Error on editor 2021.3
//        }
//        else
//        {
//            Debug.Log("player hp reduece by 1");
//        }


//    }
//    private IEnumerator OnTriggerEnter2D(Collider2D other) {
        

//        if (other.tag == triggeringTag && enabled) {

//            if (!shild)
//            {
//                damage();

//                shild = true;
//                Debug.Log("Shield on!");

//                for (float i = 3; i > 0; i--)
//                {
//                    Debug.Log("Shield: " + i + " seconds remaining!");
//                    yield return new WaitForSeconds(1);       // co-routines
//                }
//                Debug.Log("Shield gone!");
//                shild = false;
//            }
//        }
//    }


//    private void Update() {
//        /* Just to show the enabled checkbox in Editor */
//    }

//}
