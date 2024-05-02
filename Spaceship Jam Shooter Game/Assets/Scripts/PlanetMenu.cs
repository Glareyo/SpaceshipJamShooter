using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private int GoToSceneID;

    private Sprite OriginalImage;

    [SerializeField]
    private Sprite HoverImage;

    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        OriginalImage = image.sprite;
        
    }

    public void SelectPlanet()
    {
        SceneManager.LoadScene(GoToSceneID);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = HoverImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = OriginalImage;
    }
}
