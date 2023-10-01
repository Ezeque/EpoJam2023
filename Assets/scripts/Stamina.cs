using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float maxStamina = 100f; /* STAMINA MÁXIMA DO PERSONAGEM */
    public float currentStamina = 100f; /* STAMINA ATUAL DO PERSONAGEM */
    public Image staminaBar;    /* SPRITE DA BARRA DE STAMINA */
    float staminaPercentage;    /* PORCENTAGEM DE STAMINA RESTANTE */
    public bool exausted = false;   /* INDICA SE O PERSONAGEM ESTÁ EXAUSTO OU NÃO */


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* ATUALIZA BARRA DE STAMINA */
        staminaPercentage = currentStamina / maxStamina;
        staminaBar.fillAmount = staminaPercentage;

        /* ATUALIZA ESTADO DE EXAUSTO */
        if(this.staminaPercentage > 0.3){
            exausted = false;
        }
    }

    /* AUMENTA A STAMINA DO PERSONAGEM */
    public void increase(float number)
    {
        if(staminaPercentage < 1){
            this.currentStamina += number; 
        }
    }

    /* DIMINUI A STAMINA DO PERSONAGEM */
    public void decrease(float number)
    {
        this.currentStamina -= number;

        /* ATIVA EXAUSTÃO AO CHEGAR EM 0 DE STAMINA */
        if (this.currentStamina <= 0){
            this.exausted = true;
        }
    }
}
