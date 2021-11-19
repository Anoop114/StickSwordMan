using UnityEngine;

public class IncreasePlayerHealth : MonoBehaviour
{
    private GameObject playerUI;
    private PlayerHealthAndWeapon playerHealth;
    private TextUpdate playerTextUpdate;
    void Start()
    {
        playerUI = GameObject.Find("GameManager");
        playerTextUpdate = playerUI.GetComponent<TextUpdate>();
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealthAndWeapon>();
            playerHealth.health += 10;
            playerTextUpdate.UpdateText();
            Destroy(gameObject);
        }
        if(other.CompareTag("EnemyCylinder"))
        {
            Destroy(gameObject);
        }
    }
    private void Update() {
        transform.Rotate(0f,-1f,0f);
    }
}
