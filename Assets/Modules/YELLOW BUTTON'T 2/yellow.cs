using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Rnd = UnityEngine.Random;

public class yellow : MonoBehaviour
{
    public KMBombModule Module;
    public KMBombInfo BombInfo;
    public KMAudio Audio;
    public KMSelectable ButtonSelectable;
    public GameObject ButtonCap;

    private static int _moduleIdCounter = 1;
    private int _moduleId;
    private bool _moduleSolved;
    public GameObject MO;
    public TextMesh DisplayText;
    public TextMesh ButtonText;

    public int M;
    public int R;
    public int W;
    public int ANSWERbutNot;
    public float NUM;
    public int Z;
    public int DOTIMES;
    public int howmanytimes;
    public int answer;
    private static readonly int[] flash = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    private void Start()
    {
        _moduleId = _moduleIdCounter++;
        ButtonSelectable.OnInteract += ButtonPress;
        ButtonSelectable.OnInteractEnded += ButtonRelease;
        M = Rnd.Range(0, 1000);
        R = Rnd.Range(1, 10);
        W = Rnd.Range(1, 10);
        NUM = R;
        ButtonText.text = W.ToString();
        DisplayText.text = M.ToString();
        print(R.ToString());
        howmanytimes = W * 2 - 1;
        DOTIMES = 0;
        while (howmanytimes > 0)
        {
            Z = W * R + M + W;
            flash[0] = Z;
            Z = flash[DOTIMES] * R + M + W;
            flash[DOTIMES + 1] = Z;
            DOTIMES += 1;
            print(DOTIMES.ToString());
            howmanytimes -= 1;
        }
        howmanytimes = W * 2;
        answer = M;
        while(howmanytimes > 0)
        {
            answer += flash[howmanytimes - 1];
            print(answer.ToString());
            howmanytimes -= 1;
        }

        print(string.Concat(flash[0].ToString(), ",", flash[1].ToString(), ",", flash[2].ToString(), ",", flash[3].ToString(), ",", flash[4].ToString(), ",", flash[5].ToString(), ",", flash[6].ToString(), ",", flash[7].ToString(), ",", flash[8].ToString(), ",", flash[9].ToString(), ",", flash[10].ToString(), ",", flash[11].ToString(), ",", flash[12].ToString(), ",", flash[13].ToString(), "", flash[14].ToString(), ",", flash[15].ToString(), ",", flash[16].ToString(), ",", flash[17].ToString(), ",", flash[18].ToString(), ",", flash[19].ToString()));
        print(answer.ToString());
        Debug.LogFormat("[Yellow Button't #{0}] Correct Answer: {1}", _moduleId, (answer % 60).ToString());
        Debug.LogFormat("[Yellow Button't #{0}] Gear's teeth from Z1 to ZW: {1}", _moduleId, string.Concat(flash[0].ToString(),",", flash[1].ToString(), ",", flash[2].ToString(), ",", flash[3].ToString(), ",", flash[4].ToString(), ",", flash[5].ToString(), ",", flash[6].ToString(), ",", flash[7].ToString(), ",", flash[8].ToString(), ",", flash[9].ToString(),",",flash[10].ToString(), ",", flash[11].ToString(), ",", flash[12].ToString(), ",", flash[13].ToString(), "", flash[14].ToString(), ",", flash[15].ToString(), ",", flash[16].ToString(), ",", flash[17].ToString(), ",", flash[18].ToString(), ",", flash[19].ToString()));
        Debug.LogFormat("[Yellow Button't #{0}] Last gear is drive gear.", _moduleId);
        Debug.LogFormat("[Yellow Button't #{0}] Total calculated number: {1}", _moduleId,answer.ToString());
        Debug.LogFormat("[Yellow Button't #{0}] W = {1}", _moduleId, W.ToString());
        Debug.LogFormat("[Yellow Button't #{0}] R = {1}", _moduleId, R.ToString());
        Debug.LogFormat("[Yellow Button't #{0}] M = {1}", _moduleId, M.ToString());
        Debug.LogFormat("[Yellow Button't #{0}] Rotation speed: {1}", _moduleId,string.Concat(R.ToString(),"f"));
        StartCoroutine(FlyEgg());
    }

    private bool ButtonPress()
    {
        StartCoroutine(AnimateButton(0f, -0.05f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, transform);
        if (!_moduleSolved)
        {
            Debug.LogFormat("[Yellow Button't #{0}] Held the button", _moduleId);
            if ((int)BombInfo.GetTime() % 60 == answer % 60) 
            {
                DisplayText.text = "GG!";
                GetComponent<KMBombModule>().HandlePass();
                NUM = 0.1f;
                _moduleSolved = true;
                Debug.LogFormat("[Yellow Button't #{0}] Solve!!!", _moduleId);
            }
            else
            {
                GetComponent<KMBombModule>().HandleStrike();
                Debug.LogFormat("[Yellow Button't #{0}] Strike!!!", _moduleId);
            }
        }
        return false;
    }

    private void ButtonRelease()
    {
        StartCoroutine(AnimateButton(-0.05f, 0f));
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonRelease, transform);
        if (!_moduleSolved)
        {
            print("RELEASE");
        }
    }

    private IEnumerator AnimateButton(float a, float b)
    {
        var duration = 0.1f;
        var elapsed = 0f;
        while (elapsed < duration)
        {
            ButtonCap.transform.localPosition = new Vector3(0f, Easing.InOutQuad(elapsed, a, b, duration), 0f);
            yield return null;
            elapsed += Time.deltaTime;
        }
        ButtonCap.transform.localPosition = new Vector3(0f, b, 0f);
    }

    private IEnumerator FlyEgg()
    {
        var duration = NUM;
        var elapsed = 0f;
        while (elapsed < duration)
        {
            MO.transform.localEulerAngles = new Vector3(0f, Easing.OutQuad(elapsed, 0f, 360f, duration), 0f);
            yield return null;
            elapsed += Time.deltaTime;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(FlyEgg());
    }

#pragma warning disable 0414
    public readonly string TwitchHelpMessage = @"!{0} press ## to press the button at XX:##.";
#pragma warning restore 0414

    private IEnumerator ProcessTwitchCommand(string command)
    {
        print(command);
        var parameters = command.ToUpperInvariant().Split();
        var m = Regex.Match(parameters[0], @"^\s*press\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        if (!m.Success)
            yield break;
        if (parameters.Length < 2)
            yield break;
        var list = new List<int>();
        for (int i = 1; i < parameters.Length; i++)
        {
            int val;
            if (!int.TryParse(parameters[i], out val) || val < 0 || val > 60)
                yield break;
            list.Add(val);
        }
        yield return null;
        for (int i = 0; i < list.Count; i++)
        {
            while ((int)BombInfo.GetTime() % 60 != list[i])
                yield return "trycancel";
            ButtonSelectable.OnInteract();
            yield return new WaitForSeconds(0.1f);
            ButtonSelectable.OnInteractEnded();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator TwitchHandleForcedSolve()
    {
        while ((int)BombInfo.GetTime() % 60 != answer % 60)
            yield return true;
        ButtonSelectable.OnInteract();
        yield return new WaitForSeconds(0.1f);
        ButtonSelectable.OnInteractEnded(); ;
    }
}
