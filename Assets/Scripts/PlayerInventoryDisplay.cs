using UnityEngine;

public class PlayerInventoryDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject _inventory;

    private bool displayed;

    private void Awake()
    {
        displayed = false;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _inventory.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            displayed = !displayed;
            _inventory.gameObject.SetActive(displayed);
        }
    }
}

