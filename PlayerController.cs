using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12.0f;
    public float minSpeed = 8.0f;
    public float maxSpeed = 20.0f;
    private float turnSpeed = 60.0f;
    private float defaultTurnSpeed = 60.0f;
    private float stallSpeed = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        this.applyTurning();
        this.applyHorizontalRotate();
        this.applyVerticalRotate();

        this.speed = this.getUpdatedSpeed();
        this.applyStall();
        this.applyMoving();
    }

    private void applyTurning()
    {
        float fire1Input = Input.GetAxis("Fire1");
        float fire2Input = Input.GetAxis("Fire2");
        float result = fire1Input > 0 ? -1 : 1;

        if (fire1Input == fire2Input) return;

        this.rotate(Vector3.up, result);
    }

    private void applyHorizontalRotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        this.rotate(Vector3.forward, horizontalInput * -1);
    }

    private void applyVerticalRotate()
    {
        float verticalInput = Input.GetAxis("Vertical");

        this.rotate(Vector3.left, verticalInput * -1);
    }

    private float getUpdatedSpeed()
    {
        float jumpInput = Input.GetAxis("Jump");
        float factor = jumpInput > 0 ? 1 : -1;
        float speedUpdate = factor * Time.deltaTime;
        float newSpeed = this.speed + speedUpdate;

        if (newSpeed > maxSpeed || newSpeed < minSpeed)
        {
            return this.speed;
        }

        return newSpeed;
    }

    private void applyMoving()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
    }
    private void applyStall()
    {
        this.turnSpeed = (this.isStalling() ? this.stallSpeed : this.defaultTurnSpeed);

        if (!this.isStalling() || transform.rotation.x > 0.5) return;

        this.rotate(Vector3.left, -1);        
    }

    private void rotate(Vector3 target, float input)
    {
        transform.Rotate(target, this.turnSpeed * Time.deltaTime * input);
    }

    private bool isStalling()
    {
        return this.speed < stallSpeed;
    }
}   