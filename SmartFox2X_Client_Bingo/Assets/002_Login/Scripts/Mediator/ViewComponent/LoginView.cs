using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using DefineNamespace;
using UnityEngine.UI;

namespace LoginNamespace
{
    public class LoginView : MonoBehaviour
    {
        public GameObject mCamera;
        public GameObject mEventSystem;
        public Image mUserProfilePicture;
        public GameObject mLoginButton;
        public GameObject mFBLoginButton;
        public GameObject mFBLogoutButton;
        public GameObject mDonateButton;
        public Text mDonateButtonText;

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

        public void OnFBLogoutClick()
        {
            mLoginMediator.OnFBLogoutClick();
        }

        public void OnDonateClick()
        {
            mLoginMediator.OnDonateClick();
            Debug.Log("OnDonateClick");
        }


        IEnumerator CorutineCountDownDonate(int startNumber)
        {
            int innerStartNumber = startNumber;

            while (innerStartNumber >= 0)
            {
                mDonateButtonText.text = innerStartNumber.ToString();
                innerStartNumber--;
                yield return new WaitForSeconds(1);
            }

            //mCamera.SetActive(false);
            //SceneManager.LoadScene(Define.Scene.LobbyScene, LoadSceneMode.Additive);

        }


        public void SetLoginButtonActice(bool isActive)
        {
            mLoginButton.SetActive(isActive);
        }

        public void SetFBLoginButtonActive(bool isActive)
        {
            mFBLoginButton.SetActive(isActive);
        }

        public void SetFBLogoutButtonActive(bool isActive)
        {
            mFBLogoutButton.SetActive(isActive);
        }

        public void CountDownDonate(int startNumber)
        {
            StartCoroutine(CorutineCountDownDonate(startNumber));
        }

        public void Login_FBLogin(Sprite sprite)
        {
            mUserProfilePicture.sprite = sprite;

            mUserProfilePicture.enabled = true;

            SetLoginButtonActice(false);
            SetFBLoginButtonActive(false);
            //SetFBLogoutButtonActive(false);

            CountDownDonate(5);
        }

        #endregion
    }
}