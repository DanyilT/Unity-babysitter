using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = AudioListener.volume = 0.5f;
        slider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        // Set the volume of the audio source to the value of the slider
        AudioListener.volume = volume;
    }
}
