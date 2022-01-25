using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    public Coroutine _shieldTimer;

    [SerializeField] private Button PauseBtn;
    [SerializeField] private Button ContinueBtn;

    private void Start()
    {
        PauseBtn.onClick.AddListener(GameManager.Instance.PauseGame);
        ContinueBtn.onClick.AddListener(GameManager.Instance.ContinueGame);
    }
    public IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(2f);
        Player.Instance.SetInvincible(false);
        _shieldTimer = null;
    }
    public void PressedShieldButton()
    {
        Player.Instance.SetInvincible(true);
        _shieldTimer = StartCoroutine(ShieldTimer());
    }
    public void UnPressedShieldButton()
    {
        if (_shieldTimer != null)
        {
            StopCoroutine(_shieldTimer);
            Player.Instance.SetInvincible(false);
        }
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
