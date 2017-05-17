using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using DefineNamespace;
using BingoFacadeNamespace;

namespace InitNamespace
{
    public class InitView : MonoBehaviour
    {
        public Slider mLoadingBar;
        public Text mLoadingBarValue;
        public GameObject mEventSystem;

        public Image bBall;
        public Image iBall;
        public Image nBall;
        public Image gBall;
        public Image oBall;

        private int progress;

        void Awake()
        {
            progress = 0;
        }

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartRunLoadingBar()
        {
            if (this.isActiveAndEnabled)
            {
                StartCoroutine(Coroutine_DoProgress());
            }
        }

        IEnumerator Coroutine_DoProgress()
        {
            while (progress < 100)
            {
                progress = progress + 5;
                mLoadingBar.value = progress;
                mLoadingBarValue.text = progress.ToString() + "%";
                yield return new WaitForSeconds(0.05f);
            }


            BingoFacade.Instance.SendNotification(Define.Command.Init_CheckSettingDataCommand);
        }


        public void LoadLoadingSceneAddtive()
        {
            mEventSystem.SetActive(false);
            SceneManager.LoadScene(Define.Scene.LoginSceneLoader, LoadSceneMode.Additive);  
        }


        //public void LoadLobbySceneAddtive()
        //{
        //    //Let bingo ball light 1 sec than goto lobby scene
        //    mEventSystem.SetActive(false);

        //    StartCoroutine(Coroutine_LoadLobbySceneAddtive());
        //}

        //IEnumerator Coroutine_LoadLobbySceneAddtive()
        //{
        //    LightAllBingoBall();

        //    yield return new WaitForSeconds(1f);

        //    SceneManager.LoadScene(Define.Scene.LobbySceneLoader, LoadSceneMode.Additive);
        //}

        //private void LightAllBingoBall()
        //{
        //    bBall.color = new Color(0 / 255f,   65/255f,    255 / 255f);
        //    iBall.color = new Color(255 / 255f, 0 / 255f,   0 / 255f);
        //    nBall.color = new Color(99 / 255f,  99 / 255f,  99 / 255f);
        //    gBall.color = new Color(0 / 255f,   255 / 255f, 33 / 255f);
        //    oBall.color = new Color(255 / 255f, 255 / 255f, 0 / 255f);
        //}
    }
}
