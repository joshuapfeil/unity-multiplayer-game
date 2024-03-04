using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float timeAlive = 0;
    private float timeToLive = 60;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 1)
            rb.AddForce(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), ForceMode.Impulse);
        timeAlive += Time.deltaTime;
        if (timeAlive >= timeToLive)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody != null)
            rb.AddForce(collision.rigidbody.angularVelocity * -1, ForceMode.Impulse);

    }
}
