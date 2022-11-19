using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Transform Authentication;
    public Transform Register1;
    public Transform Register2;
    public Transform Verify;
    public Transform Done;
    public Transform Logged;
    public Transform Login;
    public Transform ResetPassword;
    public Transform VerifyEmail;
    public Transform SetNewPassword;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        Authentication.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Go_Authentication() {
        Authentication.SetAsLastSibling();
    }

    public void Go_Register1() {
        Register1.SetAsLastSibling();
    }

    public void Go_Register2() {
        Register2.SetAsLastSibling();
    }

    public void Go_Verify() {
        Verify.SetAsLastSibling();
    }

    public void Go_Done() {
        Done.SetAsLastSibling();
    }
    
    public void Go_Logged() {
        Logged.SetAsLastSibling();
    }

    public void Go_Login() {
        Login.SetAsLastSibling();
    }

    public void Go_ResetPassword() {
        ResetPassword.SetAsLastSibling();
    }

    public void Go_VerifyEmail() {
        VerifyEmail.SetAsLastSibling();
    }

    public void Go_SetNewPassword() {
        SetNewPassword.SetAsLastSibling();
    }

}
