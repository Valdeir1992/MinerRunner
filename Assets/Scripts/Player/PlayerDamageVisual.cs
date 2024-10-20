using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageVisual : MonoBehaviour
{
    [SerializeField] private GameObject[] playerObject;


    public IEnumerator Coroutine_Blink()
    {
        for (int i = 0; i < 3; i++)
        {


            foreach (GameObject gameObject in playerObject)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }

            yield return new WaitForSeconds(0.2f);

            foreach (GameObject gameObject in playerObject)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }

            yield return new WaitForSeconds(0.2f);
        }

    }
}
