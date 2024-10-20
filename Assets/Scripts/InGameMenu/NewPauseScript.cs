using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using static UnityEditor.Recorder.OutputPath;


public class NewPauseScript : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referência ao menu de pausa

    public void ReturnClicked()
    {
        Time.timeScale = 1f; // Despausa o jogo caso estivesse pausado
        AudioManager.instance.PlayOneShot(FMODEvents.Instance.voltarSFX, this.transform.position); // Som do botao
        GameObject.Destroy(gameObject);
    }

    public void HomeClicked()
    {
        Time.timeScale = 1f; // Despausa o jogo caso estivesse pausado
        AudioManager.instance.PlayOneShot(FMODEvents.Instance.playSFX, this.transform.position); // Som do botao
        SceneManager.LoadSceneAsync(0);
    }
}
