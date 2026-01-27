using TMPro;
using UnityEngine;

public class IndustryManager : MonoBehaviour
{
    private int _numberOfTrash;
    private int _correctlySortedTrash;
    private int _remainingTrash;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private TextMeshProUGUI _correctlySortedText;

    [System.Obsolete]
    private void Start()
    {
        _canvas.SetActive(false);
        _numberOfTrash = FindObjectsOfType<Trash>().Length;
        _remainingTrash = _numberOfTrash;
    }

    public void UpdateNumbers(bool isCorrect)
    {
        if (isCorrect)
        {
            _correctlySortedTrash++;
        }
        _remainingTrash--;
        if (_remainingTrash <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        _correctlySortedText.text = $"Déchets correctement jeté: {_correctlySortedTrash}/{_numberOfTrash}";
        _canvas.SetActive(true);
    }
}
