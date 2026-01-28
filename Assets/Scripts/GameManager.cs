using UnityEngine;
using TMPro; // Nécessaire pour le texte (TextMeshPro)

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Score")]
    public int score = 0;
    public int scoreToWin = 5;

    [Header("Interface de Fin")]
    public GameObject endScreenUI; // Ton Canvas (Panel)
    public TextMeshProUGUI scoreTextUI; // Le texte du score
    public float distanceFromEyes = 1.5f; // Distance d'apparition (en mètres)

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (endScreenUI != null) endScreenUI.SetActive(false);
    }

    public void AddPoint()
    {
        score++;
        Debug.Log($"Score : {score} / {scoreToWin}");

        if (score >= scoreToWin)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        if (endScreenUI != null)
        {
            // 1. Activer l'interface
            endScreenUI.SetActive(true);

            // 2. Placer l'interface devant les yeux du joueur
            PositionUIInFrontOfPlayer();

            // 3. Mettre à jour le texte
            if (scoreTextUI != null)
            {
                scoreTextUI.text = $"SCORE FINAL : {score} / {scoreToWin}";
            }
        }
    }

    void PositionUIInFrontOfPlayer()
    {
        // On cherche la caméra principale (le casque VR)
        Transform cameraTransform = Camera.main.transform;

        if (cameraTransform != null)
        {
            // On place l'UI devant la caméra à la distance voulue
            endScreenUI.transform.position = cameraTransform.position + (cameraTransform.forward * distanceFromEyes);
            
            // On tourne l'UI pour qu'elle regarde le joueur
            endScreenUI.transform.rotation = Quaternion.LookRotation(endScreenUI.transform.position - cameraTransform.position);
            
            // Optionnel : On s'assure qu'elle est droite (pas penchée si le joueur penche la tête)
            Vector3 euler = endScreenUI.transform.eulerAngles;
            endScreenUI.transform.eulerAngles = new Vector3(0, euler.y, 0);
        }
    }

    [ContextMenu("TEST : Gagner Immédiatement")] 
    public void DebugWin()
    {
        Debug.Log("⚠️ VICTOIRE FORCÉE (DEBUG) ⚠️");
        // On remplit le score pour que l'affichage soit cohérent (5/5)
        score = scoreToWin; 
        
        // On lance la victoire
        WinGame(); 
    }
}
