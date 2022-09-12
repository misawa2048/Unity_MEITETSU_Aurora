using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TmLib
{
    public class TmJitter : MonoBehaviour
    {
        [SerializeField, Range(0f, 45f)] float m_fluctuationAngle = 3f;
        [SerializeField, Range(0f, 45f)] float m_fluctuationRotation = 3f;
        Quaternion m_defRot;
        Quaternion m_targetRot;
        float m_targetAngle;

        private void Awake()
        {
            m_defRot = transform.rotation;
            m_targetRot = Quaternion.identity;
            m_targetAngle = 0f;
        }
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(jitterCo());
        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, m_targetRot,0.01f);

        }

        IEnumerator jitterCo()
        {
            while (true)
            {
                float tmpAngleV = Random.Range(-m_fluctuationAngle, m_fluctuationAngle);
                float tmpAngleH = Random.Range(-m_fluctuationAngle, m_fluctuationAngle);
                Quaternion tmpRot = Quaternion.AngleAxis(tmpAngleV, Vector3.right); // è„â∫Ç…êUÇÈ
                tmpRot = tmpRot * Quaternion.AngleAxis(tmpAngleH, Vector3.up); // ç∂âE
                Vector3 lookDir = tmpRot * Vector3.forward;
                m_targetRot = m_defRot * Quaternion.LookRotation(lookDir);
                m_targetAngle = Random.Range(-m_fluctuationRotation, m_fluctuationRotation);
                m_targetRot *= Quaternion.AngleAxis(m_targetAngle, Vector3.forward);
                yield return new WaitForSeconds(Random.Range(0.1f,1.5f));
            }
        }
    }
}
