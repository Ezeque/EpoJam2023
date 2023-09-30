using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    
    public float speed = 5f;    /* VELOCIDADE DE MOVIMENTO DO PLAYER */
    
    public float health = 100f; /* VIDA DO PLAYER */
    
    public float stamina = 100f;    /* STAMINA DO PLAYER */

    bool isWalking = false;     /* GUARDA SE O PLAYER ESTÁ ANDANDO */

    Animator animator;      /* ANIMATOR PARA CONTROLAR AS ANIMAÇÕES DO PLAYER */

    private AudioSource andar;      /* GUARDA O SOM DE ANDAR */

    void Start()
    {
        andar = GetComponent<AudioSource>();
        andar.loop = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        walk();
    }

    public void walk()  /* FAZ O JOGADOR ANDAR PELO MAPA AO PRESSIONAR OS BOTÕES */
    {
        /* ANDANDO HORIZONTALMENTE */
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (isWalking == false)
            {
                andar.Play();
            }

            this.isWalking = true;
            Vector3 newPosition = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.position = newPosition;

            /* VIRANDO O PERSONAGEM DE LADO  */

            Vector3 scale = transform.localScale;
            if (Input.GetAxis("Horizontal") > 0)
            {
                scale.x = Mathf.Abs(transform.localScale.x);
            }
            else
            {
                scale.x = -Mathf.Abs(transform.localScale.x);
            }
            transform.localScale = scale;
            animator.SetBool("isWalking", true);
        }

        /* ANDANDO VERTICALMENTE */
        if (Input.GetAxis("Vertical") != 0)
        {
            if (isWalking == false)
            {
                andar.Play();
            }
            this.isWalking = true;
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + Input.GetAxis("Vertical") * speed * Time.deltaTime, transform.position.z);
            transform.position = newPosition;
            animator.SetBool("isWalking", true);
        }
        if (!Input.GetButton("Vertical") && !Input.GetButton("Horizontal"))
        {
            andar.Stop();
            this.isWalking = false;
            animator.SetBool("isWalking", false);
        }
    }
}
