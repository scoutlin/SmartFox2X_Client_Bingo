using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using DefineNamespace;

namespace InitNameSpace
{
    public class InitView : MonoBehaviour
    {
        public Slider mLoadingBar;
        public Text mLoadingBarValue;
        public GameObject mEventSystem;

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
            StartCoroutine(Coroutine_DoProgress());
        }

        IEnumerator Coroutine_DoProgress()
        {
            while (progress < 100)
            {
                progress++;
                mLoadingBar.value = progress;
                mLoadingBarValue.text = progress.ToString() + "%";
                yield return new WaitForSeconds(0.05f);
            }

            LoadLoadingSceneAddtive();
        }


        public void LoadLoadingSceneAddtive()
        {
            mEventSystem.SetActive(false);
            SceneManager.LoadScene(Define.Scene.LoginScene, LoadSceneMode.Additive);  
        }
    }
}
