using UnityEngine.UI;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] Image popupImg;
    [SerializeField] Button restartBtn;

    [Space(10)]
    [SerializeField] Sprite winPopup;
    [SerializeField] Sprite losePopup;

    private void Awake()
    {
        restartBtn.onClick.AddListener(() =>
        {
            GameManager.Instance.StartGame();
            Destroy(gameObject);
        });
    }

    public void SetResult(bool IsWin)
    {
        popupImg.sprite = IsWin ? winPopup : losePopup;
        popupImg.SetNativeSize();
    }
}
