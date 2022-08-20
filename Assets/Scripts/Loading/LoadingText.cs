using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingText : MonoBehaviour
{
    public Text Tip;
    public Text Loading;
    private string[] Load =
    {
        "...",
        "...",
        "...",
        "...",
        "...",
        "...",
        "...",
        "...",
        "...",
        "..."
    };

    private string[] Tips = 
    {
        "모든 업적을 달성해 보세요",
        "차키가 있지만 차를 탈 수는 있을까요?",
        "전쟁은 절대 일어나서는 안 됩니다",
        "평화로운 세상을 위하여",
        "물과 식량은 생존에 필수적입니다",
        "업적을 확인하여 자세한 내용을 확인하세요",
        "집에서는 아이템을 획득할 수 있습니다",
        "모든 위험을 해치고 도망치세요"
    };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Typing());

        Tip.text = "TIP l " + Tips[UnityEngine.Random.Range(0, Tips.Length)] + " l";
    }

    int i;
    private IEnumerator Typing()
    {
        yield return new WaitForSeconds(0.3f);
        for (i = 0; i < Load.Length; i ++)
        {
            var load = Load[i];

            for (var j = 0; j <= load.Length; j++)
            {
                Loading.text = "LOADING" + load.Substring(0, j);
                yield return new WaitForSeconds(0.3f);
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}
