using UnityEngine;

public class BulletTimeManager : MonoBehaviour
{
    [Range(0.05f, 1f)] public float slowScale = 0.25f;
    public float transitionSpeed = 8f;
    private float targetScale = 1f;

    private AudioSource audioSource;

    void Awake()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Time.timeScale = Mathf.Lerp(Time.timeScale, targetScale, Time.unscaledDeltaTime * transitionSpeed);
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void EnterBulletTime()
    {
        targetScale = slowScale;
        if (audioSource) audioSource.pitch = 0.6f;
    }

    public void ExitBulletTime()
    {
        targetScale = 1f;
        if (audioSource) audioSource.pitch = 1f;
    }

    public void ToggleBulletTime()
    {
        if (Mathf.Approximately(targetScale, 1f)) EnterBulletTime();
        else ExitBulletTime();
    }
}

