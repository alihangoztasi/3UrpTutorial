using System.Collections;
using System.Threading;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance {get; private set;}
    private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;
    private float _shakeTimer;
    private float _shakeTimerTotal;
    private float _startingInstensity;

    void Awake()
    {
        Instance = this;
        _cinemachineBasicMultiChannelPerlin = GetComponent<CinemachineBasicMultiChannelPerlin>();

    }

    private IEnumerator CameraShakeCoroutine(float instensity, float time, float delay)
    {
        yield return new WaitForSeconds(delay);
        _cinemachineBasicMultiChannelPerlin.AmplitudeGain = instensity;
        _shakeTimer = time;
        _shakeTimerTotal = time;
        _startingInstensity = instensity;

    }

    public void ShakeCamera(float instensity, float time, float delay = 0f)
    {
        StartCoroutine(CameraShakeCoroutine(instensity, time, delay));
    }

    void Update()
    {
        if(_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;
            if(_shakeTimer <= 0f)
            {
                _cinemachineBasicMultiChannelPerlin.AmplitudeGain
                =Mathf.Lerp(_startingInstensity, 0f, 1-(_shakeTimer / _shakeTimerTotal));
            }
        }
    }
}
