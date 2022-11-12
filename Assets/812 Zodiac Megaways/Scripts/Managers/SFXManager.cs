using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    [Space(10)]
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip loseClip;

    [Space(10)]
    [SerializeField] AudioClip pressClip;

    private void Awake()
    {
        GameManager.OnGameFinished += (IsWin) =>
        {
            if (sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }

            sfxSource.PlayOneShot(IsWin ? winClip : loseClip);
        };

        LetterCard.OnPressAction += () =>
        {
            if (sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }

            sfxSource.PlayOneShot(pressClip);
        };
    }
}
