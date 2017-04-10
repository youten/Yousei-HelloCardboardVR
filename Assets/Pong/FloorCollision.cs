using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ボールが床に落ちたことを通知する
public class FloorCollision : MonoBehaviour
{
    // 通知対象のオブジェクト
    public GameObject MeObject;

    void OnCollisionEnter (Collision col)
    {
        MeObject.SendMessage ("OnBallFell");
    }
}