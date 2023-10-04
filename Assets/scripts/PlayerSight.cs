using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    private Camera camera;
    private Quaternion rotation;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rotateLight(float angle)
    {
        rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
    }

    public void resolveRotation()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            /* CASO ANDE PARA OS LADOS */
            if (Input.GetAxis("Horizontal") < 0 && transform.rotation.z != 90)
            {
                this.rotateLight(-90);
                Vector3 newPosition = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y, player.transform.position.z);
                transform.position = newPosition;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                this.rotateLight(90);
                Vector3 newPosition = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y, player.transform.position.z);
                transform.position = newPosition;
            }

            else if (Input.GetAxis("Vertical") < 0)
            {
                this.rotateLight(0);
                Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y -1.5f, player.transform.position.z);
                transform.position = newPosition;
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                this.rotateLight(180);
                Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);
                transform.position = newPosition;
            }
        }
    }
}
