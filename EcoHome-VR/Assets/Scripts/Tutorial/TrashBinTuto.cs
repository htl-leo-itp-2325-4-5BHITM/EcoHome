using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinTuto : MonoBehaviour
{
    private string paperTrashTag = "PaperTrash";
    private string paperBinTag = "PaperBin";

    public bool isThrown = false;

    [SerializeField] ParticleSystem paperParticle; 
    // Start is called before the first frame update
    void Start()
    {
        paperParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == paperTrashTag && this.gameObject.tag == paperBinTag)
        {
            Destroy(collision.gameObject);
            audioPlayer.Play();
            paperParticle.Play();
            isThrown = true;
        }
    }
}
