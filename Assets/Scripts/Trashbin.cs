using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [SerializeField]
    enum TrashType
    {
        Liquid, Solid, Glass
    }

    [SerializeField] private TrashType _trashType;
    [SerializeField] private ParticleSystem _greenEffect;
    [SerializeField] private ParticleSystem _redEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_trashType.ToString()))
        {
            _greenEffect.Play();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Liquid") || other.CompareTag("Solid") || other.CompareTag("Glass"))
        {
            _redEffect.Play();
            Destroy(other.gameObject);
        }
    }
}
