using UnityEngine;

public class LiquidTransferCheck : MonoBehaviour
{
    [Header("Réglages")]
    public float anglePourVerser = 45f; // Angle min pour que le liquide coule

    // États internes (privés mais visibles en Debug mode)
    [SerializeField] private bool estAuDessusBac = false;
    [SerializeField] private bool estProcheBidon = false;
    private bool fauteDejaEnregistree = false;

    void Update()
    {
        // 1. Calcul de l'inclinaison de la fiole
        // On vérifie l'angle entre le haut de la fiole (up) et le haut du monde (Vector3.up)
        float angleActuel = Vector3.Angle(transform.up, Vector3.up);

        // Si l'angle est > 45°, on considère qu'on verse (ou > 135° selon ton modèle 3D)
        bool estEnTrainDeVerser = angleActuel > anglePourVerser;

        // --- LA LOGIQUE DE VALIDATION ---

        // Cas A : Le joueur verse DANS le bidon
        if (estEnTrainDeVerser && estProcheBidon)
        {
            if (estAuDessusBac)
            {
                // SUCCÈS : Tout va bien, on peut lancer l'animation du liquide
                VerserLiquide(); 
            }
            else
            {
                // ÉCHEC : On verse dans le bidon MAIS pas au-dessus du bac
                EnregistrerFaute("Transfert hors zone de rétention !");
            }
        }
        
        // Cas B : Le joueur renverse à côté (juste pour info)
        else if (estEnTrainDeVerser && !estProcheBidon)
        {
             // C'est juste renversé par terre
        }
    }

    // Détection des zones (Triggers)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZoneSecurite"))
        {
            estAuDessusBac = true;
            // Reset de la faute si on rentre dans la zone (optionnel)
            fauteDejaEnregistree = false; 
        }
        if (other.CompareTag("Bidon")) // Assure-toi d'avoir le tag "Bidon" sur le trigger du bidon
        {
            estProcheBidon = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZoneSecurite"))
        {
            estAuDessusBac = false;
        }
        if (other.CompareTag("Bidon"))
        {
            estProcheBidon = false;
        }
    }

    void EnregistrerFaute(string message)
    {
        if (!fauteDejaEnregistree)
        {
            Debug.LogError("FAUTE HSE : " + message);
            // Ici tu peux ajouter ton code pour noter le joueur :
            // GameManager.Instance.RetirerPoints(10);
            
            fauteDejaEnregistree = true; // Pour ne pas spammer l'erreur 60 fois par seconde
        }
    }

    void VerserLiquide()
    {
        // Ton code pour activer les particules ou vider la fiole
        Debug.Log("Transfert en cours (Sécurisé)...");
    }
}