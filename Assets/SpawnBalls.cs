
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0, 1000) < 1)
            SpawnBall();
    }

    private void SpawnBall(){
        GameObject obj = Instantiate(ballPrefab, new Vector3(transform.position.x + direction, transform.position.y + Random.Range(-1, 1), transform.position.z + Random.Range(-10, 10)), Quaternion.identity);
        Vector3 force = new Vector3(Random.Range(0, 10)* direction, 0, Random.Range(-10, 10));
        obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}
