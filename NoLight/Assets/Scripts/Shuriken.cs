using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private Vector2 screenBounds;
    // Start is called before the first frame update
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if the object is out of screen bound, if out of screen bounds then put back to queue
        if (gameObject.transform.position.y < -screenBounds.y)
        {
            ObjectPooler.Instance.AddToPool(gameObject); //adding the object back to the pool after it has been disabled.
        }
    }
}
