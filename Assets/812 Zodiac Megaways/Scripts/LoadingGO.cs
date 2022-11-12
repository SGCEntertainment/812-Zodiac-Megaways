using System;
using System.Collections;
using UnityEngine;

using Random = UnityEngine.Random;

public class LoadingGO : MonoBehaviour
{
    const float rotSpinnerSpeed = 250.0f;

    public static Action OnLoadingStarted { get; set; } = delegate { };
    public static Action OnLoadingFinished { get; set; } = delegate { };

    private IEnumerator Start()
    {
        OnLoadingStarted?.Invoke();
        Transform spinner = GameObject.Find("spinner").transform;

        float et = 0.0f;
        float loadingTime = Random.Range(3.0f, 5.0f);

        while(et < loadingTime)
        {
            spinner.Rotate(rotSpinnerSpeed * Time.deltaTime * Vector3.back);

            et += Time.deltaTime;
            yield return null;
        }

        OnLoadingFinished?.Invoke();
        gameObject.SetActive(false);
    }
}
