using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

public class WordEntity : MonoBehaviour
{
    public static bool IsChecking { get; set; }
    private static string Word { get; set; }
    public static List<char> InputCharList { get; set; } = new List<char>();


    private static WordFieldController WordField { get; set; }
    private static LettersFiledController LettersFiled { get; set; }

    private static WordEntity Instance
    {
        get => FindObjectOfType<WordEntity>();
    }


    private void Awake()
    {
        WordField = GetComponentInChildren<WordFieldController>();
        LettersFiled = GetComponentInChildren<LettersFiledController>();
    }

    public static void SetWord(string wordString)
    {
        IsChecking = false;
        Word = wordString;

        InputCharList.Clear();
        char[] letters = Word.ToCharArray();
        RandomizeCharArray(ref letters);

        LettersFiled.MakeLetterList(letters);
        ClearOldLetters();
    }

    private static void ClearOldLetters()
    {
        foreach (Transform t in WordField.WordParent)
        {
            Destroy(t.gameObject);
        }
    }

    private static void RandomizeCharArray(ref char[] beforeCharArray)
    {
        for(int i = 0; i < beforeCharArray.Length; i++)
        {
            char tmp = beforeCharArray[i];
            int rv = Random.Range(i, beforeCharArray.Length);

            beforeCharArray[i] = beforeCharArray[rv];
            beforeCharArray[rv] = tmp;
        }
    }

    public static void PlaceWordLetter(GameObject letterGO, char letter)
    {
        letterGO.transform.SetParent(WordField.WordParent);
        InputCharList.Add(letter);

        if(Word.Length == InputCharList.Count)
        {
            Instance.StartCoroutine(nameof(Checking));
        }
    }

    private IEnumerator Checking()
    {
        IsChecking = true;
        bool IsWin = Word == new string(InputCharList.Select(c => c).ToArray());

        yield return new WaitForSeconds(0.5f);
        GameManager.OnGameFinished?.Invoke(IsWin);
    }
}
