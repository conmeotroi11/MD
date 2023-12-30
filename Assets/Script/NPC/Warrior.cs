using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    [SerializeField] private Sprite death;
    [SerializeField] private Collider2D deathCollider;
    private Collider2D coll;
    private SpriteRenderer sR;
    private NPC npc;
    private NPCText npcText;
    private Stats stats;
    private Animator anim;
    void Start()
    {
        
        npc = GetComponent<NPC>();
        npcText = GetComponent<NPCText>();
        stats = GetComponent<Stats>();
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        Final();
    }




    private void Final()
    {
        if (PlayerCheck.Instance.SecondBossDeath == true)
        {
            DestroyImmediate(npc);
            DestroyImmediate(npcText);
            DestroyImmediate(stats);
            anim.enabled = false;
            coll.enabled = false;
            deathCollider.enabled = true;
            sR.sprite = death;
        }
    }
}
