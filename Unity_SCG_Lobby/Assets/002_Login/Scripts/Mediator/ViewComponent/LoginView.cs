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
        public GameObject mQuickLoginButton;
        public GameObject mFBLoginButton;
        public GameObject mFBLogoutButton;
        public GameObject mDonateButton;
        public Text mDonateButtonText;
        public GameObject mLoginingText;

        private Login_LoginMediator mLoginMediator;

    

        void Awake()
        {
            
        }

        // Use this for initialization
        void Start()
        {
            mLoginMediator.OnInitialSmartFox2XClient();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SetMediatorRef(Login_LoginMediator mLoginMediator)
        {
            this.mLoginMediator = mLoginMediator;
        }

        #region UserInput
        public void OnQuickLoginClick()
        {
            mLoginMediator.OnQuickLoginClick();
            Debug.Log("OnLoginClick");
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
        #endregion

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


        public void SetQuickLoginButtonActice(bool isActive)
        {
            mQuickLoginButton.SetActive(isActive);
        }

        public void SetFBLoginButtonActive(bool isActive)
        {
            mFBLoginButton.SetActive(isActive);
        }

        public void SetFBLogoutButtonActive(bool isActive)
        {
            mFBLogoutButton.SetActive(isActive);
        }

        public void SetLoginingTextActive(bool isActive)
        {
            mLoginingText.SetActive(isActive);
        }

        public void CountDownDonate(int startNumber)
        {
            StartCoroutine(CorutineCountDownDonate(startNumber));
        }

        public void Login_FBLogin(Sprite sprite)
        {
            mUserProfilePicture.sprite = sprite;

            mUserProfilePicture.enabled = true;

            SetQuickLoginButtonActice(false);
            SetFBLoginButtonActive(false);
            //SetFBLogoutButtonActive(false);

            CountDownDonate(5);
        }




    }
}