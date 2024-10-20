using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private InGameConfigMenu _startGameMenuPrefab;
    [SerializeField] private NewPauseScript _startPausePrefab;

    public void ConfigClicked()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.Instance.buttonSFX, this.transform.position); // Som do botao
        Time.timeScale = 0f; // Pausa o jogo
        Instantiate(_startGameMenuPrefab); // Chama prefab do menu de configuracoes
    }

    public void PauseClicked()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.Instance.buttonSFX, this.transform.position); // Som do botao
        Time.timeScale = 0f; // Pausa o jogo
        Instantiate(_startPausePrefab); // Mostra o menu de pausa
    }
}
