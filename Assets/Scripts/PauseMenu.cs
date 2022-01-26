using UnityEngine;
using Zenject;
public class PauseMenu : MonoBehaviour
{
    [Inject] GameManager _gameManager;

    private CanvasGroup _canvasGroup;
    private Coroutine _fadeAnimation;


    public void SetPauseState(bool value)
    {
        gameObject.SetActive(value);

        if (value)
        {
            _fadeAnimation = StartCoroutine(_gameManager.AlphaCoroutine(0, 1f, _canvasGroup));
        }
        else
        {
            _canvasGroup.alpha = 0;
        }
    }
    private void Start()
    {
        SetPauseState(false);
    }
    private void OnDisable()
    {
        if (_fadeAnimation != null) StopCoroutine(_fadeAnimation);
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
}
