using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchManager : MonoBehaviour
{
    public GameObject player;
    public Vector2 startPosition; //Primeira posição do toque na tela
    public int swipeResistence = 200; //Quantidade mínima para considerar toque como swipe
    private bool fingerDown; //Checa se o dedo está encostando na tela

    void Update () 
    {
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == UnityEngine.TouchPhase.Began)
        {
            startPosition = Input.touches[0].position; //Primeira posição é primeiro toque
            fingerDown = true;
        }

        if (fingerDown)
        {
            
            //Pulo
            if (Input.touches[0].position.y >= startPosition.y + swipeResistence)
            {
                fingerDown = false;
                Debug.Log("Swipe Up");
            }
                       
            //Crouch
            else if (Input.touches[0].position.y <= startPosition.y - swipeResistence)
            {
                fingerDown = false;
                Debug.Log("Swipe Down");
            }

            //Direita
            else if (Input.touches[0].position.x >= startPosition.x + swipeResistence)
            {
                fingerDown = false;
                Debug.Log("Swipe Right");
            }

            //Esquerda
            else if (Input.touches[0].position.x <= startPosition.x - swipeResistence)
           {
               fingerDown = false;
               Debug.Log("Swipe Left");
           }

           
        }

        //Fim do toque
        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == UnityEngine.TouchPhase.Ended)
        {
            fingerDown = false;
        }
    }
}
