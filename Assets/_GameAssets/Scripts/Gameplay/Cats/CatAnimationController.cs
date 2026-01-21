using UnityEngine;

public class CatAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _catAnimator;
    
    private CatsStateController _catStateController;

    private void Awake()
    {
        _catStateController = GetComponent<CatsStateController>();
    }

    private void Update()
    {
        SetCatAnimations();
    }

    private void SetCatAnimations()
    {
        var currentGetState = _catStateController.GetCurrentState();

        switch (currentGetState)
        {
            case CatState.Idle:
                _catAnimator.SetBool(Consts.CatAnimations.IS_IDLING, true);
                _catAnimator.SetBool(Consts.CatAnimations.IS_WALKING, false);
                _catAnimator.SetBool(Consts.CatAnimations.IS_RUNNING, false);
                break;

            case CatState.Walking:
                _catAnimator.SetBool(Consts.CatAnimations.IS_IDLING, false);
                _catAnimator.SetBool(Consts.CatAnimations.IS_WALKING, true);
                _catAnimator.SetBool(Consts.CatAnimations.IS_RUNNING, false);
                break;

            case CatState.Running:
                _catAnimator.SetBool(Consts.CatAnimations.IS_RUNNING, true);
                break;
            
            case CatState.Attacking:
                _catAnimator.SetBool(Consts.CatAnimations.IS_ATTACKING, true);
                break;            
        }
    }

}
