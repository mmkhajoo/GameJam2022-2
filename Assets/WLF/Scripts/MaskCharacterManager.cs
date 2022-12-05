using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class MaskCharacterManager : MonoBehaviour
{
    public Transform StartPos,EndPos;
    public float ScaleModifier;
    public GameObject PlayerMask,Player;
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PlayerMask == null)
        {
            PlayerMask=GameObject.FindWithTag("CharacterMask");
            return;
        }
        
        var distancePassed = (PlayerMask.transform.position.x-StartPos.position.x)/(EndPos.position.x - StartPos.position.x);
        var newScale = 1 + (distancePassed * ScaleModifier);
        PlayerMask.transform.localScale = newScale * Vector3.one;
    }
}
