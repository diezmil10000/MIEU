using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{

    [SerializeField] private Slider _slider;

    void Start()
    {
        SoundManager.Instance.ChangeMusicVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
    }


}

