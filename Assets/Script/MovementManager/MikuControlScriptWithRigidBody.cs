using UnityEngine;
using System.Collections;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class MikuControlScriptWithRigidBody : MonoBehaviour
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
    int count3=270;
    int count4=200;
    int count5=40;


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
    static int walkBackState = Animator.StringToHash("Base Layer.WalkBack");
    static int guardState = Animator.StringToHash("Base Layer.Guard");
    static int damagedState = Animator.StringToHash("Base Layer.Damaged");
    static int fallSnowState = Animator.StringToHash("Base Layer.FallSnow");
    static int chillSwordState = Animator.StringToHash("Base Layer.ChillSword");
    static int raserBeamState = Animator.StringToHash("Base Layer.RaserBeam");


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

        }		// 上下のキー入力からZ軸方向の移動量を取得
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
		transform.Rotate (0, h * 1.5f, 0);	
       /* if (right_step && !left_step)
        {
            transform.Rotate(new Vector3(0,step_flame/3,0));
        }

        if (left_step && !right_step && swi == true)
        {
            transform.Rotate(new Vector3(0,-step_flame/3,0));
        }

        if (left_step && right_step)
        {
            left_step = false;
            right_step = false;
        }*/


        // 以下、Animatorの各ステート中での処理

        // スラッシュキーを離すとGuard状態を解除。関数の呼び出しのタイミングの関係でここに書く。
        if (Input.GetKeyUp(KeyCode.Slash))
        {
            anim.SetBool("Guard", false);
        }

        // Locomotion中の処理
        // 現在のベースレイヤーがlocoStateの時
        if (currentBaseState.nameHash == locoState)
        {
            //カーブでコライダ調整をしている時は、念のためにリセットする
            if (useCurves)
            {
                resetCollider();
            }

            // スペースキーを入力したらJump状態になる
            if (Input.GetButtonDown("Jump"))
            {	
                    rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                    anim.SetBool("Jump", true);		// Animatorにジャンプに切り替えるフラグを送る
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

            // スペースキーを入力したらJump状態になる
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                anim.SetBool("Jump", true);
            }
            // スラッシュキーを押し続けるとGuard状態になる
            else if (Input.GetKey(KeyCode.Slash))
            {
                anim.SetBool("Guard", true);
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
        // WALKBACK中の処理
        // 現在のベースレイヤーがwalkBackStateの時
        else if (currentBaseState.nameHash == walkBackState)
        {

            // スペースキーを入力したらJump状態になる
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
                anim.SetBool("Jump", true);
            }
        }
        // GUARD中の処理
        // 現在のベースレイヤーがguardStateの時
        else if (currentBaseState.nameHash == guardState)
        {

        }
        // DAMAGED中の処理
        // 現在のベースレイヤーがdamagedStateの時
        else if (currentBaseState.nameHash == damagedState)
        {

        }
        // FALLSNOW中の処理
        // 現在のベースレイヤーがfallSnowStateの時
        else if (currentBaseState.nameHash == fallSnowState)
        {

        }
        // CHILLSWORD中の処理
        // 現在のベースレイヤーがchillSwordStateの時
        else if (currentBaseState.nameHash == chillSwordState)
        {

        }
        // RASERBEAM中の処理
        // 現在のベースレイヤーがraserBeamStateの時
        else if (currentBaseState.nameHash == raserBeamState)
        {

        }

        if (Input.GetKeyDown("j") && Input.GetKeyDown("k") && Input.GetKeyDown("l"))
        {
            swi3 = true;
        }
        else
        {
            if (Input.GetKeyDown("j") && Input.GetKeyDown("l"))
            {
                swi3 = true;
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

        if ((swi3 == false && Input.GetKeyDown("k")) || swi1 == true)
        {
            swi = false;
            count2 = 120;
        }

        if ((swi1 == false && Input.GetKeyDown("l")) || swi3 == true)
        {
            swi = false;
            count2 = 190;
        }

        if ((swi3 == false && Input.GetKeyDown("j")) || swi2 == true)
        {
            swi = false;
            count2 = 130;
        }



        if (swi == false)
        {
            count2++;

        }

        if (count2 >= 200)
        {
            swi = true;
        }


        if (Input.GetKey("c"))
        {
            anim.SetBool("Guard", true);

            if (count3 >= 268)
            {
                count3 = 252;
            }

            if (count4 >= 38)
            {
                count4 = 22;
            }

            if (count5 >= 198)
            {
                count5 = 182;
            }
        }
        else
        {
            anim.SetBool("Guard", false);
        }

        

        if (count3 >= 270)
        {
            if ((swi3 == false && Input.GetKeyDown("k")) || swi1 == true)
            {
                count4 = -70;
                count5 = -230;
                anim.SetBool("ChillSword", true);
                count3 = 0;
            }
        }

        if (count3 > 229)
        {
            anim.SetBool("ChillSword", false);
        }

        if (count4 >= 40)
        {
            if (Input.GetKeyDown("l") || swi3 == true)
            {
                count3 = 230;
                count5 = 160;
                anim.SetBool("FallSnow", true);
                count4 = 0;

            }
        }

        if (count4 > 34)
        {
            anim.SetBool("FallSnow", false);
        }

        if (count5 >= 200)
        {
            if (Input.GetKeyDown("j") || swi2 == true)
            {
                count3 = 70;
                count4 = -160;
                anim.SetBool("RaserBeam", true);
                count5 = 0;

            }
        }

        if (count5 > 194)
        {
            anim.SetBool("RaserBeam", false);
        }

        if (swi1 == true || swi2 == true || swi3 == true)
        {
            swi1 = false;
            swi2 = false;
            swi3 = false;
        }

        count3++;
        count4++;
        count5++;

    }


    // キャラクターのコライダーサイズのリセット関数
    void resetCollider()
    {
        // コンポーネントのHeight、Centerの初期値を戻す
        col.height = orgColHight;
        col.center = orgVectColCenter;
    }
}
