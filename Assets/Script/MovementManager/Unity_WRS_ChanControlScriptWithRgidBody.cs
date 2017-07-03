//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using System.Collections;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Unity_WRS_ChanControlScriptWithRgidBody : MonoBehaviour
{

    public float animSpeed = 1.5f;				// アニメーション再生速度設定
    public float lookSmoother = 3.0f;			// a smoothing setting for camera motion
    public bool useCurves = true;				// Mecanimでカーブ調整を使うか設定する
    // このスイッチが入っていないとカーブは使われない
    public float useCurvesHeight = 0.5f;		// カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）
    bool right_step = false;
    bool left_step = false;
    int step_flame = 15;
    int count = 0;
    bool jump = true;
    bool swi = true;
    bool swi1 = false;
    bool swi2 = false;
    bool swi3 = false;
    int count2 = 200;
   

    // 以下キャラクターコントローラ用パラメタ
    // 前進速度
    public float forwardSpeed = 7.0f;
    // 後退速度
    public float backwardSpeed = 2.0f;
    // 旋回速度
    public float stepSpeed = 2f;
    // ジャンプ威力
    public float jumpPower = 3.0f;
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

    private GameObject cameraObject;	// メインカメラへの参照

    // アニメーター各ステートへの参照
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int restState = Animator.StringToHash("Base Layer.Rest");

    // 初期化
    void Start()
    {
        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();
        // CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        //メインカメラを取得する
        cameraObject = GameObject.FindWithTag("MainCamera");
        // CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
        orgColHight = col.height;
        orgVectColCenter = col.center;


    }


    // 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
    void Update()
    {
        float h = Input.GetAxis("Horizontal");				// 入力デバイスの水平軸をhで定義
        float v = Input.GetAxis("Vertical");	// 入力デバイスの垂直軸をvで定義


        anim.SetFloat("Speed", v);							// Animator側で設定している"Speed"パラメタにvを渡す
        anim.SetFloat("Direction", h); 						// Animator側で設定している"Direction"パラメタにhを渡す
        anim.speed = animSpeed;								// Animatorのモーション再生速度に animSpeedを設定する
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// 参照用のステート変数にBase Layer (0)の現在のステートを設定する
        rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする



        // 以下、キャラクターの移動処理
        if (swi == true)
        {
            velocity = new Vector3(0, 0, v);                            // 上下のキー入力からZ軸方向の移動量を取得
            velocity = transform.TransformDirection(velocity);
            		
        }
        
        

        // キャラクターのローカル空間での方向に変換
        
        //以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
        if (v > 0.1)
        {
            velocity *= forwardSpeed;		// 移動速度を掛ける
        }
        else if (v < -0.1)
        {
            velocity *= backwardSpeed;	// 移動速度を掛ける
        }

        if (Input.GetButtonDown("Jump"))
        {	// スペースキーを入力したら
            if (currentBaseState.nameHash == locoState)
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                anim.SetBool("Jump", true);		// Animatorにジャンプに切り替えるフラグを送る
            }

            //アニメーションのステートがLocomotionの最中のみジャンプでき
        }


        // 上下のキー入力でキャラクターを移動させる
        if (swi == true)
        {
            transform.localPosition += velocity * Time.deltaTime;
        }

        if (v < 0.5 && v > -0.5)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                right_step = true;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                left_step = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            right_step = false;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left_step = false;
        }

        /*if (right_step && !left_step)
        {
            transform.Translate(Vector3.right * stepSpeed / step_flame);
        }

        if (left_step && !right_step && swi==true)
        {
            transform.Translate(Vector3.right * -stepSpeed / step_flame);
           
        }

        if (left_step && right_step)
        {
            left_step = false;
            right_step = false;
        }*/
		transform.Rotate (0, h * 1.5f, 0);


        // 以下、Animatorの各ステート中での処理
        // Locomotion中
        // 現在のベースレイヤーがlocoStateの時
        if (currentBaseState.nameHash == locoState)
        {
            //カーブでコライダ調整をしている時は、念のためにリセットする
            if (useCurves)
            {
                resetCollider();
            }
        }
        // JUMP中の処理
        // 現在のベースレイヤーがjumpStateの時
        else if (currentBaseState.nameHash == jumpState)
        {
            //cameraObject.SendMessage("setCameraPositionJumpView");	// ジャンプ中のカメラに変更
            // ステートがトランジション中でない場合
            if (!anim.IsInTransition(0))
            {

                // 以下、カーブ調整をする場合の処理
                if (useCurves)
                {
                    // 以下JUMP00アニメーションについているカーブJumpHeightとGravityControl
                    // JumpHeight:JUMP00でのジャンプの高さ（0〜1）
                    // GravityControl:1⇒ジャンプ中（重力無効）、0⇒重力有効
                    float jumpHeight = anim.GetFloat("JumpHeight");
                    float gravityControl = anim.GetFloat("GravityControl");
                    if (gravityControl > 0)
                        rb.useGravity = false;	//ジャンプ中の重力の影響を切る

                    // レイキャストをキャラクターのセンターから落とす
                    Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
                    RaycastHit hitInfo = new RaycastHit();
                    // 高さが useCurvesHeight 以上ある時のみ、コライダーの高さと中心をJUMP00アニメーションについているカーブで調整する
                    if (Physics.Raycast(ray, out hitInfo))
                    {
                        if (hitInfo.distance > useCurvesHeight)
                        {
                            col.height = orgColHight - jumpHeight;			// 調整されたコライダーの高さ
                            float adjCenterY = orgVectColCenter.y + jumpHeight;
                            col.center = new Vector3(0, adjCenterY, 0);	// 調整されたコライダーのセンター
                        }
                        else
                        {
                            // 閾値よりも低い時には初期値に戻す（念のため）					
                            resetCollider();
                        }
                    }
                }
                // Jump bool値をリセットする（ループしないようにする）				
                anim.SetBool("Jump", false);
                jump = false;
            }
        }
        // IDLE中の処理
        // 現在のベースレイヤーがidleStateの時
        else if (currentBaseState.nameHash == idleState)
        {
            //カーブでコライダ調整をしている時は、念のためにリセットする
            if (useCurves)
            {
                resetCollider();
            }
        }
        // REST中の処理
        // 現在のベースレイヤーがrestStateの時
        else if (currentBaseState.nameHash == restState)
        {
            //cameraObject.SendMessage("setCameraPositionFrontView");		// カメラを正面に切り替える
            // ステートが遷移中でない場合、Rest bool値をリセットする（ループしないようにする）
            if (!anim.IsInTransition(0))
            {
                anim.SetBool("Rest", false);
            }
        }


        if (Input.GetKeyDown("j") && Input.GetKeyDown("k") && Input.GetKeyDown("l"))
        {
            swi1 = true;
        }
        else
        {
            if (Input.GetKeyDown("j") && Input.GetKeyDown("l"))
            {
                swi1 = true;
            }

            if (Input.GetKeyDown("j") && Input.GetKeyDown("k"))
            {
                swi2 = true;
            }

            if (Input.GetKeyDown("k") && Input.GetKeyDown("l"))
            {
                swi3 = true;
            }

        }


        if (Input.GetKey("c"))
        {
            swi = false;
            count2 = 198;
        }

        if ((swi2 == false && Input.GetKeyDown("j")) || swi1 == true)
        {
            swi = false;
            count2 = 120;
        }

        if ((swi1==false && Input.GetKeyDown("l")) || swi3 == true)
        {
            swi = false;
            count2 = 158;
        }

        if ((swi1==false && Input.GetKeyDown("k")) || swi2 == true)
        {
            swi = false;
            count2 = 140;
        }

        

        if (swi == false)
        {
            count2++;

        }

        if (count2 >= 200)
        {
            swi = true;
        }

        if(swi1 == true || swi2 == true || swi3 == true)
        {
            swi1 = false;
            swi2 = false;
            swi3 = false;

        }
    }


    // キャラクターのコライダーサイズのリセット関数
    void resetCollider()
    {
        // コンポーネントのHeight、Centerの初期値を戻す
        col.height = orgColHight;
        col.center = orgVectColCenter;
    }

    
}

