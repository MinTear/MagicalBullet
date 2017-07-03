using Assets.Extention;
using Assets.Script.EnemyController.EnemyMovement;
using Assets.Script.EnemyController.EnemySkills;
using Assets.Script.EnemyController.LockonDetecter;
using BulletXNA.BulletCollision;
using UnityEngine;
using System.Collections;

public class NewEnemyBehaviour : MonoBehaviour
{
    public LockonDetectorBase LockOnDetector;

    public EnemySkillBase[] Skills;

    public SkillSelectorBase SkillSelector;

    public EnemyMovementBase EnemyMovement;
    
    public float skillEndTime;

    public float skillBeginTime;

    public bool SkillActive = false;

    public EnemySkillBase currentSkill;

    private GameObject player;
    // Use this for initialization
    void Start()
    {
        if (this.Skills != null)
        {
            foreach (var enemySkillBase in Skills)
            {
                enemySkillBase.ParentEnemyBehaviour = this;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = player ?? this.GetPlayer();
        if(player==null)return;
        if (EnemyMovement != null)
        {
            EnemyMovement.MoveEnemy(LockOnDetector.IsNoticed,player);
        }
        if (SkillActive)
        {
            if (Time.time > skillEndTime) SkillActive = false;
            if(currentSkill!=null)currentSkill.OnSkillUpdate(Time.time-skillBeginTime);
        }
        else
        {
            if (LockOnDetector.IsNoticed)
            {
                var skill = SkillSelector.SelectSkill(Skills);
                if(skill==null)return;
                SkillActive = true;
                skillEndTime = Time.time + skill.SkillTime;
                skillBeginTime = Time.time;
                this.currentSkill = skill;
                skill.OnSkillBegin();
            }
        }
    }
}
