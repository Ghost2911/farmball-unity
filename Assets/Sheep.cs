using UnityEngine;

public class Sheep : MonoBehaviour
{
    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.speed = Random.Range(0.6f,1.3f);
    }

    public void SetRotating(bool isRotate)
    {
        _anim.SetBool("isRotate", isRotate);
    }
}
