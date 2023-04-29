using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public bool isDestoryed;
    public GameObject killEffect;
    public MeshRenderer meshRen;
    public Score score;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Car")
        {
            if(this.isDestoryed == false)
            {
                Destory();
            }
            if(collisionInfo.collider.GetComponent<Car>().isDestoryed == false)
            {
                collisionInfo.collider.GetComponent<Car>().Destory();
            }
        }
    }

    public void Destory()
    {
        score.ChangeScore(1);
        score.ComboIncrese();
        isDestoryed = true;
        Instantiate(killEffect, this.transform.position, this.transform.rotation);
        foreach (Material mat in meshRen.materials)
        {
            mat.color = Color.black;
        }
    }
}
