using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireBreath : MonoBehaviour
{
    public float timeToSelect = 3.0f;
    public int score;
    Transform cam;
    private float countDown;
    public bool isBreathing;
    public ParticleSystem hitEffect;
    public GameObject breath;
    public int breathcount;
    void Start()
    {
        score = 0;
        countDown = timeToSelect;
        cam = Camera.main.transform;
    }
    void Update()
    {
        if(isBreathing == true)
        {
            Debug.Log("Raw!");  
            Ray ray = new Ray(cam.position, cam.rotation * Vector3.forward);
            Debug.DrawRay(cam.position, cam.rotation * Vector3.forward, Color.green);
            RaycastHit hit;
            if(breathcount < 1)
            {
                //Instantiate(breath, cam.transform.position, cam.transform.rotation);
                breathcount++;
            }
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Car")
                {
                    Debug.Log("Hit a Car");
                    hit.collider.GetComponent<Car>().Destory();
                }
            }
        }
    }

    public void BreathTime()
    {
        if(isBreathing == false)
        {
            isBreathing = true;
            Debug.Log("Breathing!");
        }
    }

    public void NoMoreBreath()
    {
        isBreathing = false;
        breathcount = 0;
        Debug.Log("All Done");
    }
}
