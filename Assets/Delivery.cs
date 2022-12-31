using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor;
    [SerializeField] Color32 noPackageColor;

    SpriteRenderer spriteRenderer;
    Driver driver;

    [SerializeField] bool hasPackage = false;
    [SerializeField] float packageDestroyDelay = 1f;

    private void Start()
    {
        driver = GetComponent<Driver>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package" && !hasPackage)
        {            
            hasPackage = true;
            Destroy(collision.gameObject, packageDestroyDelay);
            Debug.Log("you picked package");
            spriteRenderer.color = hasPackageColor;
        }
        else if(collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("you delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        else if (collision.tag == "Obstacle")
        {
            driver.SlowSpeed();
            Debug.Log("SlowSpeed");
        }
        else if (collision.tag == "SpeedUp")
        {
            driver.SpeedUp();
            Debug.Log("SpeedUp");
        }

    }
}
