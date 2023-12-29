using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Cria um menu com essas opções
[CreateAssetMenu(fileName ="New Dialogue", menuName ="New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")] //cabeçalho
    public GameObject actor; //personagem (NPC) do diálogo (fala)

    [Header("Dialogue")]
    public Sprite speakerSprite;//sprite do falante
    public string sentence; //fala atual

    //Cria os dialogos
    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable] //faz as variáveis aparecer no menu
public class Sentences //cria uma frase para o NPC
{
    public string actorName; //Nome do NPC
    public Sprite profile; //Foto do NPC
    public Languages sentence; //O que está falando
}

[System.Serializable] //faz as variáveis aparecer no menu
public class Languages //linguas que vai falar
{
    public string portuguese;
    public string english;
    public string spanish;
}

//Só é chamado se estiver com o editor da unity aberto
#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))] //referencia o script DialogueSettings
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI() //sobrescreve uma classe
    {
        DrawDefaultInspector(); //Redesenho meu Inspector

        //criar um objeto para cada classe desse script
        DialogueSettings dialogueSettings = (DialogueSettings)target; //alvo 

        Languages languages = new Languages(); //Armazena as falas
        languages.portuguese = dialogueSettings.sentence; //Por padrão iniciamos com portugues a fala

        Sentences sentences = new Sentences();
        sentences.profile = dialogueSettings.speakerSprite; //foto do NPC
        sentences.sentence = languages; //Falas em todas as linguagens 

        //Cria o botão para adicionar falas
        if(GUILayout.Button("Create Dialogue"))
        {
            if(dialogueSettings.sentence != "")
            {
                dialogueSettings.dialogues.Add(sentences);

                //limpa os campos
                dialogueSettings.speakerSprite = null;
                dialogueSettings.sentence = "";
            }
        }
    }
}
#endif