using UnityEngine;

// 1. On définit la liste des produits possibles (Ajoutes-en autant que tu veux)
public enum ChemicalType
{
    Acid,
    Bottle,
    Exclam,
    Explos,
    Flamme,
    Pollu,
    RondFlamm,
    Silhouette,
    Skull
}

public class ChemicalIdentity : MonoBehaviour
{
    // 2. On choisit le type dans l'inspecteur
    public ChemicalType chemicalType;
}