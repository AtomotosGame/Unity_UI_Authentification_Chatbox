using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Authentication : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI Registeralerttext;
    [SerializeField] private TextMeshProUGUI Loginalerttext;
    [SerializeField] private Button loginbutton;
    [SerializeField] private Button Createbutton;
    [SerializeField] private InputField RegisterusernameImput;
    [SerializeField] private InputField RegisterPasswordImput;
    [SerializeField] private InputField LoginusernameImput;
    [SerializeField] private InputField LoginPasswordImput;
    [SerializeField] private string LoginEndpoint = "http://127.0.0.1:13756/account/login";
    [SerializeField] private string CreateEndpoint = "http://127.0.0.1:13756/account/create";

    public void OnLoginClick()
    {
        Loginalerttext.text = "Signing In";
    //    ActivateButtons(false);
        StartCoroutine(TryLogin());
    }
    
    public void OnCreateClick()
    {
        Registeralerttext.text = "Creating Account..";
        // ActivateButtons(false);
        StartCoroutine(TryCreate());
    }

    public void OnUpdateClick()
    {
        StartCoroutine(TryUpdate());
    }

    private IEnumerator TryLogin()
    {
        string Username = LoginusernameImput.text;
        string Password = LoginPasswordImput.text;

        if (Username.Length < 3 || Username.Length > 24)
        {
            Loginalerttext.text = "Invalid Username";
            loginbutton.interactable = true;
            yield break;
        }
        if (Password.Length < 1 || Password.Length > 24)
        {
            Loginalerttext.text = "Invalid Password";
            loginbutton.interactable = true;
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("REmail", Username);
        form.AddField("RPassword", Password);
        UnityWebRequest request = UnityWebRequest.Post(LoginEndpoint, form);
        var handler = request.SendWebRequest();

        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }
            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.result);
            Debug.Log(UnityWebRequest.Result.Success);
            Debug.Log(request.downloadHandler.text);
            if (request.downloadHandler.text != "Invalid Credentials")
            {
                Loginalerttext.text = "Welcome";
                Loginalerttext.text = "Welcome " + request.downloadHandler.text;
                yield return  new WaitForSeconds(2);

            }
            else
            {
                Loginalerttext.text = "Invalid Credentials";
            }
            
        }
        else
        {
            Loginalerttext.text = "Error";
        }
        
        
        Debug.Log($"{Username}:{Password}");
        
        yield return null;
    }

    private IEnumerator TryCreate()
    {
        string Username = RegisterusernameImput.text;
        string Password = RegisterPasswordImput.text;

        if (Username.Length < 3 || Username.Length > 24)
        {
            Registeralerttext.text = "Invalid Username";
            yield break;
        }
        if (Password.Length < 1 || Password.Length > 24)
        {
            Registeralerttext.text = "Invalid Password";
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("REmail", Username);
        form.AddField("RPassword", Password);
        UnityWebRequest request = UnityWebRequest.Post(CreateEndpoint, form);
        var handler = request.SendWebRequest();

        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }
            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.downloadHandler.text != "Invalid Credentials" && request.downloadHandler.text != "Username Is Already Taken")
            {
                Registeralerttext.text = "Account Created Successfully....";
            }
            else
            {
                Registeralerttext.text = "Username Is Already Taken";
            }
            
        }
        else
        {
            Registeralerttext.text = "Error";
        }
        
        yield return null;
    }

    private IEnumerator TryUpdate()
    {
        string ID = "637bd7738fb8637d72e0dbd6";
        string playerName = "PlayerName2";
        var level = 3;

        string UpdateEndpoint = "http://127.0.0.1:13756/account/update";
        string GetInfopoint = "http://127.0.0.1:13756/account/info?id=637bd7738fb8637d72e0dbd6";


        UnityWebRequest request1 = UnityWebRequest.Get(GetInfopoint);
        var handler1 = request1.SendWebRequest();
        float startTime1 = 0.0f;
        while (!handler1.isDone)
        {
            startTime1 += Time.deltaTime;

            if (startTime1 > 10.0f)
            {
                break;
            }
            yield return null;
        }

        Debug.Log(request1.downloadHandler.text);

        WWWForm form = new WWWForm();
        form.AddField("id", ID); // you must send ID
        form.AddField("playerName", playerName);
        form.AddField("level", level);
        UnityWebRequest request = UnityWebRequest.Post(UpdateEndpoint, form);

        var handler = request.SendWebRequest();

        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }
            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.downloadHandler.text != "Invalid Credentials")
            {
                Registeralerttext.text = "Update Successful";
            }
            else
            {
                Registeralerttext.text = "Username Is Already Taken";
            }
            
        }
        else
        {
            Registeralerttext.text = "Error";
        }
        
        yield return null;
    }
    
    public void initAlert()
    {
        Registeralerttext.text = "";
        Loginalerttext.text = "";
    }
}
