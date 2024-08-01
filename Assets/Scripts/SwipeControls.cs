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
    public float laneDistance = 4f; // Distância entre as lanes

    
    public Vector3 jump;
    public Vector3 crouch;
    public bool isGrounded = false;
    private Rigidbody rb;
    public float forcapulo = 2.0f;
    public float massa = 6.0f;


    private void Start()
    {
        _gameinputs = new GameInputs();
        _gameinputs.Gameplay.Enable();
        _gameinputs.Gameplay.Right.started += MoveToRight;
        _gameinputs.Gameplay.Left.started += MoveToLeft;
        _gameinputs.Gameplay.Jump.started += Jump;
        _gameinputs.Gameplay.Crouch.started += Crouch;

        // Definindo jump e crouch
        rb = GetComponent<Rigidbody>();
        rb.mass = massa;
      
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

        //rigidbody
        rb.AddForce(Vector3.up * forcapulo, ForceMode.Impulse);
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

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        
    }

    private void OnCollisionExit(Collision collision)
    {

            isGrounded = false;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector3.up * forcapulo, ForceMode.Impulse);
        }
        Debug.Log("Pular");

    }

    private void Crouch(InputAction.CallbackContext context)
    {
        if (isGrounded == true)
        {
            rb.AddForce(crouch, ForceMode.Impulse);
            isGrounded = false;
        }
        Debug.Log("Abaixar");

    }


}
