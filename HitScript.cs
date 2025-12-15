using UnityEngine;

public class Fighter : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Play first hit
        if (Input.GetKeyDown(KeyCode.G))
            anim.SetTrigger("hit1");

        // Play second hit
        if (Input.GetKeyDown(KeyCode.H))
            anim.SetTrigger("hit2");

        // Play third hit
        if (Input.GetKeyDown(KeyCode.J))
            anim.SetTrigger("hit3");

        // Optional: mouse click also plays hit1
        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("hit1");
    }
}
