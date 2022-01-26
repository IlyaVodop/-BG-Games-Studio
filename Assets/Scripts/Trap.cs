using UnityEngine;
using Zenject;

    public class Trap : MonoBehaviour
    {
        [Inject] Player _player;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            _player.TryToKill();
        }
    }

