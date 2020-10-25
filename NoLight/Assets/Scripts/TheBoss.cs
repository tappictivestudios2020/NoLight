using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBoss : MonoBehaviour
{
    public Transform leftShoot,rightShoot;
    public float shootSpeed;
    public GameObject Shuriken;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootShurikens();
            Debug.Log("Shoot");
        }
    }

    public void ShootShurikens()
    {
        //GameObject shurikenRight = Instantiate(Shuriken) as GameObject;

        GameObject obj = ObjectPooler.Instance.GetFromPool(); //getting object from the object poolder getpooledobject method.
        if (obj == null)
            return;

        obj.transform.position = leftShoot.transform.position;

        obj.SetActive(true);
        //shurikenRight.transform.position = rightShoot.transform.position;
    }
}
