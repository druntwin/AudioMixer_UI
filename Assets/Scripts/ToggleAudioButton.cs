using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudioButton : MonoBehaviour
{
    [SerializeField] private Image _toggleButtonImage;
    [SerializeField] private Sprite _imageOn;
    [SerializeField] private Sprite _imageOff;
    [SerializeField] private MixerController _mixerComtroller;

    private void OnEnable()
    {
        _mixerComtroller.OnToggleChanged += ChangeToogle;
    }

    private void OnDisable()
    {
        _mixerComtroller.OnToggleChanged -= ChangeToogle;
    }

    private void ChangeToogle(bool _isToggleOn)
    {
        if (_isToggleOn == false)
        {
            _toggleButtonImage.sprite = _imageOn;
        }
        else
        {
            _toggleButtonImage.sprite = _imageOff;
        }
    }
}
