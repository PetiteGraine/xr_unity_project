using UnityEngine;
using UnityEngine.UI; // Si tu utilises le Canvas

[System.Serializable] // Important pour voir la liste dans l'Inspecteur
public struct FlaskProfil
{
    public string name;           // Juste pour t'y retrouver (ex: "Acide Sulfurique")
    public ChemicalType type;     // L'enum (Identité logique)
    public Sprite picto;          // L'image (Identité visuelle)
    public Color liquidColor;     // (Optionnel) La couleur du liquide associée
}