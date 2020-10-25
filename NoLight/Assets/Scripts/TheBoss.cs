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
        ShootShurikens();
    }

    public void ShootShurikens()
    {
        GameObject shurikenLeft = Instantiate(Shuriken) as GameObject;
        GameObject shurikenRight = Instantiate(Shuriken) as GameObject;
        shurikenLeft.transform.position = leftShoot.transform.position;
        shurikenRight.transform.position = rightShoot.transform.position;
    }
}
