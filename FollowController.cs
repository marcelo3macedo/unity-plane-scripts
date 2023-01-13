
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowController : MonoBehaviour
{
    public GameObject player;
    private float rotationDamping = 3.0f;
    private float distance = 25.0f;
    private float height = 4.0f;
    private float wantedRotationAngleSide;
    private float currentRotationAngleSide;
    private float wantedRotationAngleUp;
    private float currentRotationAngleUp;
    private Quaternion currentRotation;

    void Start()
    {
    }

    void LateUpdate()
    {
        wantedRotationAngleSide = player.transform.eulerAngles.y;
        currentRotationAngleSide = player.transform.eulerAngles.y;

        wantedRotationAngleUp = player.transform.eulerAngles.x;
        currentRotationAngleUp = transform.eulerAngles.x;

        currentRotationAngleSide = Mathf.LerpAngle(currentRotationAngleSide, wantedRotationAngleSide, rotationDamping * Time.deltaTime);
        currentRotationAngleUp = Mathf.LerpAngle(currentRotationAngleUp, wantedRotationAngleUp, rotationDamping * Time.deltaTime);
        currentRotation = Quaternion.Euler(currentRotationAngleUp, currentRotationAngleSide, 0);

        transform.position = player.transform.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.LookAt(player.transform);

        transform.position += transform.up * height;
    }
}
