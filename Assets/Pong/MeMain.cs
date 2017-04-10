using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

// ゲームの開始(ボールの生成)と自機(バー)の位置制御を行う
public class MeMain : MonoBehaviour
{
    // 自機(バー)の最大座標
    public static float MAX_ME_X = 7.5f;
    private GameObject ballPrefab;
    private GameObject ball;

    void Start ()
    {
        ballPrefab = (GameObject)Resources.Load ("Pong/Ball");
        startGame ();
    }

    void Update ()
    {
        #if UNITY_EDITOR
        // キーボードによる自機の移動(Unityエディター上限定のデバッグ用)
        if (Input.GetKey (KeyCode.LeftArrow)) { // ←キー
            if (-MAX_ME_X < transform.position.x) {
                transform.Translate (Vector3.left * 0.3f); // 左へ            
            } 
        }
        if (Input.GetKey (KeyCode.RightArrow)) { // →キー
            if (transform.position.x < MAX_ME_X) {
                transform.Translate (Vector3.right * 0.3f); // 右へ
            }
        }
        #else // not UNITY_EDITOR

        // Cardboard (Google VR)での首振りによる自機の移動
        #if UNITY_5_6_OR_NEWER
        // Unity 5.6以降の場合はUnityネイティブのVR対応を利用することになるため、
        // PlayerSettingsのVirtual Reality SupportedチェックをONにして、
        // Cardboardコンポーネントを追加する必要があります。
        Quaternion head = InputTracking.GetLocalRotation(VRNode.Head);
        #else // 5.5 or older
        Quaternion head = GvrViewer.Instance.HeadPose.Orientation;
        #endif

        if (head != null) {
            float posX = Mathf.Clamp (head.y * 20.0f, -MAX_ME_X, MAX_ME_X);
            // move bar
            transform.position = new Vector3 (
                posX, // x
                transform.position.y, // y
                transform.position.z); // z
        }
        #endif
    }

    // receive Message from "FloorCollision"
    void OnBallFell ()
    {
        // ボールが床に落ちたらゲームを再開始
        startGame ();
    }

    void startGame ()
    {
        // ボールを生成してゲームを開始
        if (ball != null) {
            Destroy (ball);
        }
        // ボールの初期位置
        Vector3 pos = new Vector3 (
            transform.position.x,
            transform.position.y,
            transform.position.z + 1.0f);
        ball = (GameObject)Instantiate (ballPrefab, pos, transform.rotation);

        // ボールに初速を与える
        Rigidbody rb = ball.GetComponent<Rigidbody> ();
        if (rb != null) {
            rb.velocity = new Vector3 (
                Random.Range (-5.0f, 5.0f), // x
                0, // y
                10.0f); // z
        }
    }
}
