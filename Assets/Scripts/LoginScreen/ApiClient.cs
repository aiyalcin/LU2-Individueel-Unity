using System.Text;
using System.Threading.Tasks;
using Assets.Scripts;
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
        Debug.Log(json);
        await PerformApiCall("https://localhost:7023/account/register", "POST", json);

    }

    public async void Login(string Email, string Password)
    {
        var registerDto = new PostLoginRequestDTO()
        {
            email = Email,
            password = Password
        };

        string json = JsonUtility.ToJson(registerDto);

        var response = await PerformApiCall("https://localhost:7023/account/login", "POST", json);
        JsonUtility.FromJson<PostLoginResponseDTO> (response);
        Debug.Log(response);
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

            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                return request.downloadHandler.text;
            }
            else
            {
                Debug.LogError("Fout bij API-aanroep: " + request.error);
                return null;
            }
        }
    }
}
