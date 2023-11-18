using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AI_Types
{
    Archer,
    Warrior,
    Mage,
    Ninja
}
public class AiBehaviour : MonoBehaviour
{
    Dictionary<AI_Types, int> aiModelIndices = new Dictionary<AI_Types, int>()
    {
        { AI_Types.Archer, 0 },
        { AI_Types.Warrior, 1 },
        { AI_Types.Mage, 2 },
        {AI_Types.Ninja,3 }
    };
    [Header("State")]
    public string currentState;
    public AI_Types aiTypes;
    [Header("References")]
    public List<GameObject> aiModel;
    public Animator animator;
    public NavMeshAgent agent;
    public Collider col;
    [Header("AttackRange")]
    public float range;
    [Header("EnemyValues")]
    public bool isDead = false;
    public float health;
    public float damage;
    public new string tag = "Team1";
    [Header("Archer-VFX")]
    public GameObject Arrow;
    public Transform spawnArcherFX;
    [Header("Warrior-VFX")]
    public GameObject AttackWarrior;
    public Transform spawnWarriorAttackFX;
    [Header("Mage-VFX")]
    public GameObject MagePow;
    public Transform spawnMageProjFX;
    [Header("Ninja-VFX")]
    public GameObject Slash;
    public Transform slashFX;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<Collider>();
        Action<AI_Types> activateAiModel = (AI_Types aiType) =>
        {
            aiModel[aiModelIndices[aiType]].SetActive(true);
            animator = aiModel[aiModelIndices[aiType]].GetComponent<Animator>();
        };
        activateAiModel(aiTypes);

        switch (aiTypes)
        {
            case AI_Types.Archer:
                health = GameManager.Instance.archerHealth;
                range = GameManager.Instance.archerRange;
                damage = GameManager.Instance.archerDamage;

                break;
            case AI_Types.Warrior:
                health = GameManager.Instance.warriorHealth;
                range = GameManager.Instance.warriorRange;
                damage = GameManager.Instance.warriorDamage;

                break;
            case AI_Types.Mage:
                health = GameManager.Instance.mageHealth;
                range = GameManager.Instance.mageRange;
                damage = GameManager.Instance.mageDamage;

                break;
            case AI_Types.Ninja:
                health = GameManager.Instance.ninjaHealth;
                range = GameManager.Instance.ninjaRange;
                damage = GameManager.Instance.ninjaDamage;

                break;
            default:
                break;
        }

    }

    private void Update()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (animator != null)
        {
            AnimationClip currentClip = GetCurrentAnimatorClip(animator, 0);
            // Store the animation name as a string
            if (currentClip != null)
            {
                currentState = currentClip.name;
            }
            else
            {
                currentState = "No animation playing";
            }
        }
        else
        {
            currentState = "Animator reference not set";
        }
    }
    private AnimationClip GetCurrentAnimatorClip(Animator anim, int layer)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(layer);
        return anim.GetCurrentAnimatorClipInfo(layer)[0].clip;
    }


}