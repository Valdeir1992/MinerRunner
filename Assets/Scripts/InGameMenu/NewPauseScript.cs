using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPauseScript : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referência ao menu de pausa

    public void ReturnClicked()
    {
        Time.timeScale = 1f; // Despausa o jogo caso estivesse pausado
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.voltarSFX, this.transform.position); // Som do botao
        GameObject.Destroy(gameObject);
    }

    public void HomeClicked()
    {
        Time.timeScale = 1f; // Despausa o jogo caso estivesse pausado
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.voltarSFX, this.transform.position); // Som do botao
        SceneManager.LoadSceneAsync(0);
    }
}
