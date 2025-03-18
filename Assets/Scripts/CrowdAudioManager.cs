using UnityEngine;

public class CrowdAudioManager : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public AudioSource[] crowdAudioSources; // Аудиоисточники толпы
    public float maxVolume = 1.0f; // Максимальная громкость
    public float minVolume = 0.1f; // Минимальная громкость
    public float maxHearingDistance = 10f; // Дистанция, на которой слышно хорошо
    public float minHearingDistance = 20f; // Дистанция, после которой почти не слышно

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        float volume = Mathf.Clamp01(1 - (distance - maxHearingDistance) / (minHearingDistance - maxHearingDistance));
        volume = Mathf.Lerp(minVolume, maxVolume, volume);
        
        foreach (AudioSource source in crowdAudioSources)
        {
            source.volume = volume;
        }
    }
}
