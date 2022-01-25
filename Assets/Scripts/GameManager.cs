using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private CanvasGroup loaderPause;

    public void OnLabyrinthGenerated()
    {
        StartCoroutine(AlphaCoroutine(1f, 0f, loaderPause, callback: () => Player.Instance.OnGameStart()));
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
        Player.Instance.Finish();
        StartCoroutine(AlphaCoroutine(0f, 1f, loaderPause, 2, ResetGame));
    }
    public void ContinueGame()
    {
        Player.Instance.OnGameContinue();
        PauseMenu.Instance.SetPauseState(false);
    }


    public void PauseGame()
    {
        Player.Instance.OnGamePause();
        PauseMenu.Instance.SetPauseState(true);
    }

    private void ResetGame()
    {
        Player.Instance.ResetPlayer();
        LabyrinthCreator.Instance.GenerateLabyrinth();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
