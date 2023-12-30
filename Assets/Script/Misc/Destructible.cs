using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX; //tạo biến gameobject để chứa particle effect
    private void OnTriggerEnter2D(Collider2D collision) //void trigger để xác định chạm trigger và collider
    {
        if (collision.CompareTag("Weapon")) //nếu va chạm với collider có tag weapon
        {
            GetComponent<PickUpSpawner>().DropItems();
            Instantiate(destroyVFX,transform.position, Quaternion.identity); //tạo ra gameobject ở vị trí mặc định và k độ xay
            Destroy(gameObject); //phá huỷ gameobject chứa script
        }
    }
}
