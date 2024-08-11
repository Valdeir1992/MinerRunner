using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchManager : MonoBehaviour
{
    //Vari�veis para o touch
    private Animator animator;
    public GameObject player;
    public Vector2 startPosition; //Primeira posi��o do toque na tela
    public int swipeResistence = 200; //Quantidade m�nima para considerar toque como swipe
    private bool fingerDown; //Checa se o dedo est� encostando na tela

    //Vari�veis para a movimenta��o
    public SpawnManager spawnManager;
    private int desiredLane = 1; // 0 = esquerda, 1 = meio, 2 = direita
    public float laneDistance = 3f; // Dist�ncia entre as lanes

    //Jump
    [SerializeField] private float forcaPulo = 7.0f;
    private bool isGrounded;
    private Rigidbody rb;

    //Crouch
    [SerializeField] private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 normalScale = new Vector3(1, 1, 1);

    //Som
    [SerializeField] private AudioSource som;
    [SerializeField] private AudioClip somPulo; 
    [SerializeField] private AudioClip somCarrinho; //Ainda n�o chamei no c�digo
    [SerializeField] private float volume = 5f;



    private void Start()
    {
        // Definindo componentes
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

  
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    spawnManager.TriggerEntered();
    //}

    //Checando colis�o com o Apoio
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
   

    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void Update()
    {
        // Calcular a nova posi��o com base na lane desejada
        Vector3 targetPosition = transform.position;
        targetPosition.x = (desiredLane - 1) * laneDistance;

        // Atualizar a posi��o do jogador
        transform.position = targetPosition;
        
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == UnityEngine.TouchPhase.Began)
        {
            startPosition = Input.touches[0].position; //Primeira posi��o � primeiro toque
            fingerDown = true;
        }

        if (fingerDown == true)
        {

            //Pulo
            if (Input.touches[0].position.y >= startPosition.y + swipeResistence)
            {
                if (isGrounded == true)
                {
                    rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
                    rb.constraints = RigidbodyConstraints.FreezeRotation;
                    animator.SetBool("isJumping", true);
                    animator.SetBool("IsJumpingcar", true);
                }
                fingerDown = false;

                som.PlayOneShot(somPulo, volume);
                Debug.Log("Swipe Up");
            }

            //Crouch
            else if (Input.touches[0].position.y <= startPosition.y - swipeResistence)
            {
                if (isGrounded == true)
                {
                    transform.localScale = crouchScale;
                    transform.position = new Vector3(transform.position.x, transform.position.y -0.5f, transform.position.z);
                    rb.constraints = RigidbodyConstraints.FreezeRotation;

                    animator.SetBool("abaixar", true);
                }
                fingerDown = false;
                Debug.Log("Swipe Down");
            }

            //Direita
            else if (Input.touches[0].position.x >= startPosition.x + swipeResistence)
            {
                desiredLane++;
                if (desiredLane == 3)
                {
                    desiredLane = 2;
                }

                fingerDown = false;
                Debug.Log("Swipe Right");
            }

            //Esquerda
            else if (Input.touches[0].position.x <= startPosition.x - swipeResistence)
            {
                desiredLane--;
                if (desiredLane == -1)
                {
                    desiredLane = 0;
                }

                fingerDown = false;
                Debug.Log("Swipe Left");
            }


        }

        //Fim do toque
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == UnityEngine.TouchPhase.Ended)
        {
            fingerDown = false;
            transform.localScale = normalScale; //Resetar escala por causa do crouch
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z); //Resetar posi��o por causa do crouch
            rb.constraints = RigidbodyConstraints.None; //Resetar constrains por causa do jump e o crouch
            animator.SetBool("abaixar", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("IsJumpingcar", false);
        }

        

    }

}


