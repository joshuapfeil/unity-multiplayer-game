using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(other.gameObject.name.Equals("White"))
                Managers.WhiteInventory.AddItem(itemName);
            else
                Managers.BlueInventory.AddItem(itemName);
            Destroy(this.gameObject);
        }
    }

}