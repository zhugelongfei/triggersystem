using System.Collections.Generic;
using UnityEngine;
using Lonfee.EventSystem;
using UnityEngine.UI;

namespace Lonfee.TriggerSystem.Samples
{
    public class MiniGame : MonoBehaviour
    {
        #region UI

        public Transform player;
        public Transform enemy;
        public Slider enemySlider;

        public Transform trap;

        #endregion

        private ABaseTrigger tg;

        private bool isCurInTrap = false;

        public float playerMoveSpeed = 300;

        void Start()
        {
            CAData data = new CAData();
            data.condColl = new List<CondCtorData>();
            data.condColl.Add(new CondCtorData((int)EConditionType.PlayerEnterTrap, 1));

            data.actColl = new List<ActionCtorData>();
            data.actColl.Add(new ActionCtorData((int)EActionType.HitEnemy));

            tg = new Trigger_CA(new TsObjGenerator(), data);
            tg.Start();
        }

        private void OnEnable()
        {
            EventMgr.RegisterEvent<EvtCls_HitEnemy>(OnEvt_HitEnemy);
        }

        private void OnEvt_HitEnemy(EvtCls_HitEnemy obj)
        {
            enemySlider.value -= 0.2f;
        }

        private void OnDisable()
        {
            EventMgr.RemoveEvent<EvtCls_HitEnemy>(OnEvt_HitEnemy);
        }

        void Update()
        {
            PlayerControler();

            bool isIn = CheckPlayerIsInTrap();
            if (isCurInTrap != isIn)
            {
                // status changed
                isCurInTrap = isIn;

                if (isIn)
                {
                    EventMgr.Dispatch(new EvtCls_PlayerEnterTrap() { playerId = 1 });
                }
            }

            if (tg != null)
            {
                tg.Update(Time.deltaTime);

                if (tg.IsFinished())
                {
                    // restart for show again
                    tg.Stop();
                    tg.Start();
                }
            }
        }

        private void PlayerControler()
        {
            player.localPosition += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * playerMoveSpeed * Time.deltaTime;
        }

        private bool CheckPlayerIsInTrap()
        {
            Vector3 dis = player.localPosition - trap.localPosition;
            dis.z = 0;
            if (Vector3.Dot(dis, dis) <= 300 * 300) 
            {
                // in trap;
                return true;
            }
            return false;
        }

    }
}