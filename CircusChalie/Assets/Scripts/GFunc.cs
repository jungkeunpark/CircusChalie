using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public static partial class GFunc
{
    //디버그모드일때만 적용이 가능하게 바꾼다.
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        //Debug.Log에 대해 래핑해줬다.
        //음식같은걸 보관할때 랲으로 싸듯이 내가 필요할때마다 사용할려고 준비하는것들.
        //EX)C++에서 사용하는것들을  C#에서 사용하려고 래핑함
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }



    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }

        textComponent.text = text;
    }


    //! LoadScene 함수 래핑
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //! 현재 씬의 이름을 리턴한다.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! 두 백터를 더한다
    public static Vector2 AddVector(this Vector3 origin, Vector2 addvector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addvector;
        return result;
    }

    //!컴포넌트가 존재하는지 여부를 체크하는 함수
    public static bool IsValid<T>(this T target) where T : Component
    {
        if (target == null || target == default) { return false; }
        else { return true; }
    }

    //! 리스트가 유효한지 여부를 체크하는 함수
    public static bool IsValid<T>(this List<T> target)

    {
        bool isInvalid = (target == null || target == default);
        isInvalid = isInvalid || target.Count == 0;

        if (isInvalid == true) { return false; }
        else { return true; }
    }

}
