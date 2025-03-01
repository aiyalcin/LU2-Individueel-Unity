using System.Text;
using System.Threading.Tasks;
using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{

    public async void Register(string Email, string Password)
    {
        var registerDto = new PostLoginRequestDTO()
        {
            email = Email,
            password = Password
        };

        string json = JsonUtility.ToJson(registerDto);
        Debug.Log("Register JSON: " + json);
        await PerformApiCall("https://localhost:7023/account/register", "POST", json);
    }

    public async void Login(string Email, string Password)
    {
        var loginDto = new PostLoginRequestDTO()
        {
            email = Email,
            password = Password
        };

        string json = JsonUtility.ToJson(loginDto);
        Debug.Log("Login JSON: " + json);

        var response = await PerformApiCall("https://localhost:7023/account/login", "POST", json);
        if (response != null)
        {
            JsonUtility.FromJson<PostLoginResponseDTO>(response);
            Debug.Log("Login Response: " + response);
        }
    }

    private async Task<string> PerformApiCall(string url, string method, string jsonData = null, string token = null)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, method))
        {
            if (!string.IsNullOrEmpty(jsonData))
            {
                byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(token))
            {
                request.SetRequestHeader("Authorization", "Bearer " + token);
            }

            Debug.Log("Sending request to: " + url);
            await request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("API call successful: " + request.downloadHandler.text);
                return request.downloadHandler.text;
            }
            else
            {
                Debug.LogError("Error in API call: " + request.error);
                return null;
            }
        }
    }
}
