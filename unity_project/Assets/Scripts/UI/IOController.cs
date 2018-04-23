using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInputEvent : UnityEvent<string> { }
public class PlayerActionInputEvent : UnityEvent<string[]> { }

public enum SpecialTextType { Error, Lewd, Accent, System, Player }

public class IOController : MonoBehaviour
{
    #region Properties

    public static IOController io;

    public Text textOutput;
    public InputField inputField;

    public int maxLogHistory;
    private List<string> gameLogs;

    public PlayerInputEvent playerInputEvent;
    public PlayerActionInputEvent playerActionInputEvent;

    public bool nextInputIsGrabbed { get; private set; }
    private PlayerInputEvent nextInputEvent;

    public int inputIsGrabbed { get; private set; }
    private PlayerActionInputEvent exclusiveInputEvent;

    public bool autoLogPlayerInput;
    [HideInInspector]
    public bool readyToAct;

    public string inlineLogBuffer;

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        io = this;

        gameLogs = new List<string>();

        inputField.onEndEdit.AddListener(inputFieldEndEditing);

        FocusInputField();

        playerInputEvent = new PlayerInputEvent();
        playerActionInputEvent = new PlayerActionInputEvent();

        exclusiveInputEvent = new PlayerActionInputEvent();
        nextInputIsGrabbed = false;
        nextInputEvent = new PlayerInputEvent();

