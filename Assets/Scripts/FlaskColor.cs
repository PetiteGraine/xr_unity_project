using UnityEngine;

public class FlaskColor : MonoBehaviour
{
    // Glisse ici l'objet enfant qui doit changer de couleur (le liquide ou le symbole)
    [SerializeField] private MeshRenderer targetMeshRenderer; 

    // Le nom exact de la propriété couleur dans ton Shader (souvent "_BaseColor" en URP)
    private string colorProperty = "_Color1"; 

    public void SetColor(Color newColor)
    {
        if (targetMeshRenderer == null) return;

        // On utilise un PropertyBlock pour ne pas dupliquer le material en mémoire (Optimisation)
        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
        
        // On récupère les propriétés actuelles pour ne pas écraser le reste
        targetMeshRenderer.GetPropertyBlock(propBlock);
        
        // On change la couleur
        propBlock.SetColor(colorProperty, newColor);
        
        // On applique
        targetMeshRenderer.SetPropertyBlock(propBlock);
    }
}