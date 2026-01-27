using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int NumberOfTrash;
    public int NumberOfCollectedTrash;
    public int NumberOfRemainingTrash;
    [SerializeField] private GameObject _canvasGameOver;
    [SerializeField] private TextMeshProUGUI _trashInfoText;

    private void Start()
    {
        NumberOfTrash = FindObjectsByType<Trash>(FindObjectsSortMode.None).Length;
        NumberOfCollectedTrash = 0;
        NumberOfRemainingTrash = NumberOfTrash;
        _canvasGameOver.SetActive(false);
    }

    public void UpdateNumbers(bool isCollectedCorrectly)
    {
        if (isCollectedCorrectly)
        {
            NumberOfCollectedTrash++;
        }
        NumberOfRemainingTrash--;
        if (NumberOfRemainingTrash <= 0)
        {
            FindObjectsByType<GameManager>(FindObjectsSortMode.None)[0].GameOver();
        }
    }

    public void GameOver()
    {
        _canvasGameOver.SetActive(true);
        _trashInfoText.text = $"Déchets correctement jeté: {NumberOfCollectedTrash}/{NumberOfTrash}";
    }
}
