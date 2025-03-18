using UnityEngine;

public class CrowdAudioManager : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public AudioSource crowdAudioSource; // Один аудиофайл с речью толпы
    public float maxVolume = 1.0f;
    public float maxHearingDistance = 10f;
    public float minHearingDistance = 20f;

    void Start()
    {
        if (!crowdAudioSource.isPlaying)
        {
            crowdAudioSource.Play(); // Убедимся, что звук всегда играет
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        float volume = Mathf.Clamp01(1 - (distance - maxHearingDistance) / (minHearingDistance - maxHearingDistance));

        if (distance >= minHearingDistance)
        {
            crowdAudioSource.volume = 0f;
        }
        else
        {
            if (!crowdAudioSource.isPlaying)
            {
                crowdAudioSource.Play(); // Включаем звук, если он был отключен
            }
            crowdAudioSource.volume = Mathf.Lerp(0f, maxVolume, volume);
        }
    }
}
