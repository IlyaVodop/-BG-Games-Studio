using System;
using System.Collections;
using UnityEngine;
using Zenject;
public class GameManager : MonoBehaviour
{
    [Inject] PauseMenu _pauseMenu;
    [Inject] Player _player;
    [Inject] LabyrinthCreator _labyrinthCreator;

    [SerializeField] private CanvasGroup loaderPause;

    public void OnLabyrinthGenerated()
    {
        StartCoroutine(AlphaCoroutine(1f, 0f, loaderPause, callback: () => _player.OnGameStart()));
    }
    public IEnumerator AlphaCoroutine(float from, float to, CanvasGroup screen, float cooldown = 0f, Action callback = null)
    {
        yield return new WaitForSeconds(cooldown);

        float time = 0;

        while (time < 1)
        {
            yield return new WaitForSeconds(0.001f);

            time += 0.05f;
            if (screen) screen.alpha = Mathf.Lerp(from, to, time);
        }

        callback?.Invoke();
    }
    public void Finish()
    {
        _player.Finish();
        StartCoroutine(AlphaCoroutine(0f, 1f, loaderPause, 2, ResetGame));
    }
    public void ContinueGame()
    {
        _player.OnGameContinue();
        _pauseMenu.SetPauseState(false);
    }


    public void PauseGame()
    {
        _player.OnGamePause();
        _pauseMenu.SetPauseState(true);
    }

    private void ResetGame()
    {
        _player.ResetPlayer();
        _labyrinthCreator.GenerateLabyrinth();
    }

}
