using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEvent : MonoBehaviour
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

    public void SpawnAttack()
    {
        GameObject powersFX = Instantiate(newAiBehaviour.MagePow, newAiBehaviour.spawnMageProjFX.position, newAiBehaviour.spawnMageProjFX.rotation);
        VFXDamage vFXDamage = powersFX.GetComponent<VFXDamage>();
        vFXDamage.StartVFX(newAiBehaviour.tag);
        Rigidbody powProjRigidbody = powersFX.GetComponent<Rigidbody>();
        powProjRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
