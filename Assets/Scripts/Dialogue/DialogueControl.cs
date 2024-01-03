using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ativa o canva


public class DialogueControl : MonoBehaviour
{
    [Header("Components")] //muda cabeçalho
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //Variáveis de controle
    private bool isShowing; //se a janela está visível
    private int index; //index das sentenças, percorre as palavras

    private string[] sentences;

    //consigo acessar qualquer variável de qualquer método público
    public static DialogueControl instance;

    //awake é chamado antes de todos os Start() na hierarquia de execução de scripts
    private void Awake()
    {
        instance = this;
    }

    //é chamado ao inicializar
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
            yield return new WaitForSeconds(typingSpeed); //controla o tempo de execussão
        }
    }

    //pula para próxima frase/fala
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
