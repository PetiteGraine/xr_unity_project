using UnityEngine;
using System.Collections.Generic; // Indispensable pour les Listes

public class FlaskSpawner : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject flaskPrefab;   // Ton prefab "FIOLE_ROOT"
    public Transform[] spawnPoints;  // Liste de tes Empty Objects (points d'apparition)
    public int flasksToSpawn = 5;    // Nombre de fioles à faire apparaître

    void Start()
    {
        SpawnRandomFlasks();
    }

    void SpawnRandomFlasks()
    {
        // 1. On crée une copie de la liste des points pour pouvoir "rayer" ceux qu'on utilise
        List<Transform> availablePoints = new List<Transform>(spawnPoints);

        // Sécurité : On ne peut pas spawner plus de fioles que de points disponibles
        int limit = Mathf.Min(flasksToSpawn, availablePoints.Count);

        for (int i = 0; i < limit; i++)
        {
            // 2. Tirage au sort d'une position unique
            int randomIndex = Random.Range(0, availablePoints.Count);
            Transform selectedPoint = availablePoints[randomIndex];

            // 3. On retire ce point de la liste pour ne pas le réutiliser
            availablePoints.RemoveAt(randomIndex);

            // 4. Création de la fiole
            GameObject newFlask = Instantiate(flaskPrefab, selectedPoint.position, selectedPoint.rotation);

            // 5. INITIALISATION DU PROFIL (Liaison avec FlaskManager)
            FlaskManager manager = newFlask.GetComponent<FlaskManager>();
            if (manager != null)
            {
                // On demande à la fiole de choisir son identité (Picto + Type + Couleur)
                manager.SetRandomFlask();
            }
            else
            {
                Debug.LogWarning("Attention : Pas de FlaskManager trouvé sur le prefab de la fiole !");
            }
        }
    }
}