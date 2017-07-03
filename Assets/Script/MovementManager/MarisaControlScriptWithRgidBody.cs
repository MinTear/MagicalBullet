using UnityEngine;
using System.Collections;
using Assets.Script.InputManager;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]


public class MarisaControlScriptWithRgidBody : MonoBehaviour
{
    // 以下キャラクターコントローラ用パラメタ
    // ジャンプ威力
    public float MarisaJumpPower = 4.0f;
    // キャラクターコントローラ（カプセルコライダ）の参照
    private CapsuleCollider col;
    private Rigidbody rb;
    // キャラクターコントローラ（カプセルコライダ）の移動量
    private Vector3 velocity;
    // CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
    private float orgColHight;
    private Vector3 orgVectColCenter;

    private Animator anim;							// キャラにアタッチされるアニメーターへの参照
    private AnimatorStateInfo currentBaseState;			// base layerで使われる、アニメーターの現在の状態の参照

    // アニメーター各ステートへの参照
    static int masterSparkState = Animator.StringToHash("Base Layer.MasterSpark");
    static int damagedState = Animator.StringToHash("Base Layer.Damaged");
    static int guardState = Animator.StringToHash("Base Layer.Guard");
    static int rightArmUpState = Animator.StringToHash("Base Layer.RightArmUp");
    static int walkBackState = Animator.StringToHash("Base Layer.WalkBack");

    public static int MasterSparkState { get { return MarisaControlScriptWithRgidBody.masterSparkState; } }
    public static int DamagedState { get { return MarisaControlScriptWithRgidBody.damagedState; } }
    public static int GuardState { get { return MarisaControlScriptWithRgidBody.guardState; } }

    float count = 0;

    // 初期化
    void Start()
    {
        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();
        // CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        // CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
        orgColHight = col.height;
        orgVectColCenter = col.center;

    }


