using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] private Sprite death;
    private SpriteRenderer sR;
    [SerializeField] private Collider2D deathCollider;
    private Collider2D coll;
    private NPC npc;
    private NPCText npcText;
    private HealingNPC healingNPC;
    private Animator anim;
    void Start()
    {
       
        npc= GetComponent<NPC>();
        npcText = GetComponent<NPCText>();
        healingNPC = GetComponent<HealingNPC>();
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        Final();
    }

   
    void Update()
    {
        
    }

    private void Final()
    {
        if (PlayerCheck.Instance.SecondBossDeath == true)
        {
            DestroyImmediate(npc);
            DestroyImmediate(npcText);
            DestroyImmediate(healingNPC);
            anim.enabled = false;
            coll.enabled = false;
            deathCollider.enabled = true;
            sR.sprite = death;
        }
    }
}
