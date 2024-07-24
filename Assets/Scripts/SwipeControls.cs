using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public SpawnManager spawnManager;

    private void Start()
    {

    }

    private void Update()
    {
        float hMoviment = Input.GetAxis("Horizontal") * moveSpeed / 2;
        float vMoviment = Input.GetAxis("Vertical") * moveSpeed;

        transform.Translate(new Vector3(hMoviment,0, vMoviment) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.TriggerEntered();
    }



}
