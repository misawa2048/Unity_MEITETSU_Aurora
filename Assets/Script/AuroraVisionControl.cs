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
        // ���C�v��ON�ɂ���
        m_wipeL.fillAmount = 1f;
        m_wipeR.fillAmount = 1f;

        // ���C�v�̐F��OFF�F�ɂ���
        m_wipeL.color = m_wipeOffColor;
        m_wipeR.color = m_wipeOffColor;

        // 2�b�҂�
        yield return new WaitForSeconds(2f);
        m_wipeL.color = m_wipeOnColor;
        m_wipeR.color = m_wipeOnColor;

        // ���C�v�̐F��ON�F�ɂ���
        m_wipeL.color = m_wipeOnColor;
        m_wipeR.color = m_wipeOnColor;

        float timer = 1f; // �^�C�}�[���P��
        while (timer > 0f)  // �^�C�}�[��0���傫���ԑ�����
        {
            timer -= Time.deltaTime * 0.05f; // 1�b�Ԃ�0.05�����i�߂�
            // ���̃��C�v���������J����
            m_wipeL.fillAmount = timer;
            yield return null; // �������񒆒f
        }

        // 1�b�҂�
        yield return new WaitForSeconds(1f);

        timer = 1f; // �^�C�}�[���P��
        while (timer > 0f)  // �^�C�}�[��0���傫���ԑ�����
        {
            timer -= Time.deltaTime * 0.05f; // 1�b�Ԃ�0.05�����i�߂�
            // �E�̃��C�v���������J����
            m_wipeR.fillAmount = timer;
            yield return null; // �������񒆒f
        }
        yield break; // �I��
    }
}
