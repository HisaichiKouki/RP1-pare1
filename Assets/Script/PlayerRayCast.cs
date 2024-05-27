using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public float rayLength;
    public GameObject reticleObj;

    float a;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit[] hit=new RaycastHit[10];
        RaycastHit[] hit = Physics.RaycastAll(transform.position, Vector3.down, 100f);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            a++;
        }
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.CompareTag("HoleCollision1"))
            {

                print("Found an object - distance: " + hit[i].distance);
                Debug.DrawRay(transform.position, Vector3.down * hit[i].distance, Color.red, 0.0f);
                Vector3 newPosition = transform.position;
                newPosition.y -= hit[i].distance;
                reticleObj.transform.position = newPosition;
                return;

            }
        }


    }
}
