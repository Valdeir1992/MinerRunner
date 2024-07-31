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
    public float jumpHeight = 5f; // Altura do pulo

    public Vector3 crouch;
    public float crouchForce = 1f; // O quanto o player abaixa

    public bool isGrounded;
    private Rigidbody rb;


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
        jump = new Vector3(0f, 1f, 0f);
        crouch = new Vector3(0f, -1f, 0f);
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

    // Definindo isGrounded
    private void OnCollisionEnter()
    {
        isGrounded = true;
    }

    private void OnCollisionExit()
    {
        isGrounded = false;
    }

    /// <summary>
    /// Personagem pula.
    /// </summary>
    /// <param name="context">Recebe o contexto do InputSystem</param>
    private void Jump(InputAction.CallbackContext context)
    {

        if (isGrounded == true)
        {
            rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("Pulando");
        }


    }

    private void Crouch(InputAction.CallbackContext context)
    {
        if (isGrounded == true)
        {
            rb.AddForce(crouch * crouchForce);
            isGrounded = false;
        }
        Debug.Log("Abaixar");

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



}
