using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] public float speed; //armazena e controla a velocidade de andar, pública
    [SerializeField] public float runSpeed; //armazena e controla a velocidade de corrida, pública

    //Componentes 
    private Rigidbody2D rig; //controle do rigidbody

    //Atributos
    private float initialSpeed; //velocidade inicial
    private bool _isRunning; //verifica se esta correndo
    private Vector2 _direction; //controle de direção do player

    //permite acessar essa função publica de outro script
    public Vector2 direction
    { 
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning //verifica se está correndo ou não
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    private void Start()
    {
        //Procura um componente do tipo rigidbody no código
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    // é chamado a cada frame
    void Update()
    {
        
        OnRun(); //chama método correr
    }

    private void FixedUpdate()
    {
        OnInput(); //chama o input direcional
        OnMove(); //chama o andar
    }

    #region Movement

    void OnInput()
    {
        //Armazena qual direção que o player vai se mover
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        //Posição do rigidbody na cena
        rig.MovePosition(rig.position + _direction * speed * Time.deltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) //quando PRESSIONAR o botão shift esquerdo
        {
            speed = runSpeed; //velocidade aumenta
            _isRunning = true; //está correndo
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) //quando SOLTAR o botão shift esquerdo
        {
            speed = initialSpeed; //volta a velocidade inicial
            _isRunning = false; //parou de correr
        }
    }


    #endregion
}
