using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    
    public float walkingSpeed = 5f;    /* VELOCIDADE DE MOVIMENTO NORMAL DO PLAYER */

    public float runningSpeed = 6f; /* VELOCIDADE DE MOVIMENTO DE CORRIDA DO PLAYER */
    
    public float health = 100f; /* VIDA DO PLAYER */
    
    public Stamina stamina;    /* STAMINA DO PLAYER */

    bool isWalking = false;     /* GUARDA SE O PLAYER ESTÁ ANDANDO */

    bool isRunning = false;

    Animator animator;      /* ANIMATOR PARA CONTROLAR AS ANIMAÇÕES DO PLAYER */

    public AudioClip walkingSound;      /* GUARDA O SOM DE ANDAR */

    public AudioClip runningSound;      /* GUARDA O SOM DE CORRER */

    private AudioSource moveAudioSource;    /* CONTROLADOR DO ÁUDIO DE MOVIMENTO */

    void Start()
    {
        /* CONFIGURANDO CONTROLADORES DE ÁUDIO E ANIMAÇÃO */
        moveAudioSource = GetComponent<AudioSource>();
        moveAudioSource.loop = true;
        animator = GetComponent<Animator>();

        /* INICIALIZANDO STAMINA DO PERSONAGEM */
        this.stamina =  GameObject.Find("Stamina").GetComponent<Stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        walk(); /* RESOLVENDO A LÓGICA DA MOVIMENTAÇÃO */
    }

    public void walk()  /* FAZ O JOGADOR ANDAR PELO MAPA AO PRESSIONAR OS BOTÕES */
    {
        if(Input.GetButton("Run") && !(stamina.exausted)){ /* CONDICIONAL PARA FAZER O JOGADOR CORRER */
            Debug.Log("entrou " + stamina.exausted);
            run();
        }
        else{   /* CONDICIONAL PARA FAZER O JOGADOR ANDAR EM VELOCIDADE NORMAL */
            walkNormal();
        }

        if(!isRunning){
            stamina.increase(0.2f);
        }
        
    }

    public void walkNormal() /* MOVIMENTA O PERSONAGEM NA VELOCIDADE PADRÃO */
    {
        this.isRunning = false;
        /* ANDANDO HORIZONTALMENTE */
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (isWalking == false) /* DÁ PLAY NO ÁUDIO CASO O JOGADOR AINDA NÃO ESTEJA ANDANDO */
            {
                moveAudioSource.Play();
            }
            this.isWalking = true;
            Vector3 newPosition = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * walkingSpeed * Time.deltaTime, transform.position.y, transform.position.z);
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
                moveAudioSource.clip = walkingSound;
                moveAudioSource.Play();
            }
            this.isWalking = true;
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + Input.GetAxis("Vertical") * walkingSpeed * Time.deltaTime, transform.position.z);
            transform.position = newPosition;
            animator.SetBool("isWalking", true);
        }

        if (!Input.GetButton("Vertical") && !Input.GetButton("Horizontal")) /* RODA QUANDO O PLAYER PARA DE SE MOVIMENTAR */
        {   
            moveAudioSource.Stop();
            this.isWalking = false;
            animator.SetBool("isWalking", false);
        }
    }

    public void run() /* MOVIMENTA O PERSONAGEM NA VELOCIDADE DE CORRIDA */
    {
        this.isWalking = false;
        moveAudioSource.clip = runningSound;

        /* ANDANDO HORIZONTALMENTE */
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (isRunning == false) /* DÁ PLAY NO ÁUDIO CASO O PLAYER NÃO ESTEJA CORRENDO */
            {
                moveAudioSource.Play();
            }
            this.isRunning = true;
            Vector3 newPosition = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * runningSpeed* Time.deltaTime, transform.position.y, transform.position.z);
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
            if (isRunning == false)
            {
                moveAudioSource.Play();
            }
            this.isRunning = true;
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + Input.GetAxis("Vertical") * runningSpeed * Time.deltaTime, transform.position.z);
            transform.position = newPosition;
            animator.SetBool("isWalking", true);
        }

        stamina.decrease(0.4f); /* DIMINUI A STAMINA AO CORRER */

        if (!Input.GetButton("Vertical") && !Input.GetButton("Horizontal")) /* RODA QUANDO O PLAYER PARAR DE ANDAR */
        {
            moveAudioSource.Stop();
            this.isRunning = false;
            animator.SetBool("isWalking", false);
        }
    }
}
