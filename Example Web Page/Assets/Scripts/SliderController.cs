using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Image sliderImage;                // Deðiþen büyük görsel
    public Sprite[] sliderSprites;           // Deðiþecek sprite'lar
    public Image[] indicatorDots;            // Noktalar (dolu/boþ göstermek için)
    public Sprite fullDotSprite;             // Dolu hal (aktif nokta)
    public Sprite emptyDotSprite;            // Boþ hal (pasif nokta)

    public float changeInterval = 3f;        // Kaç saniyede bir geçsin
    private int currentIndex = 0;
    private float timer;

    void Start()
    {
        UpdateSlider();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            timer = 0f;
            currentIndex = (currentIndex + 1) % sliderSprites.Length;
            UpdateSlider();
        }
    }

    void UpdateSlider()
    {
        sliderImage.sprite = sliderSprites[currentIndex];

        for (int i = 0; i < indicatorDots.Length; i++)
        {
            indicatorDots[i].sprite = (i == currentIndex) ? fullDotSprite : emptyDotSprite;
        }
    }
    public void GoToSlide(int index)
    {
        currentIndex = index;
        timer = 0f; // tekrar baþlat
        UpdateSlider();
    }

}
