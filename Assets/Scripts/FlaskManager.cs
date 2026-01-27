using UnityEngine;
using UnityEngine.UI; // Nécessaire si tu utilises l'UI Canvas pour le picto

public class FlaskManager : MonoBehaviour
{
    [Header("Configuration")]
    // La liste de toutes tes combinaisons possibles (à remplir dans l'inspecteur)
    public FlaskProfil[] availableProfiles; 

    [Header("Références Visuelles")]
    public Image pictoImageUI;      // Si méthode Canvas : L'image UI
    public Renderer liquidRenderer; // (Optionnel) Pour changer la couleur du liquide
    // public Renderer decalRenderer; // (Alternative) Si tu utilises la "Double Peau" au lieu du Canvas

    [Header("Références Logiques")]
    public ChemicalIdentity chemicalIdentity; // Le script d'identité qu'on a créé avant

    void Start()
    {
        // Exemple : Au démarrage, on en choisit un au hasard (ou tu peux appeler SetProfile(0) pour forcer le premier)
        // SetRandomFlask(); 
    }

    // Fonction principale pour définir la fiole
    public void SetProfile(int index)
    {
        if (index < 0 || index >= availableProfiles.Length)
        {
            Debug.LogError("Index de profil invalide !");
            return;
        }

        // 1. Récupérer les données
        FlaskProfil data = availableProfiles[index];

        // 2. Appliquer la Logique (Le Chemical Type)
        if (chemicalIdentity != null)
        {
            chemicalIdentity.chemicalType = data.type;
            // Astuce : On change aussi le nom de l'objet pour aider au debug
            gameObject.name = "Fiole_" + data.name;
        }

        // 3. Appliquer le Visuel (Le Picto)
        if (pictoImageUI != null)
        {
            pictoImageUI.sprite = data.picto;
        }
        
        // (Alternative : Si tu utilises un Mesh Renderer pour le picto au lieu de l'UI)
        /*
        if (decalRenderer != null) {
            decalRenderer.material.mainTexture = data.picto.texture;
        }
        */

        // 4. (Optionnel) Changer la couleur du liquide
        if (liquidRenderer != null)
        {
            MaterialPropertyBlock props = new MaterialPropertyBlock();
            liquidRenderer.GetPropertyBlock(props);
            props.SetColor("_Color1", data.liquidColor); // Vérifie le nom "_Color1" ou "_BaseColor"
            liquidRenderer.SetPropertyBlock(props);
        }
    }

    public void SetRandomFlask()
    {
        int randomIndex = Random.Range(0, availableProfiles.Length);
        SetProfile(randomIndex);
    }
}