﻿using UnityEngine;

/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover: MonoBehaviour {
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] Vector3 velocity;
    private float leftEdge = -9f; 
    void Update() {
        transform.position += velocity * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    public void SetVelocity(Vector3 newVelocity) {
        this.velocity = newVelocity;
    }
   
}

