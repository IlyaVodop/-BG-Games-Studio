using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UiManager : MonoBehaviour
{
    [Inject] GameManager _gameManager;
    [Inject] Player _player;

    public Coroutine _shieldTimer;

    [SerializeField] private Button PauseBtn;
    [SerializeField] private Button ContinueBtn;

    private void Start()
    {
        PauseBtn.onClick.AddListener(_gameManager.PauseGame);
        ContinueBtn.onClick.AddListener(_gameManager.ContinueGame);
    }
    public IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(2f);
        _player.SetInvincible(false);
        _shieldTimer = null;
    }
    public void PressedShieldButton()
    {
        _player.SetInvincible(true);
        _shieldTimer = StartCoroutine(ShieldTimer());
    }
    public void UnPressedShieldButton()
    {
        if (_shieldTimer != null)
        {
            StopCoroutine(_shieldTimer);
            _player.SetInvincible(false);
        }
    }
}
