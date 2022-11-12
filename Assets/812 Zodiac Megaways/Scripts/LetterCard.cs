using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class LetterCard : MonoBehaviour
{
    bool IsWorking { get; set; }
    int DefaultIndex { get; set; }


    Transform DefaultParent { get; set; }
    Image ImageComponent { get; set; }

    public static Action OnPressAction { get; set; } = delegate { };

    public void SetLetter(char letter)
    {
        DefaultIndex = transform.GetSiblingIndex();
        DefaultParent = transform.parent;

        ImageComponent = GetComponent<Image>();

        GetComponent<Button>().onClick.AddListener(() =>
        {
            if(WordEntity.IsChecking)
            {
                return;
            }

            IsWorking = !IsWorking;
            OnPressAction?.Invoke();

            if(IsWorking)
            {
                WordEntity.PlaceWordLetter(gameObject, letter);
                ImageComponent.color = new Color(1, 1, 1, 0);
            }
            else
            {
                transform.SetParent(DefaultParent);
                transform.SetSiblingIndex(DefaultIndex);

                ImageComponent.color = new Color(1, 1, 1, 1);
                WordEntity.InputCharList.Remove(letter);
            }
        });

        GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();
    }
}