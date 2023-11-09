using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;

    private SpriteRenderer spriteRenderer;
    private int _animationFrame;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        InvokeRepeating(nameof(Animate), 0f, animationTime);
    }

    private void Animate()
    {
        _animationFrame = _animationFrame + 1;

        // Loop back the first sprite if exceed length
        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        // Set Sprite
        spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

}
