using UnityEngine;

public class LettersFiledController : MonoBehaviour
{
    GameObject LetterCardPrefab { get; set; }
    private void Awake()
    {
        LetterCardPrefab = Resources.Load("Letters/letter card", typeof(GameObject)) as GameObject;
    }

    public void MakeLetterList(char[] lettersArray)
    {
        foreach(char c in lettersArray)
        {
            Instantiate(LetterCardPrefab, transform).GetComponent<LetterCard>().SetLetter(c);
        }
    }
}