using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float rotationSpeed = 50f; // Velocidade de rota��o do cubo

    void Update()
    {
        // Rotaciona o cubo, dependente do tempo
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
