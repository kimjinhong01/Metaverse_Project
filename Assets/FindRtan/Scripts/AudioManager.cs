using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindRtan
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        AudioSource audioSource;
        public AudioClip clip;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DestroyMusic()
        {
            Destroy(gameObject);
        }
    }
}