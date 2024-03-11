using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float timeAlive = 0;
    private float timeToLive = 60;
    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0, 100) < 1)
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

        if(rb.velocity.magnitude > 20)
        {
            if(collision.gameObject.name.Equals("WhiteWall"))
            {
                Managers.WhitePlayer.ChangeHealth(1);
                Debug.Log("impact WHITE");
                Destroy(gameObject);
            }
            else if(collision.gameObject.name.Equals("BlueWall"))
            {
                Managers.BluePlayer.ChangeHealth(1);
                Debug.Log("impact BLUE");
                Destroy(gameObject);
            }
        }

    }
}
