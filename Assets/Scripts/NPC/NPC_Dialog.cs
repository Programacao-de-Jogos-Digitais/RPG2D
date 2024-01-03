 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialog : MonoBehaviour
{
    public float dialogueRange; //tamanho do circulo da colisão
    public LayerMask playerLayer; //identifica a layer (camada)

    bool playerHit; //monitora quando player entrar em colisão

    //é chamado a cada frame
    void Update()
    {
        //Quando apertar tecla E e plaHit for verdadeiro
        if(Input.GetKeyUp(KeyCode.E) && playerHit )
        {
            DialogueControl.instance.Speech();
        }
    }

    //é usado pela física 
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
            playerHit = true;
            //Debug.Log("player na área de colisão!");
        }
        else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange); //desenha a esfera gizmo
    }
}
