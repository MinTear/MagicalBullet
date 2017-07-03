using Assets.Extention;
using Assets.Script.EnemyController.LockonDetecter;
using UnityEngine;
using System.Collections;

public class DistanceDetecter :LockonDetectorBase
{

    public float NoticeDistance;
    // Use this for initialization
    void Start()
    {
        playerObject = this.GetPlayer();
    }

    public GameObject playerObject { get; set; }

    // Update is called once per frame
    void Update()
    {
        playerObject = playerObject ?? this.GetPlayer();
        if (playerObject == null) return;
        if ((this.transform.position - this.playerObject.transform.position).magnitude <= NoticeDistance)
        {
            this._isNoticed = true;
        }
    }

    public bool _isNoticed = false;

    public override bool IsNoticed
    {
        get { return this._isNoticed; }
    }
}
