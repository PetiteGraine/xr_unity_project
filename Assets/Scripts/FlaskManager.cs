using UnityEngine;
using UnityEngine.UI; 

public class FlaskManager : MonoBehaviour
{
    [Header("Configuration")]
    public FlaskProfil[] availableProfiles; 

    [Header("Références Visuelles")]
    public Image pictoImageUI;      
    public Renderer liquidRenderer; 

    [Header("Références Logiques")]
    public ChemicalIdentity chemicalIdentity; 

    // --- NOUVEAU : Gestion de la transparence ---
    [Header("État Vide")]
    public Material emptyLiquidMaterial; // Glissez votre material transparent (ex: M_Glass) ici
    private bool isEmpty = false;

    // ... (Gardez vos fonctions Start et SetProfile telles quelles) ...
    // Je remets SetProfile pour le contexte, assurez-vous qu'elle est là :
    public void SetProfile(int index)
    {
        if (index < 0 || index >= availableProfiles.Length) return;
        FlaskProfil data = availableProfiles[index];

        if (chemicalIdentity != null) chemicalIdentity.chemicalType = data.type;
        gameObject.name = "Fiole_" + data.name;

        if (pictoImageUI != null) pictoImageUI.sprite = data.picto;

        if (liquidRenderer != null)
        {
            MaterialPropertyBlock props = new MaterialPropertyBlock();
            liquidRenderer.GetPropertyBlock(props);
            props.SetColor("_Color1", data.liquidColor); 
            liquidRenderer.SetPropertyBlock(props);
        }
    }

    public void SetRandomFlask()
    {
        int randomIndex = Random.Range(0, availableProfiles.Length);
        SetProfile(randomIndex);
    }

    // --- NOUVELLE FONCTION ---
    [ContextMenu("TEST : Vider la Fiole")] // <--- AJOUTEZ CETTE LIGNE
    public void EmptyFlask()
    {
        if (isEmpty) return; // On ne vide pas deux fois

        // On change le material de l'enfant (le liquide) pour qu'il devienne transparent
        if (liquidRenderer != null && emptyLiquidMaterial != null)
        {
            liquidRenderer.material = emptyLiquidMaterial;
        }

        isEmpty = true;
    }
}