using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject game;

    private void Awake()
    {
        LoadingGO.OnLoadingStarted += () =>
        {
            game.SetActive(false);
        };

        LoadingGO.OnLoadingFinished += () =>
        {
            game.SetActive(true);
            GameManager.Instance.StartGame();
        };

        GameManager.OnGameFinished += (IsWin) =>
        {
            GameObject resultPopupPrefab = Resources.Load("Popups/result", typeof(GameObject)) as GameObject;
            Instantiate(resultPopupPrefab, GameObject.Find("screen").transform).GetComponent<Result>().SetResult(IsWin);
        };
    }
}