using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform playerTransform;
    public float speed = 5f;
    public int noise = 0;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.Find("Player").transform;
        Debug.Log("Teste");
    }

    // Update is called once per frame
    void Update()
    {
        //player é controlado pelo jogador
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector3 newPosition = new Vector3(playerTransform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, playerTransform.position.y, playerTransform.position.z);
            playerTransform.position = newPosition;

            /* FLIPPING CHARACTER  */

            Vector3 scale = playerTransform.localScale;
            if (Input.GetAxis("Horizontal") > 0)
            {
                scale.x = Mathf.Abs(playerTransform.localScale.x);
            }
            else
            {
                scale.x = -Mathf.Abs(playerTransform.localScale.x);
            }
            playerTransform.localScale = scale;
            animator.SetBool("isWalking", true);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            Vector3 newPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime, playerTransform.position.z);
            playerTransform.position = newPosition;
            animator.SetBool("isWalking", true);
        }
        if (!Input.GetButton("Vertical") && !Input.GetButton("Horizontal"))
        {
            animator.SetBool("isWalking", false);
        }
    }
}
