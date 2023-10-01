using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform playerTransform;
    public float followSpeed = 5.0f;
    //public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z-9);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
