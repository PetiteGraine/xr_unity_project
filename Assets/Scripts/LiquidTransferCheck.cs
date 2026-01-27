using UnityEngine;

public class LiquidTransferCheck : MonoBehaviour
{
    [Header("Réglages")]
    public float anglePourVerser = 45f;

    // Référence au manager pour pouvoir vider la fiole
    private FlaskManager myManager;

    [SerializeField] private bool estAuDessusBac = false;
    [SerializeField] private bool estProcheBidon = false;
    private bool fauteDejaEnregistree = false;

    void Start()
    {
        // On récupère le script FlaskManager automatiquement
        myManager = GetComponent<FlaskManager>();
    }

    void Update()
    {
        float angleActuel = Vector3.Angle(transform.up, Vector3.up);
        bool estEnTrainDeVerser = angleActuel > anglePourVerser;

        // Si on verse dans le bidon
        if (estEnTrainDeVerser && estProcheBidon)
        {
            // 1. DANS TOUS LES CAS : On vide visuellement la fiole
            // Car physiquement, le liquide coule, même si c'est une erreur.
            VerserLiquide();

            // 2. Ensuite, on juge si c'est bien ou mal pour le score/feedback
            if (estAuDessusBac)
            {
                Debug.Log("Transfert OK (Sécurisé)");
            }
            else
            {
                EnregistrerFaute("Transfert hors zone de rétention !");
            }
        }
        else if (estEnTrainDeVerser && !estProcheBidon)
        {
             // Optionnel : Vous pouvez aussi vider la fiole ici si on verse par terre
        }
    }

    // ... (Gardez vos fonctions OnTriggerEnter et OnTriggerExit telles quelles) ...
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZoneSecurite")) estAuDessusBac = true;
        if (other.CompareTag("Bidon")) estProcheBidon = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZoneSecurite")) estAuDessusBac = false;
        if (other.CompareTag("Bidon")) estProcheBidon = false;
    }

    void EnregistrerFaute(string message)
    {
        if (!fauteDejaEnregistree)
        {
            Debug.LogError("FAUTE HSE : " + message);
            fauteDejaEnregistree = true; 
        }
    }

    void VerserLiquide()
    {
        // On appelle le manager pour rendre le liquide transparent
        if (myManager != null)
        {
            myManager.EmptyFlask();
        }
    }
}