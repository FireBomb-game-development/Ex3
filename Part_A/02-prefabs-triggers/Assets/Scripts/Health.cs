using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
   [SerializeField] int HP;
   [SerializeField] int  barSize;
   [SerializeField] Image[] bar;
   [SerializeField] Sprite fullHeart;
   [SerializeField] Sprite emptyHeart;
   [SerializeField] int duration;
   [Tooltip("Every object tagged with this tag will trigger game over")]
   [SerializeField] string triggeringTag;
    static bool shild = false;


    // Start is called before the first frame update

    void Start()
    {
        
    }
    public void Hit(int damage)
    {
        
        
        
        float currentTimeScale = Time.timeScale;
        Debug.Log("Current Time Scale: " + currentTimeScale);
        if (!shild)
        {
            HP -= damage;


            Debug.Log("Shield on!");
            shild = true;

            //for (int i = 0; i < duration; i++)
            //{
               
            //    yield return new WaitForSeconds(1);
            //}

            Debug.Log("Shield gone!");
            shild = false;

        }

        
    }




    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bar.Length; i++)
        {
            if(i< HP)
            {
                bar[i].sprite = fullHeart;
            }
            else
            {
                bar[i].sprite = emptyHeart;
            }
            if (i < barSize)
            {
                bar[i].enabled = true;
            }
            else
            {
                bar[i].enabled = false;

            }
        }
        if (HP <= 0)
        {

            Destroy(gameObject);

            Debug.Log("Game over!");
            Application.Quit();
            // UnityEditor.EditorApplication.isPlaying = false;  # Error on editor 2021.3
        }
    


    }
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == triggeringTag && enabled)
        {
            
            if (!shild)
            {

                shild = true;
                Debug.Log("Shield on!");

                for (float i = duration; i > 0; i--)
                {
                    Debug.Log("Shield: " + i + " seconds remaining!");
                    yield return new WaitForSeconds(1);       // co-routines
                }
                Debug.Log("Shield gone!");
                shild = false;
            }
        }
    }
}
