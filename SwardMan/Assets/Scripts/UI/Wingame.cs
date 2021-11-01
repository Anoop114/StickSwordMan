using UnityEngine;

public class Wingame : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject gameManager;
    public GameObject WinUi;

    private GameManager manager;
    void Start()
    {
        manager = gameManager.GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.PauseGame();
            WinUi.SetActive(true);
        }

    }
}
