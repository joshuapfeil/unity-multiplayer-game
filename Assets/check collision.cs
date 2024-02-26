using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class checkcollision : MonoBehaviour
{
    [SerializeField] private GameObject[] oppositeWalls = new GameObject[2];

    [SerializeField] private int targetWall = 0;
    private float collisionCooldown = 0.5f; // Cooldown period in seconds
    private float lastCollisionTime;
    public int score = 0;
    

    public TMP_Text scoreText;
    [SerializeField] private TMP_Text victoryText;
    
    public void OnTriggerEnter(Collider collision)
    {
        checkcollision chkcoll = collision.gameObject.GetComponent<checkcollision>();
        if (chkcoll != null && collision.gameObject != gameObject && collision.isTrigger == false)
        {
            chkcoll.scoreText.text = chkcoll.gameObject.name + " Score: " + ++chkcoll.score;
            victoryText.text = chkcoll.score >= 5 ? chkcoll.gameObject.name + " Wins!" : "";
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Ball" && Time.time - lastCollisionTime > collisionCooldown)
        {
            lastCollisionTime = Time.time;
            scoreText.text = gameObject.name + " Points: " + --score;
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.Equals(oppositeWalls[targetWall]))
        {
            targetWall = (targetWall + 1) % 2;
            transform.Rotate(0, 180, 0);
        }
    }
}
