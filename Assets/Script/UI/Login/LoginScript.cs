using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using TMPro;

public class GoogleSignInExample : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;
    public TMP_InputField email;
    public TMP_InputField password;
    private void Start()
    {
        
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;

            if (auth != null)
            {
                Debug.Log("Firebase Auth is ready.");
            }
            else
            {
                Debug.LogError("Firebase Auth is not initialized.");
            }
        });
    }
    public void CreateAccountWithEmailPassword()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("생성 취소됨!");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("생성에 무언가 문제가 있음!");
                return;
            }

            // Get the result from the task
            AuthResult authResult = task.Result;

            // Access the user from the authResult if needed
            FirebaseUser newUser = authResult.User;
            Debug.Log("생성 성공! " + newUser.DisplayName);
        });
    }

    public void SignInWithGoogle()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("로그인 취소됨!");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("로그인에 문제 있음!" + task.Exception);
                return;
            }

            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });
    }
    public void SignOut()
    {
        auth.SignOut();
    }
    
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null
                && auth.CurrentUser.IsValid();
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                //displayName = user.DisplayName ?? "";
                //emailAddress = user.Email ?? "";
                //photoUrl = user.PhotoUrl ?? "";
            }
        }
    }
    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using Firebase.Extensions;
using System;
using TMPro;

public class LoginScript : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    public TMP_InputField email;
    public TMP_InputField password;

    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += OnChanged;
    }

    private void OnChanged(object sender, EventArgs e)
    {
        if (auth.CurrentUser != user)
        {
            bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);
            if (!signed && user != null)
            {
                Debug.Log("로그아웃!");
            }
            user = auth.CurrentUser;
            if (signed)
            {
                Debug.Log("로그인");
            }
        }
    }

    public void Create()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                // 사용자에게 적절한 메시지를 표시할 수 있습니다.
                ShowErrorMessage("가입을 취소했습니다.");
                return;
            }
            if (task.IsFaulted)
            {
                // FirebaseException을 가져옵니다.
                FirebaseException exception = task.Exception.InnerExceptions[0] as FirebaseException;
                if (exception != null)
                {
                    // Firebase에서 제공하는 오류 코드에 따라 사용자 지정 메시지를 표시할 수 있습니다.
                    if (string.Equals(exception.ErrorCode, "ERROR_INVALID_EMAIL"))
                    {
                        ShowErrorMessage("이메일 주소 형식이 올바르지 않습니다.");
                    }
                    else if (string.Equals(exception.ErrorCode,"ERROR_WEAK_PASSWORD"))
                    {
                        ShowErrorMessage("비밀번호가 너무 약합니다. 더 강력한 비밀번호를 선택하세요.");
                    }
                    else
                    {
                        ShowErrorMessage("가입 중에 오류가 발생했습니다.");
                    }
                }
                return;
            }

            Debug.Log("가입완");
            // Get the result from the task
            AuthResult authResult = task.Result;

            // Access the user from the authResult if needed
            FirebaseUser newUser = authResult.User;
        });
    }

    private void ShowErrorMessage(string message)
    {
        // 사용자에게 오류 메시지를 표시하는 로직을 여기에 추가하세요.
        // 예를 들어, UI Text 요소를 업데이트하거나 팝업 메시지를 표시할 수 있습니다.
        Debug.LogError(message);
    }
    public void Login()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Debug.Log("로그인 완료");
            // Get the result from the task
            AuthResult authResult = task.Result;

            // Access the user from the authResult if needed
            FirebaseUser newUser = authResult.User;
        });
    }

    public void Logout()
    {
        auth.SignOut();
    }
}*/