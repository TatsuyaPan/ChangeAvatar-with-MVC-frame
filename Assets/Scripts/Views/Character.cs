using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, GameObject>> bodyParts;
    private Animation anim;
    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    private void PlayAct(string partName)
    {
        switch (partName)
        {
            case RoleDefine.top:
                anim.CrossFade("item_shirt");
                anim.CrossFadeQueued("idle1");
                break;
            case RoleDefine.pants:
                anim.CrossFade("item_pants");
                anim.CrossFadeQueued("idle1");
                break;
            case RoleDefine.shoes:
                anim.CrossFade("item_boots");
                anim.CrossFadeQueued("idle1");
                break;
        }
    }


    public void SetCharacter(string partName, string assistantName)
    {
        Dictionary<string, GameObject> part;
        if (bodyParts.TryGetValue(partName, out part))
        {
            foreach (var partDic in part)
            {
                partDic.Value.SetActive(partDic.Key == assistantName);
            }
        }
        PlayAct(partName);
    }


    public void InitCharacterParts()
    {
        bodyParts = new Dictionary<string, Dictionary<string, GameObject>>();
        SkinnedMeshRenderer[] meshs = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (var mesh in meshs)
        {
            string[] nameSplits = mesh.name.Split('-');
            if (nameSplits.Length < 2) continue;

            Dictionary<string, GameObject> innerParts;
            if (!bodyParts.TryGetValue(nameSplits[0], out innerParts))
            {
                innerParts = new Dictionary<string, GameObject>();
                bodyParts.Add(nameSplits[0], innerParts);
            }
            innerParts.Add(nameSplits[1], mesh.gameObject);
        }

        foreach (var part in bodyParts)
        {
            int index = 0;
            foreach (var item in part.Value)
            {
                item.Value.SetActive(index == 0);
                index++;
            }
        }

    }

}
