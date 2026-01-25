using UnityEditor.UIElements;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [SerializeField] private enum _trashTag { Liquid, Solid, Glass };
    [SerializeField] private ParticleSystem _greenEffect;
    [SerializeField] private ParticleSystem _redEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_trashTag.ToString()))
        {
            _greenEffect.Play();
            Destroy(other.gameObject);
        }
        else
        {
            _redEffect.Play();
            Destroy(other.gameObject);
        }
    }
}
