using System.Collections.Generic;
using UnityEngine;
using Lonfee.EventSystem;
using UnityEngine.UI;

namespace Lonfee.TriggerSystem.Samples
{
    public class KeyDownTrigger : MonoBehaviour
    {
        #region UI

        public Button playBtn;
        public Text playBtnText;

        public Text statusText;
        #endregion

        private bool isPlay;
        private ABaseTrigger tg;
        private ETriggerState state;

        void Start()
        {
            RefreshBtnStatus();
            playBtn.onClick.AddListener(OnClk_Play);

            CACData data = new CACData();
            data.startCondColl = new List<CondCtorData>();
            data.startCondColl.Add(new CondCtorData((int)EConditionType.KeyDown, KeyCode.S));

            data.actColl = new List<ActionCtorData>();
            data.actColl.Add(new ActionCtorData((int)EActionType.LogError));

            data.endCondColl = new List<CondCtorData>();
            data.endCondColl.Add(new CondCtorData((int)EConditionType.KeyDown, KeyCode.E));

            tg = new Trigger_CAC(new TsObjGenerator(), data, OnTriggerStatusChange);
        }

        private void OnTriggerStatusChange(ETriggerState obj)
        {
            state = obj;
            Debug.Log("Trigger state switch to : " + state);
        }

        private void OnClk_Play()
        {
            if (!isPlay)
            {
                tg.Start();
            }
            else
            {
                tg.Stop();
            }

            isPlay = !isPlay;
            RefreshBtnStatus();
        }

        public void RefreshBtnStatus()
        {
            playBtnText.text = isPlay ? "Stop" : "Start";
        }

        void Update()
        {
            if (tg != null)
            {
                tg.Update(Time.deltaTime);
                RefreshTriggerStatus();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                EventMgr.Dispatch(new EvtCls_KeyDown() { code = KeyCode.S });
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                EventMgr.Dispatch(new EvtCls_KeyDown() { code = KeyCode.E });
            }
        }

        private void RefreshTriggerStatus()
        {
            string text = string.Empty;

            // is play?
            text += "Is Start : " + (isPlay ? "Yes" : "No") + "\n";

            // is finished?
            text += "Is Finished : " + (tg.IsFinished() ? "Yes" : "No") + "\n";

            // trigger status
            text += "Trigger status : " + state.ToString();

            statusText.text = text;
        }
    }
}