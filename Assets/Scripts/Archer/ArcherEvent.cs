using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEvent : MonoBehaviour
{
    AiBehaviour newAiBehaviour;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        newAiBehaviour = GetComponentInParent<AiBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShootArrow()
    {
        GameObject arrowFX = Instantiate(newAiBehaviour.Arrow, newAiBehaviour.spawnArcherFX.position, newAiBehaviour.spawnArcherFX.rotation);
        Rigidbody bulletRigidbody = arrowFX.AddComponent<Rigidbody>();
        bulletRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
