using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Authentication : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI alerttext;
    [SerializeField] private Button loginbutton;
    [SerializeField] private Button Createbutton;
    [SerializeField] private TMP_InputField usernameImput;
    [SerializeField] private TMP_InputField PasswordImput;
    [SerializeField] private string LoginEndpoint = "http://127.0.0.1:13756/account/login";
    [SerializeField] private string CreateEndpoint = "http://127.0.0.1:13756/account/Create";

    public void OnLoginClick()
    {
        alerttext.text = "Signing In";
       ActivateButtons(false);
        StartCoroutine(TryLogin());
    }
    
    public void OnCreateClick()
    {
        alerttext.text = "Creating Account..";
        ActivateButtons(false);
        StartCoroutine(TryCreate());
    }

    private IEnumerator TryLogin()
    {
        string Username = usernameImput.text;
        string Password = PasswordImput.text;

        if (Username.Length < 3 || Username.Length > 24)
        {
            alerttext.text = "Invalid Username";
            loginbutton.interactable = true;
            yield break;
        }
        if (Password.Length < 1 || Password.Length > 24)
        {
            alerttext.text = "Invalid Password";
            loginbutton.interactable = true;
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("RUusername", Username);
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
            if (request.downloadHandler.text != "Invalid Credentials")
            {
                alerttext.text = "Welcome";
                ActivateButtons(false);
                GameAccounts returnedAccount = JsonUtility.FromJson<GameAccounts>(request.downloadHandler.text);
                alerttext.text = "Welcome " + returnedAccount.username;
                yield return  new WaitForSeconds(2);

                SceneManager.LoadScene("4.AISystem");
            }
            else
            {
                alerttext.text = "Invalid Credentials";
                ActivateButtons(true);
            }
            
        }
        else
        {
            alerttext.text = "Error";
           ActivateButtons(true);
        }
        
        
        Debug.Log($"{Username}:{Password}");
        
        yield return null;
    }

    private IEnumerator TryCreate()
    {
        string Username = usernameImput.text;
        string Password = PasswordImput.text;

        if (Username.Length < 3 || Username.Length > 24)
        {
            alerttext.text = "Invalid Username";
            ActivateButtons(true);
            yield break;
        }
        if (Password.Length < 1 || Password.Length > 24)
        {
            alerttext.text = "Invalid Password";
            ActivateButtons(true);
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("RUusername", Username);
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
                GameAccounts returnedAccount = JsonUtility.FromJson<GameAccounts>(request.downloadHandler.text);
                alerttext.text = "Account Created Successfully....";
            }
            else
            {
                alerttext.text = "Username Is Already Taken";
            }
            
        }
        else
        {
            alerttext.text = "Error";
        }
        
        ActivateButtons(true);
        yield return null;
    }

    
    void ActivateButtons(bool Toggle)
    {
        loginbutton.interactable = Toggle;
        Createbutton.interactable = Toggle;
    }
}
