using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Toogle : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _buttonImage;

    [SerializeField] private Sprite _imageOn;
    [SerializeField] private Sprite _imageOff;

    private bool _isSoundOn;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeToogle);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(ChangeToogle);
    }

    private void ChangeToogle()
    {
        if (_isSoundOn)
        {
            OffSound();
        }
        else
        {
            OnSound();
        }
    }

    private void OnSound()
    {
        _isSoundOn = true;
        _buttonImage.sprite = _imageOn;

    }

    private void OffSound()
    {
        _isSoundOn = false;
        _buttonImage.sprite = _imageOff;

    }
}
