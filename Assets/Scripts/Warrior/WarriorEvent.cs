using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorEvent : MonoBehaviour
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
        GameObject attackFX = Instantiate(newAiBehaviour.AttackWarrior, newAiBehaviour.spawnWarriorAttackFX.position, newAiBehaviour.spawnWarriorAttackFX.rotation);
        VFXDamage vFXDamage = attackFX.GetComponent<VFXDamage>();
        vFXDamage.StartVFX(newAiBehaviour.tag);
        Rigidbody attackRigidbody = attackFX.AddComponent<Rigidbody>();
        attackRigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
