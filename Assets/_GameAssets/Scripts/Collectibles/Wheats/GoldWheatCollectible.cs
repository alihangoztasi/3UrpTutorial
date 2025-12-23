using UnityEngine;

public class GoldWheatCollectible : MonoBehaviour, ICollectible
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _movementIncressedSpeed;
    [SerializeField] private float _resetBoostDuration;
    public void Collect()
    {
        _playerController.SetMovementSpeed(_movementIncressedSpeed, _resetBoostDuration);
        Destroy(this.gameObject); // Sadece gameObject Yazincada Bu objeyi yok et demek olabiliyor
    }
}
