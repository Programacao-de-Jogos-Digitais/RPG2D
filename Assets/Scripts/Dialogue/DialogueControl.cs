using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ativa o canva


public class DialogueControl : MonoBehaviour
{
    [Header("Components")] //muda cabe�alho
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //Vari�veis de controle
    private bool isShowing; //se a janela est� vis�vel
    private int index; //index das senten�as, percorre as palavras

    private string[] sentences;

    //consigo acessar qualquer vari�vel de qualquer m�todo p�blico
    public static DialogueControl instance;

    //awake � chamado antes de todos os Start() na hierarquia de execu��o de scripts
    private void Awake()
    {
        instance = this;
    }

    //� chamado ao inicializar
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //exibe letra por letra na fala
    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray()) //percorre letra por letra
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed); //controla o tempo de execuss�o
        }
    }

    //pula para pr�xima frase/fala
    public void NextSentence()
    {

    }

    //chama a fala do npc
    public void Speech(string[] txt)
    {
        if(!isShowing) 
        {
            dialogueObj.SetActive(true); //ativa a fala
            sentences = txt; //passa as falas
            StartCoroutine(TypeSentence()); //chama a rotina
            isShowing = true; //evita que o npc fale novamente
        }
    }
}
