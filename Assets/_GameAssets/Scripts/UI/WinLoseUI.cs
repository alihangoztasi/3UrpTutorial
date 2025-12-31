using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class WinLoseUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _blackBackgroundObject;
    [SerializeField] private GameObject _winPopup;
    [SerializeField] private GameObject _losePopup;

    [Header("Settings")]
    [SerializeField] private float _animationDuration = 0.3f;


    private Image _blackBackgroundImage;
    private RectTransform _winPopupTransfrom;
    private RectTransform _losePopupTransfrom;

    void Awake()
    {
        _blackBackgroundImage = _blackBackgroundObject.GetComponent<Image>();
        _winPopupTransfrom = _winPopup.GetComponent<RectTransform>();
        _losePopupTransfrom = _losePopup.GetComponent<RectTransform>();
    }

    public void OnGameWin()
    {
        _blackBackgroundObject.SetActive(true);
        _winPopup.SetActive(true);

        _blackBackgroundImage.DOFade(0.8f,_animationDuration).SetEase(Ease.Linear);
        _winPopupTransfrom.DOScale(1.5f,_animationDuration).SetEase(Ease.OutBack);
    }

    public void OnGameLose()
    {
        _blackBackgroundObject.SetActive(true);
        _losePopup.SetActive(true);

        _blackBackgroundImage.DOFade(0.8f,_animationDuration).SetEase(Ease.Linear);
        _losePopupTransfrom.DOScale(1.5f,_animationDuration).SetEase(Ease.OutBack);
    }

}
