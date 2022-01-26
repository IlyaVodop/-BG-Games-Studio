using UnityEngine;
using Zenject;


public class Finish : MonoBehaviour
{
    [Inject] GameManager _gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _gameManager.Finish();
    }
}

