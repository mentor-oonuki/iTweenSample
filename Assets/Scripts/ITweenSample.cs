using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ITweenSample : MonoBehaviour
{
    private bool isITweenMoving = false;

    // EaseTypeリストの配列
    private string[] EaseType =
    {
        "easeInQuad",
        "easeOutQuad",
        "easeInOutQuad",
        "easeInCubic",
        "easeOutCubic",
        "easeInOutCubic",
        "easeInQuart",
        "easeOutQuart",
        "easeInOutQuart",
        "easeInQuint",
        "easeOutQuint",
        "easeInOutQuint",
        "easeInSine",
        "easeOutSine",
        "easeInOutSine",
        "easeInExpo",
        "easeOutExpo",
        "easeInOutExpo",
        "easeInCirc",
        "easeOutCirc",
        "easeInOutCirc",
        "linear",
        "spring",
        "easeInBounce",
        "easeOutBounce",
        "easeInOutBounce",
        "easeInBack",
        "easeOutBack",
        "easeInOutBack",
        "easeInElastic",
        "easeOutElastic",
        "easeInOutElastic"
    };
    public static int EaseTypeNumber = 0;


    void Start()
    {
        // ドロップダウンリストの生成
        Dropdown dropdown = (Dropdown)GameObject.FindObjectOfType<Dropdown>();
        dropdown.GetComponent<Dropdown>().options.Clear();
        for (int index = 0; index < EaseType.Length; index++)
        {
            dropdown.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData(EaseType[index]));
        }
    }


    void Update()
    {
        if (!isITweenMoving)
        {
            isITweenMoving = true;

            float x = Random.Range(-10.0f, 10.0f);
            float y = Random.Range(-8.0f, 8.0f);
            float z = 0f;
            Vector3 vector = new Vector3(x, y, z);
            Tween(vector, EaseType[EaseTypeNumber]);
        }
    }


    // ローカル座標系で指定座標へ移動
    // iTween.Hashでキーバリュー形式のハッシュ作成
    // 第１引数：ターゲットGameObject, 第２引数：移動に関する各種パラメータのハッシュ
    void Tween(Vector3 vector, string easeType)
    {
        iTween.MoveTo(this.gameObject, iTween.Hash(
            "position", vector,
            "time", 1.0f,
            "oncomplete", "Complete",
            "oncompletetarget", this.gameObject,
            "easeType", easeType
        //"space", Space.worldでグローバル座標系で移動
        ));
    }

    //終了時実行メソッド
    //iTween.Stop(gameobject, アニメーションタイプ（オプション）;
    //ターゲットのTweenを終了する
    public void Complete()
    {
        isITweenMoving = false;
        iTween.Stop(this.gameObject, "move");
    }

}