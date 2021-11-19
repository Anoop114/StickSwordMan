using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealth : MonoBehaviour
{
    public GameObject health;

    public Vector3 center;
    public Vector3 size;
    private void Awake() {
        StartCoroutine(Count());        
    }
    
    IEnumerator Count()
    {
        yield return new WaitForSeconds(10);
        SpawnHealthInGame();
    }
    // IEnumerator DestroyObject()
    // {
    //     yield return new WaitForSeconds(20);
    //     Destroy(gameObject);
    // }

    private void SpawnHealthInGame()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),2f,Random.Range(-size.z / 2, size.z / 2));
        Instantiate(health,pos,Quaternion.identity);
        StartCoroutine(Count());
    }
    
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }
}