    // 以下、メイン処理.
    void Update()
    {
        // 全ての状況で呼ばれる処理
        IInputListener inputListener = InputListenerFactory.GetInputListener();
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// 参照用のステート変数にBase Layer (0)の現在のステートを設定する
        rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする

        // Cキーを離すとGuard状態を解除。関数の呼び出しのタイミングの関係でここに書く。
        if (Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("Guard", false);
        }

        // 以下、Animatorの各ステート中での処理

        // Locomotion中の処理
        // 現在のベースレイヤーがlocoStateの時
        if (currentBaseState.nameHash == UCCSWRBforMarisa.LocoState)
        {
            // Jキーを入力したらMasterSpark状態になる
            if (inputListener.IsStrongSkillPushed)
            {
                anim.SetBool("MasterSpark", true);
            }
            // Kキーを入力したらRightArmUp状態になる
            else if (inputListener.IsMediumSkillPushed)
            {
                anim.SetBool("RightArmUp", true);
            }
            // Cキーを入力したらGuard状態になる
            else if (inputListener.IsGuardPushed)
            {
                anim.SetBool("Guard", true);
            }
        }

        // WalkBack中の処理
        // 現在のベースレイヤーがwalkBackStateの時
        if (currentBaseState.nameHash == walkBackState)
        {
            // Jキーを入力したらMasterSpark状態になる
            if (inputListener.IsStrongSkillPushed)
            {
                anim.SetBool("MasterSpark", true);
            }
            // Kキーを入力したらRightArmUp状態になる
            else if (inputListener.IsMediumSkillPushed)
            {
                anim.SetBool("RightArmUp", true);
            }
            // Zキーを入力したらJump状態になる
            else if (inputListener.IsJumpPushed)
            {
                rb.AddForce(Vector3.up * MarisaJumpPower, ForceMode.VelocityChange);
                anim.SetBool("Jump", true);
            }
            // Cキーを入力したらGuard状態になる
            else if (inputListener.IsGuardPushed)
            {
                anim.SetBool("Guard", true);
            }
        }

        // Jump中の処理
        // 現在のベースレイヤーがjumpStateの時
        if (currentBaseState.nameHash == UCCSWRBforMarisa.JumpState)
        {
            // Cキーを入力したらGuard状態になる
            if (inputListener.IsGuardPushed)
            {
                anim.SetBool("Guard", true);
            }
        }

        // Idle または Rest中の処理
        // 現在のベースレイヤーがidleState または restStateの時
        else if (currentBaseState.nameHash == UCCSWRBforMarisa.IdleState ||
                 currentBaseState.nameHash == UCCSWRBforMarisa.RestState)
        {
            /*          // 特にIdle中の時は
                        if (currentBaseState.nameHash == UCCSWRBforMarisa.IdleState)
                        {
                            // ピリオドキーを入力したらRest状態になる
                            if (Input.GetKeyDown(KeyCode.Period))
                            {
                                anim.SetBool("Rest", true);
                            }
                        }
            */

            // Zキーを入力したらJump状態になる
            if (inputListener.IsJumpPushed)
            {
                rb.AddForce(Vector3.up * MarisaJumpPower, ForceMode.VelocityChange);
                anim.SetBool("Jump", true);
            }
            // Cキーを入力したらGuard状態になる
            else if (inputListener.IsGuardPushed)
            {
                anim.SetBool("Guard", true);
            }
            // Jキーを入力したらMasterSpark状態になる
            else if (inputListener.IsStrongSkillPushed)
            {
                anim.SetBool("MasterSpark", true);
            }
            // Kキーを入力したらRightArmUp状態になる
            else if (inputListener.IsMediumSkillPushed)
            {
                anim.SetBool("RightArmUp", true);
            }
        }

        // Guard中の処理
        // 現在のベースレイヤーがguardStateの時
        /*else if (currentBaseState.nameHash == guardState)
        {
            transform.localPosition += new Vector3(0, 0, 0) * Time.deltaTime;

            if ((OVRDevice.IsHMDPresent() == false) && (OVRDevice.IsSensorPresent() == false))
            {
                transform.localEulerAngles += new Vector3(0, 0, 0) * Time.deltaTime;
            }
        }*/

        // MasterSpark中の処理
        // 現在のベースレイヤーがmasterSparkStateの時
        else if (currentBaseState.nameHash == masterSparkState)
        {
            count = count + Time.deltaTime;
            transform.localPosition += new Vector3(0, 0, 0) * Time.deltaTime;
            // ステートが遷移中でない場合 かつ countが120以上の場合
            // MasterSpark bool値をfalseにしIdleに移動
            if (!anim.IsInTransition(0) && count >= 0.7f)
            {
                count = 0;
                anim.SetBool("MasterSpark", false);
            }

            // MasterSparkMakerが破壊されている場合
            if (GameObject.Find("MasterSparkMaker(Clone)") == null)
            {
                anim.SetBool("MasterSpark", false);
            }
        }

        // RightArmUp中の処理
        // 現在のベースレイヤーがrightArmUpStateの時
        else if (currentBaseState.nameHash == rightArmUpState)
        {
            //固有の処理は今のところ無い
        }

        // Damaged中の処理
        // 現在のベースレイヤーがのdamagedStateの時
        else if (currentBaseState.nameHash == damagedState)
        {
            count = count + Time.deltaTime;
            transform.localPosition += new Vector3(0, 0, 0) * Time.deltaTime;
            // ステートが遷移中でない場合 かつ countが30以上の場合
            // MasterSpark bool値をfalseにしIdleに移動
            if (!anim.IsInTransition(0) && count >= 0.5f)
            {
                count = 0;
                anim.SetBool("Damaged", false);
            }
        }
    }

    void LateUpdate()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy-Effect"))
        {
            Debug.Log("Enemy-Effectが魔理沙に当たりました");
            anim.SetBool("Damaged", true);
        }
    }
}