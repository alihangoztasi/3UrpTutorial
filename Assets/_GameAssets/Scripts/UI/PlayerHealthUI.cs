using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image[] _playerHealtImages;
    
    [Header("Sprites")]
    [SerializeField] private Sprite _playerHealtySprite;
    [SerializeField] private Sprite _playerUnHealtySprite;

    [Header("Setting")]
    [SerializeField] private float _scaleDurtion;

    private RectTransform[] _playerHealtTransform;

    void Awake()
    {
        _playerHealtTransform = new RectTransform[_playerHealtImages.Length];

        for (int i=0 ; i<_playerHealtImages.Length; i++)
        {
            _playerHealtTransform[i] = _playerHealtImages[i].gameObject.GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AnimateDamage();
        }
         if (Input.GetKeyDown(KeyCode.P))
        {
            AnimateDamageForAll();
        }
    }

    public void AnimateDamage()
    {
        for(int i= 0; i < _playerHealtImages.Length; i++)
        {
            if(_playerHealtImages[i].sprite == _playerHealtySprite)
            {
                AnimateDamageSprite(_playerHealtImages[i],_playerHealtTransform[i]);
                break;
            }
        }
    }

    public void AnimateDamageForAll()
    {
        for(int i= 0; i < _playerHealtImages.Length; i++)
        {
            AnimateDamageSprite(_playerHealtImages[i],_playerHealtTransform[i]);
        }
    }

    private void AnimateDamageSprite(Image activeImage, RectTransform activeImageTransform)
    {
        activeImageTransform.DOScale(0f, _scaleDurtion).SetEase(Ease.InBack).OnComplete(() =>
        {
           activeImage.sprite = _playerUnHealtySprite;
           activeImageTransform.DOScale(1f, _scaleDurtion).SetEase(Ease.OutBack); 
        });
    }
}
