using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _forceIncressed;
    [SerializeField] private float _resetBoostDuration;
    public void Collect()
    {
        _playerController.SetJumpForce(_forceIncressed, _resetBoostDuration);
        Destroy(this.gameObject); // Sadece gameObject Yazincada Bu objeyi yok et demek olabiliyor
    }
}
