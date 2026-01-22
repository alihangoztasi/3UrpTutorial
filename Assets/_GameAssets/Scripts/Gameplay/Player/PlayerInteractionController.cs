using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{

    [SerializeField] private Transform _playerVisualTransform;
    private PlayerController _playerController;
    private Rigidbody _playerRigidBody;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent<ICollectible>(out var collectible))
        {
            collectible.Collect();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<IBoostible>(out var boostible))
        {
            boostible.Boost(_playerController);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if(other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.GiveDamage(_playerRigidBody, _playerVisualTransform);
            CameraShake.Instance.ShakeCamera(1f, 0.5f);
        }
    }
}
