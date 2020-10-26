using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBoss : MonoBehaviour
{
    public Transform leftShoot,rightShoot;
    public float shootSpeed;
    public GameObject Shuriken;
    private float fireTime = 0.5f;
    private float movementSpeed = 3f;
    public float distance;

    private bool moveRight = true;

    public Transform groundDectect;

    // Update is called once per frame
    void Update()
    {
        fireTime -= Time.deltaTime;
        if (fireTime < 0)
        {
            ShootShurikens();
            fireTime = 2;
        }
        WanderingBoss();
    }

    public void WanderingBoss()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDectect.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
        {
            if(moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }
    public void ShootShurikens()
    {
        GameObject obj = ObjectPooler.Instance.GetFromPool(); //getting object from the object poolder getpooledobject method.
        GameObject obj2 = ObjectPooler.Instance.GetFromPool();

        if (obj == null || obj2 ==null )
            return;

        obj.transform.position = leftShoot.transform.position;
        obj2.transform.position = rightShoot.transform.position;

        obj.SetActive(true);
        obj2.SetActive(true);
    }
}
