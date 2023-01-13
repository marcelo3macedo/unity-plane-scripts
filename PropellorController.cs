using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PropellorController : MonoBehaviour
{
    private float speed = 1000.0f;
    private PlayerController playerController;
    private float rotationPercent;

    void Start()
    {
        playerController = this.GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        if (!playerController) return;

        rotationPercent = this.getSpeedPercent(playerController.speed, playerController.minSpeed, playerController.maxSpeed);
        
        transform.Rotate(Vector3.back, this.speed * Time.deltaTime * rotationPercent);    
    }

    private float getSpeedPercent(float actual, float min, float max)
    {
        float aceleration = actual - min;
        float maxAceleration = max - min;
        return aceleration / maxAceleration;
    }
}
