using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private InGameConfigMenu _startGameMenuPrefab;
    [SerializeField] private NewPauseScript _startPausePrefab;

    public void ConfigClicked()
    {
        Time.timeScale = 0f; // Pausa o jogo
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.voltarSFX, this.transform.position); // Som do botao
        Instantiate(_startGameMenuPrefab); // Chama prefab do menu de configuracoes
    }

    public void PauseClicked()
    {
        Time.timeScale = 0f; // Pausa o jogo
        UIAudioManager.instance.PlayOneShot(UIFMODEvents.instance.voltarSFX, this.transform.position); // Som do botao
        Instantiate(_startPausePrefab); // Mostra o menu de pausa

    }
}
