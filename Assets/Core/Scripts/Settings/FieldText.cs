using TMPro;
using UnityEngine;

public class FieldText : MonoBehaviour
{
    [SerializeField] private int _countLetters = 10;

    [field: SerializeField] public TextMeshProUGUI TextMesh { get; private set; }

    private void Start()
    {
        ClearText();
    }

    public void AddLetter(string letter)
    {
        if (TextMesh.text.ToCharArray().Length + 1 > _countLetters)
            return;

        TextMesh.text += letter;
    }

    public void ClearText()
    {
        TextMesh.text = "";
    }

}