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
    [SerializeField] private IndustryManager IndustryManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_trashType.ToString()) && other.GetComponent<Trash>().IsClean())
        {
            _greenEffect.Play();
            Destroy(other.gameObject);
            IndustryManager.UpdateNumbers(true);
        }
        else if (other.CompareTag("Liquid") || other.CompareTag("Solid") || other.CompareTag("Glass"))
        {
            _redEffect.Play();
            Destroy(other.gameObject);
            IndustryManager.UpdateNumbers(false);
        }
    }
}
