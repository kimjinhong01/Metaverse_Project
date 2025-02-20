using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindRtan
{
    public class Card : MonoBehaviour
    {
        public int idx = 0;

        public GameObject front;
        public GameObject back;

        public Animator anim;

        AudioSource audioSource;
        public AudioClip clip;

        public SpriteRenderer frontImage;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Setting(int number)
        {
            idx = number;
            frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
        }

        public void OpenCard()
        {
            if (GameManager.Instance.secondCard != null) return;

            audioSource.PlayOneShot(clip);
            anim.SetBool("isOpen", true);
            front.SetActive(true);
            back.SetActive(false);

            // firstCard�� ����ٸ�,
            if (GameManager.Instance.firstCard == null)
            {
                // firstCard�� �� ������ �Ѱ��ش�.
                GameManager.Instance.firstCard = this;
            }
            // firstCard�� ������� �ʴٸ�,
            else
            {
                // secondCard�� �� ������ �Ѱ��ش�.
                GameManager.Instance.secondCard = this;
                // Matched �Լ��� ȣ���� �ش�.
                GameManager.Instance.Matched();
            }
        }

        public void DestroyCard()
        {
            Invoke("DestroyCardInvoke", 0.5f);
        }

        void DestroyCardInvoke()
        {
            Destroy(gameObject);
        }

        public void CloseCard()
        {
            Invoke("CloseCardInvoke", 0.5f);
        }

        void CloseCardInvoke()
        {
            anim.SetBool("isOpen", false);
            front.SetActive(false);
            back.SetActive(true);
        }
    }
}