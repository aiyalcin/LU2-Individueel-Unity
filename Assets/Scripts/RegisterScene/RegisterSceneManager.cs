using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RegisterSceneManager : MonoBehaviour
{

    public TMP_InputField EmailInputField;
    public TMP_InputField PasswordInputField;
    public TMP_Text EmailErrorBanner;
    public TMP_Text PasswordErrorBanner;
    private string _enteredEmail;
    private string _enteredPassword;
    private CredentialsValidator _credentialsValidator;
    private void Start()
    {
        _credentialsValidator = new CredentialsValidator();
    }
    // Update is called once per frame
    public void OnRegisterButtonPressed()
    {
        _enteredEmail = EmailInputField.text;
        _enteredPassword = PasswordInputField.text;
        var (isValidEmail, returnString) = _credentialsValidator.ValidateEmail(_enteredEmail);
        var (isValidPassword, returnString2) = _credentialsValidator.ValidatePassword(_enteredPassword);
        if (isValidEmail && isValidPassword)
        {
            Debug.Log("Register successful");
        }
        else
        {
            EmailErrorBanner.text = returnString;
            PasswordErrorBanner.text = returnString2;
        }
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("LoginScene");
        Debug.Log("Back button pressed");
    }
}
