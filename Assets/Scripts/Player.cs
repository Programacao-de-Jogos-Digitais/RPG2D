using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] public float speed; //armazena e controla a velocidade de andar, p�blica
    [SerializeField] public float runSpeed; //armazena e controla a velocidade de corrida, p�blica

    //Componentes 
    private Rigidbody2D rig; //controle do rigidbody

    //Atributos
    private float initialSpeed; //velocidade inicial
    private bool _isRunning; //verifica se esta correndo
    private bool _isRolling; //verifica se esta rolando
    private Vector2 _direction; //controle de dire��o do player

    //permite acessar essa fun��o publica de outro script
    public Vector2 direction
    { 
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning //verifica se est� correndo ou n�o
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    
    public bool isRolling //verifica se est� correndo ou n�o
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    private void Start()
    {
        //Procura um componente do tipo rigidbody no c�digo
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    // � chamado a cada frame
    void Update()
    {
        OnInput(); //chama a fun��o input direcional
        OnRun(); //chama m�todo correr
        OnRolling(); //chama a fun��o rolar
    }

    private void FixedUpdate()
    {
        OnMove(); //chama a fun��o andar
    }

    #region Movement

    void OnInput()
    {
        //Armazena qual dire��o que o player vai se mover
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        //Posi��o do rigidbody na cena
        rig.MovePosition(rig.position + _direction * speed * Time.deltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) //quando PRESSIONAR o bot�o shift esquerdo
        {
            speed = runSpeed; //velocidade aumenta
            _isRunning = true; //est� correndo
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) //quando SOLTAR o bot�o shift esquerdo
        {
            speed = initialSpeed; //volta a velocidade inicial
            _isRunning = false; //parou de correr
        }
    }

    void OnRolling()
    {
        if(Input.GetMouseButtonDown(1)) //verifica se esta precionando o bot�o direito do mouse
        {
            speed = runSpeed; //velocidade aumenta
            _isRolling = true; //rolar
        }
        
        if(Input.GetMouseButtonUp(1)) //verifica se soltou o bot�o direito do mouse
        {
            speed = initialSpeed; //volta a velocidade inicial
            _isRolling = false; //para de rolar
        }

    }


    #endregion
}
