using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))] // checar se existe um Rigidbody
public class SwipeMovement : MonoBehaviour
{
    public SpawnManager spawnManager;
    private GameInputs _gameinputs;

    private int desiredLane = 1; // 0 = esquerda, 1 = meio, 2 = direita
    public float laneDistance = 3f; // Distância entre as lanes

    //Jump
    [SerializeField] private float forcaPulo = 7.0f;
    private bool isGrounded;
    private Rigidbody rb;

    //Crouch
    [SerializeField] private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 normalScale = new Vector3(1, 1, 1);
    


    //Para as animações
    Animator animator;
    
  
    private void Start()
    {
        _gameinputs = new GameInputs();
        _gameinputs.Gameplay.Enable();
        _gameinputs.Gameplay.Right.started += MoveToRight;
        _gameinputs.Gameplay.Left.started += MoveToLeft;
        _gameinputs.Gameplay.Jump.started += Jump;
        _gameinputs.Gameplay.Jump.canceled += JumpCanceled;
        _gameinputs.Gameplay.Crouch.started += Crouch;
        _gameinputs.Gameplay.Crouch.canceled += CrouchCanceled;

        // Definindo componentes
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();


    }

    /// <summary>
    /// Move o personagem para esqueda.
    /// </summary>
    /// <param name="context">Recebe o contexto do InputSystem</param>
    /// <exception cref="NotImplementedException"></exception>
    private void MoveToLeft(InputAction.CallbackContext context)
    {
        desiredLane--;
        if (desiredLane == -1)
        {
            desiredLane = 0;
        }
        Debug.Log("Esquerda");
    }

    /// <summary>
    /// Move o personagem para direita.
    /// </summary>
    /// <param name="context">Recebe o contexto do InputSystem</param>
    /// <exception cref="NotImplementedException"></exception>
    private void MoveToRight(InputAction.CallbackContext context)
    {
        desiredLane++;
        if (desiredLane == 3)
        {
            desiredLane = 2;
        }
        Debug.Log("Direita");
    }
    private void Update()
    {
        // Calcular a nova posição com base na lane desejada
        Vector3 targetPosition = transform.position;
        targetPosition.x = (desiredLane - 1) * laneDistance;

        // Atualizar a posição do jogador
        transform.position = targetPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.TriggerEntered();
    }

    /// <summary>
    /// Personagem pula.
    /// </summary>
    /// <param name="context">Recebe o contexto do InputSystem</param>
    /// 
    
    //Checando colisão com o Apoio
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    //Pulo
    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }

        Debug.Log("Pular");

    }
    private void JumpCanceled(InputAction.CallbackContext context)
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            rb.constraints = RigidbodyConstraints.None;

        }

        Debug.Log("Voltar");

    }

    //Agachar
    private void Crouch(InputAction.CallbackContext context)
    {
     
        if (isGrounded == true)
        {
            transform.localScale = crouchScale;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }
        Debug.Log("Abaixar");

    }

    private void CrouchCanceled(InputAction.CallbackContext context)
    {
    
        if (isGrounded == true)
        {
            transform.localScale = normalScale;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            rb.constraints = RigidbodyConstraints.None;
        }
        Debug.Log("Levantar");

    }


}
