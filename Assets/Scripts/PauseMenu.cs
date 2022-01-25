using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    private CanvasGroup _canvasGroup;
    private Coroutine _fadeAnimation;


    public void SetPauseState(bool value)
    {
        gameObject.SetActive(value);

        if (value)
        {
            _fadeAnimation = StartCoroutine(GameManager.Instance.AlphaCoroutine(0, 1f, _canvasGroup));
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
