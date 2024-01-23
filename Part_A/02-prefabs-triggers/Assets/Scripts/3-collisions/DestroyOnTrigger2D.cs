using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] string aim;
    


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);

        }
        if (other.tag == aim && enabled)
        {
            Debug.Log("Enemy object hit player");
            Health health  = other.transform.GetComponent<Health>();
            ShieldThePlayer shild = other.transform.GetComponent<ShieldThePlayer>();
            if (health != null)
            {
               health.Hit(1);
                
            }
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }
}
