using UnityEngine;

public class Trash : MonoBehaviour
{
    enum TrashState
    {
        Dirty, Wet, Clean
    }

    [SerializeField] private TrashState _trashState;
    [SerializeField] private GameObject _dirtyVisual;
    [SerializeField] private GameObject _wetVisual;

    private void Start()
    {
        UpdateIcon();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cleaner"))
        {
            if (_trashState == TrashState.Dirty)
            {
                _trashState = TrashState.Wet;
                UpdateIcon();
            }
        }

        if (other.CompareTag("Dryer"))
        {
            if (_trashState == TrashState.Wet)
            {
                _trashState = TrashState.Clean;
                UpdateIcon();
            }
        }
    }

    private void UpdateIcon()
    {
        _dirtyVisual.SetActive(_trashState == TrashState.Dirty);
        _wetVisual.SetActive(_trashState == TrashState.Wet);
    }

    public bool IsClean()
    {
        return _trashState == TrashState.Clean;
    }
}
