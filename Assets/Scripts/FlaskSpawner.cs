using UnityEngine;

public class FlaskSpawner : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject flaskPrefab; // Ton prefab de fiole
    public Transform[] spawnPoints; // Liste de tes points d'apparition (Empty Objects)
    public Color[] liquidColors;   // Liste des couleurs possibles (Rouge, Vert, Bleu...)

    void Start()
    {
        SpawnFlasks();
    }

    void SpawnFlasks()
    {
        // Pour chaque point d'apparition...
        foreach (Transform spawnPoint in spawnPoints)
        {
            // 1. On crée la fiole
            GameObject newFlask = Instantiate(flaskPrefab, spawnPoint.position, spawnPoint.rotation);

            // 2. On choisit une couleur au hasard
            Color randomColor = liquidColors[Random.Range(0, liquidColors.Length)];

            // 3. On applique la couleur via le script qu'on a fait à l'étape 1
            FlaskColor colorScript = newFlask.GetComponent<FlaskColor>();
            if (colorScript != null)
            {
                colorScript.SetColor(randomColor);
            }
        }
    }
}