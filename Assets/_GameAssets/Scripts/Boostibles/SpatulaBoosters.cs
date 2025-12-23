using UnityEngine;

public class SpatulaBoosters : MonoBehaviour, IBoostible

{
    [Header("Settings")]
    [SerializeField] private float _jumpForce;
    private bool _isActivited;

    [Header("References")]
    [SerializeField] private Animator _spatulaAnimator;
    public void Boost(PlayerController playerController)
    {
        if (_isActivited) { return; }

        PlayBoostAnimation();

        Rigidbody playerRigidBody = playerController.GetPlayerRigidBody();

        playerRigidBody.linearVelocity = new Vector3(playerRigidBody.linearVelocity.x, 0f, playerRigidBody.linearVelocity.z);
        playerRigidBody.AddForce(transform.forward * _jumpForce, ForceMode.Impulse);
        _isActivited = true;
        Invoke(nameof(resetActivation), 0.2f);
    }

    private void PlayBoostAnimation()
    {
        _spatulaAnimator.SetTrigger(Consts.OtherAnimations.IS_SPATULA_JUMPING);
    }

    private void resetActivation()
    {
        _isActivited = false;
    }
}
