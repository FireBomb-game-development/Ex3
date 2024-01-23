using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component spawns the given object whenever the player clicks a given key.
 */
public class ClickSpawner: MonoBehaviour {
    [SerializeField] protected InputAction spawnAction = new InputAction(type: InputActionType.Button);
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;
    [SerializeField] protected int duration ;
    [SerializeField] public  bool delay;
    


    void OnEnable()  {
        spawnAction.Enable();
    }

    void OnDisable()  {
        spawnAction.Disable();
    }

    protected virtual GameObject spawnObject() {
        Debug.Log("Spawning a new object");

        // Step 1: spawn the new object.
        if (delay)
        {
            delayHandler();
        }
        else
        {

            Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
            Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
            GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);
            delay = true;

            // Step 2: modify the velocity of the new object.
            Mover newObjectMover = newObject.GetComponent<Mover>();
            if (newObjectMover)
            {
                newObjectMover.SetVelocity(velocityOfSpawnedObject);
            }

            return newObject;


        }
        return null;

    }
    
    IEnumerator ExampleCoroutine(int n)
    {
        
        yield return new WaitForSeconds(n);

    }
    private void delayHandler(){
        if (delay)
        {
            StartCoroutine(ExampleCoroutine(duration));
            delay = false;

        }

    }

    private void Update()
    {
        
        if (spawnAction.WasPressedThisFrame()) {
        
           
                spawnObject();
          

        }
        


    }
}
