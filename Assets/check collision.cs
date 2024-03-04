using Unity.VisualScripting;
using UnityEngine;

public class checkcollision : MonoBehaviour
{
    [SerializeField] private GameObject[] oppositeWalls = new GameObject[2];

    [SerializeField] private int targetWall = 0;
    private float collisionCooldown = 0.5f; // Cooldown period in seconds
    private float lastCollisionTime;
    
    PlayerManager playerManager;
    
    void Start(){
        if(gameObject.name.Equals("White"))
            playerManager = Managers.WhitePlayer;
        else
            playerManager = Managers.BluePlayer;
    }

    public void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag.Equals("Player") && collision.gameObject != gameObject && collision.isTrigger == false)
        {
            playerManager.ChangeHealth(-20);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" && Time.time - lastCollisionTime > collisionCooldown)
        {
            playerManager.ChangeHealth((int)Mathf.Ceil(-1 * Mathf.Abs(collision.collider.attachedRigidbody.angularVelocity.magnitude)));
            collision.collider.attachedRigidbody.AddForce(collision.rigidbody.angularVelocity * -1, ForceMode.Impulse);
            lastCollisionTime = Time.time;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Ball" && Time.time - lastCollisionTime > collisionCooldown)
        {
            hit.collider.attachedRigidbody.AddForce(hit.moveDirection * 100, ForceMode.Impulse);
            lastCollisionTime = Time.time;
            
        }
        if (hit.gameObject.Equals(oppositeWalls[targetWall]))
        {
            targetWall = (targetWall + 1) % 2;
            transform.Rotate(0, 180, 0);
        }
    }
}
