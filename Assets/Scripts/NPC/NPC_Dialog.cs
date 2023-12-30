 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialog : MonoBehaviour
{
    public float dialogueRange; //tamanho do circulo da colisão
    public LayerMask playerLayer; //identifica a layer (camada)

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        //cria um circulo ao redor do NPC, identificando posição e layer
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer); 

        if(hit != null)
        {
            Debug.Log("player na área de colisão!");
        }
        else
        {

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange); //desenha a esfera gizmo
    }
}
