using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    [SerializeField] private Button _toggleButton;
    [SerializeField] private Slider _sliderMainVolume;
    [SerializeField] private Slider _sliderButtonsVolume;
    [SerializeField] private Slider _sliderMusicVolume;

    [SerializeField] AudioMixerGroup _audioMixerMasterGroup;

    private string _masterParameterName = "MasterVolume";
    private string _soundsParameterName = "SoundsVolume";
    private string _musicParameterName = "MusicVolume";

    private bool _isToggleOn = true;
    private int volumeOn = 0;
    private int volumeOff = -80;

    public delegate void ChangeToggleDelegate(bool isToggleOn);
    public event ChangeToggleDelegate OnToggleChanged;

    private void OnEnable()
    {
        _toggleButton.onClick.AddListener(ChangeToogle);
        _sliderMainVolume.onValueChanged.AddListener(ChangeMainVolume);
        _sliderButtonsVolume.onValueChanged.AddListener(ChangeSoundsVolume);
        _sliderMusicVolume.onValueChanged.AddListener(ChangeMusicVolume);
    }

    private void OnDisable()
    {
        _toggleButton.onClick.RemoveListener(ChangeToogle);
        _sliderMainVolume.onValueChanged.RemoveListener(ChangeMainVolume);
        _sliderButtonsVolume.onValueChanged.RemoveListener(ChangeSoundsVolume);
        _sliderMusicVolume.onValueChanged.RemoveListener(ChangeMusicVolume);
    }

    private void ChangeToogle()
    {
        if (_isToggleOn == false)
        {
            OnToggleChanged.Invoke(_isToggleOn);
            _isToggleOn = true;
            _audioMixerMasterGroup.audioMixer.SetFloat(_masterParameterName, volumeOn);
        }
        else
        {
            OnToggleChanged.Invoke(_isToggleOn);
            _isToggleOn = false;
            _audioMixerMasterGroup.audioMixer.SetFloat(_masterParameterName, volumeOff);
        }
    }

    public void ChangeMainVolume(float volume)
    {
        _audioMixerMasterGroup.audioMixer.SetFloat(_masterParameterName, Mathf.Lerp(volumeOff, volumeOn, volume));
    }

    public void ChangeSoundsVolume(float volume)
    {
        _audioMixerMasterGroup.audioMixer.SetFloat(_soundsParameterName, Mathf.Lerp(volumeOff, volumeOn, volume));
    }
    public void ChangeMusicVolume(float volume)
    {
        _audioMixerMasterGroup.audioMixer.SetFloat(_musicParameterName, Mathf.Lerp(volumeOff, volumeOn, volume));
    }
}
