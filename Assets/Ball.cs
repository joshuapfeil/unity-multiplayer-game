using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private int bounceCount = 0;
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
    }

    public void OnCollisionEnter(Collision collision)
    {
        bounceCount++;
        if (bounceCount >= 10)
        {
            Destroy(gameObject);
        }

    }
}
