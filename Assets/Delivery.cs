using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(0, 0, 0, 0);




    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Detected!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Picked");
            hasPackage = true;
            Destroy(other.gameObject, 0.3f);
            spriteRenderer.color = hasPackageColor;

        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered Package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }

}
