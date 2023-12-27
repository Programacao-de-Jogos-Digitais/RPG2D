using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;//faz refer�ncia ao outro script player
    private Animator anim; //acessa a anima��o

    void Start()
    {
        
        player = GetComponent<Player>(); //procura um componente do tipo Player
        anim = GetComponent<Animator>(); //procura animator
    }

    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0) //se dire��o for maior que zero
        {
            anim.SetInteger("transition", 1); //altera o valor do transition para 1
        }
        else
        {
            anim.SetInteger("transition", 0); //altera o valor do transition para 0
        }

        if (player.direction.x > 0) //se x for positivo, estou indo para direita
        {
            transform.eulerAngles = new Vector2(0, 0); //n�o muda dire��o
        }
        if (player.direction.x < 0) //se x for negativo, estou indo para esquerda
        {
            transform.eulerAngles = new Vector2(0, 180); //muda dire��o
        }
    }

    void OnRun()
    {
        if(player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    #endregion
}
