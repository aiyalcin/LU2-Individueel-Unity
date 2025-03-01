using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LoginSceneManager : MonoBehaviour
{
    public TMP_InputField EmailInputField;
    public TMP_InputField PasswordInputField;
    public TMP_Text UsernameErrorBanner;
    public TMP_Text PasswordErrorBanner;
    public TMP_Text NoAccountErrorBannerText;
    private CredentialsValidator _credentialsValidator;
    private ApiClient _apiClient;

    private void Start()
    {
        _credentialsValidator = new CredentialsValidator();
        _apiClient = new ApiClient();
    }

    private string _enteredEmail;
    private string _enteredPassword;

    public void OnLoginButtonPressed()
    {
        _enteredEmail = EmailInputField.text;
        _enteredPassword = EmailInputField.text;
        var (isValidEmail, returnString) = _credentialsValidator.ValidateEmail(_enteredEmail);
        var (isValidPassword, returnString2) = _credentialsValidator.ValidatePassword(_enteredPassword);
        if (isValidEmail && isValidPassword)
        {
            _apiClient.Login(_enteredEmail, _enteredPassword);
            
        }
        else
        {
            UsernameErrorBanner.text = returnString;
            PasswordErrorBanner.text = returnString2;
        }
    }

    public void OnRegisterButtonPressed()
    {
        SceneManager.LoadScene("RegisterScene");
    }
}