        readyToAct = true;
    }

    private void OnDestroy()
    {
        playerInputEvent.RemoveAllListeners();
        playerActionInputEvent.RemoveAllListeners();
        nextInputEvent.RemoveAllListeners();
    }

    #endregion

    #region Methods

    #region Input

    public void FocusInputField()
    {
        inputField.Select();
        inputField.ActivateInputField();
    }

    public void inputFieldEndEditing(string text)
    {
        if (!readyToAct)
        {
            if(text.Length > 0)
                IOController.io.LogError("You can't do that right now, you're doing something else");
        }
        else
        {
            if (autoLogPlayerInput && text.Length > 0)
                this.LogPlayer(">" + text);

            handlePlayerInput(text);
        }

        inputField.text = string.Empty;
        FocusInputField();
    }

    private void handlePlayerInput(string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            if (nextInputIsGrabbed)
            {
                nextInputIsGrabbed = false;
                nextInputEvent.Invoke(input);
                nextInputEvent.RemoveAllListeners();
            }
            else if (inputIsGrabbed > 0)
            {
                string[] actionArgs = input.Split(' ');
                exclusiveInputEvent.Invoke(actionArgs);
            }
            else
            {
                string[] actionArgs = input.Split(' ');
                playerActionInputEvent.Invoke(actionArgs);
                playerInputEvent.Invoke(input);
            }
        }
    }

    public void grabNextInput(UnityAction<string> callback)
    {
        nextInputEvent.AddListener(callback);
        nextInputIsGrabbed = true;
    }

    public void grabExclusiveInput(UnityAction<string[]> callback)
    {
        inputIsGrabbed++;
        exclusiveInputEvent.AddListener(callback);
    }

    public void releaseExclusiveInput(UnityAction<string[]> callback)
    {
        inputIsGrabbed--;
        exclusiveInputEvent.RemoveListener(callback);
    }

    #endregion

    #region Output

    private void updateLogDisplay()
    {
        textOutput.text = string.Join("\n", gameLogs.ToArray());
    }

    private string getColorTagForColor(Color c)
    {
        string ret = "<color=#";

        ret += ColorUtility.ToHtmlStringRGBA(c);
        ret += ">";

        return ret;
    }

    private string getColorTagForTextType(SpecialTextType type)
    {
        switch (type)
        {
            case SpecialTextType.Accent:
                return getColorTagForColor(UISkinController.skinController.skin.accentTextColor);
            case SpecialTextType.Error:
                return getColorTagForColor(UISkinController.skinController.skin.errorTextColor);
            case SpecialTextType.Lewd:
                return getColorTagForColor(UISkinController.skinController.skin.lewdTextColor);
            case SpecialTextType.Player:
                return getColorTagForColor(UISkinController.skinController.skin.playerTextColor);
            case SpecialTextType.System:
                return getColorTagForColor(UISkinController.skinController.skin.systemTextColor);
            default:
                break;
        }

        return string.Empty;
    }

    public void ClearLog()
    {
        gameLogs.Clear();
        updateLogDisplay();
    }

    #region Log

    public void Log(string message)
    {
        gameLogs.Add(message);

        if (gameLogs.Count > maxLogHistory)
            gameLogs.RemoveAt(0);

        updateLogDisplay();
    }

    public void LogWithColor(string message, Color c)
    {
        string log = string.Empty;

        log = getColorTagForColor(c);
        log += message;
        log += "</color>";

        this.Log(log);
    }

    public void LogError(string errorMessage)
    {
        this.LogWithColor(errorMessage, UISkinController.skinController.skin.errorTextColor);
    }

    public void LogAccent(string message)
    {
        this.LogWithColor(message, UISkinController.skinController.skin.accentTextColor);
    }

    public void LogLewd(string message)
    {
        this.LogWithColor(message, UISkinController.skinController.skin.lewdTextColor);
    }

    public void LogSystem(string message)
    {
        this.LogWithColor(message, UISkinController.skinController.skin.systemTextColor);
    }

    public void LogPlayer(string message)
    {
        this.LogWithColor(message, UISkinController.skinController.skin.playerTextColor);
    }

    public void LogSpecial(string message, SpecialTextType type)
    {
        switch (type)
        {
            case SpecialTextType.Error:
                LogError(message);
                break;

            case SpecialTextType.Lewd:
                LogLewd(message);
                break;

            case SpecialTextType.Accent:
                LogAccent(message);
                break;

            case SpecialTextType.System:
                LogSystem(message);
                break;

            case SpecialTextType.Player:
                LogPlayer(message);
                break;

            default:
                this.LogError("Trying to log text with unknown special type: " + type);
                Debug.LogError("Trying to log text with unknown special type: " + type);
                break;
        }
    }

    public void LogLine()
    {
        this.Log(string.Empty);
    }

    public void LogLines(int n)
    {
        string log = string.Empty;

        for (int i = 1; i < n; i++)
        {
            log += "\n";
        }

        this.Log(log);
    }

    #endregion

    #region InlineLog

    public void FlushInlineLog()
    {
        this.Log(inlineLogBuffer);
        this.ClearInlineBuffer();
    }

    public void ClearInlineBuffer()
    {
        inlineLogBuffer = string.Empty;
    }

    public void TrimInlineBufferEnd()
    {
        inlineLogBuffer = inlineLogBuffer.TrimEnd();
    }

    public void TrimInlineBuffer()
    {
        this.TrimInlineBuffer(1);
    }

    public void TrimInlineBuffer(int n)
    {
        inlineLogBuffer = inlineLogBuffer.Substring(0, inlineLogBuffer.Length - n);
    }

    public void InlineLog(string message)
    {
        inlineLogBuffer += message;
    }

    public void InlineLogWithColor(string message, Color c)
    {
        string log = string.Empty;

        log = getColorTagForColor(c);
        log += message;
        log += "</color>";

        this.InlineLog(log);
    }

    public void InlineLogError(string errorMessage)
    {
        this.InlineLogWithColor(errorMessage, UISkinController.skinController.skin.errorTextColor);
    }

    public void InlineLogAccent(string message)
    {
        this.InlineLogWithColor(message, UISkinController.skinController.skin.accentTextColor);
    }

    public void InlineLogLewd(string message)
    {
        this.InlineLogWithColor(message, UISkinController.skinController.skin.lewdTextColor);
    }

    public void InlineLogSystem(string message)
    {
        this.InlineLogWithColor(message, UISkinController.skinController.skin.systemTextColor);
    }

    public void InlineLogPlayer(string message)
    {
        this.InlineLogWithColor(message, UISkinController.skinController.skin.playerTextColor);
    }

    public void InlineLogSpecial(string message, SpecialTextType type)
    {
        switch (type)
        {
            case SpecialTextType.Error:
                InlineLogError(message);
                break;

            case SpecialTextType.Lewd:
                InlineLogLewd(message);
                break;

            case SpecialTextType.Accent:
                InlineLogAccent(message);
                break;

            case SpecialTextType.System:
                InlineLogSystem(message);
                break;

            case SpecialTextType.Player:
                InlineLogPlayer(message);
                break;

            default:
                Debug.LogError("Trying to log inline text with unknown special type: " + type);
                break;
        }
    }

    #endregion

    #endregion

    #endregion
}
