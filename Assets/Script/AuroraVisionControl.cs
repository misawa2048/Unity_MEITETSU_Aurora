using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuroraVisionControl : MonoBehaviour
{
    [SerializeField] Color m_wipeOffColor;
    [SerializeField] Color m_wipeOnColor;

    [SerializeField] Image m_wipeL;
    [SerializeField] Image m_wipeR;

    [SerializeField] TMPro.TMP_Text m_leftUpperText;
    [SerializeField] TMPro.TMP_Text m_leftBottomText;
    [SerializeField] TMPro.TMP_Text m_rightUpperText;
    [SerializeField] TMPro.TMP_Text m_rightBottomText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WipeCo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WipeCo()
    {
        // ワイプをONにする
        m_wipeL.fillAmount = 1f;
        m_wipeR.fillAmount = 1f;

        // ワイプの色をOFF色にする
        m_wipeL.color = m_wipeOffColor;
        m_wipeR.color = m_wipeOffColor;

        // 2秒待つ
        yield return new WaitForSeconds(2f);
        m_wipeL.color = m_wipeOnColor;
        m_wipeR.color = m_wipeOnColor;

        // ワイプの色をON色にする
        m_wipeL.color = m_wipeOnColor;
        m_wipeR.color = m_wipeOnColor;

        float timer = 1f; // タイマーを１に
        while (timer > 0f)  // タイマーが0より大きい間続ける
        {
            timer -= Time.deltaTime * 0.05f; // 1秒間に0.05だけ進める
            // 左のワイプを少しずつ開ける
            m_wipeL.fillAmount = timer;
            yield return null; // いったん中断
        }

        // 1秒待つ
        yield return new WaitForSeconds(1f);

        timer = 1f; // タイマーを１に
        while (timer > 0f)  // タイマーが0より大きい間続ける
        {
            timer -= Time.deltaTime * 0.05f; // 1秒間に0.05だけ進める
            // 右のワイプを少しずつ開ける
            m_wipeR.fillAmount = timer;
            yield return null; // いったん中断
        }
        yield break; // 終了
    }
}
