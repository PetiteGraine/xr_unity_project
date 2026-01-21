using UnityEngine;
using UnityEngine.UI; // Nécessaire pour toucher à l'Image

public class FlaskSymbolUI : MonoBehaviour
{
    public Image symbolImage; // Glisse ton objet "Image" ici dans l'inspecteur
    public Sprite[] availableSymbols;

    public void ChangeSymbol(int index)
    {
        if(index >= 0 && index < availableSymbols.Length)
        {
            symbolImage.sprite = availableSymbols[index];
        }
    }
}