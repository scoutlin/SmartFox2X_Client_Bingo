using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using DefineNamespace;

namespace LoginNamespace
{
    public class LoginView : MonoBehaviour
    {
        public GameObject mCamera;
        public GameObject mEventSystem;

        private LoginMediator mLoginMediator;

    

        void Awake()
        {

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetMediatorRef(LoginMediator mLoginMediator)
        {
            this.mLoginMediator = mLoginMediator;
        }

        #region UserInput
        public void OnLoginClick()
        {
            mLoginMediator.OnLoginClick();
            Debug.Log("OnLoginClick");


            //For Test
            mEventSystem.SetActive(false);
            mCamera.SetActive(false);

            SceneManager.LoadScene(Define.Scene.LobbyScene, LoadSceneMode.Additive);
        }

        public void OnFBLoginClick()
        {
            mLoginMediator.OnFBLoginClick();
            Debug.Log("OnFBLoginClick");
        }

        public void OnDonateClick()
        {
            mLoginMediator.OnDonateClick();
            Debug.Log("OnDonateClick");
        }

        #endregion
    }
}