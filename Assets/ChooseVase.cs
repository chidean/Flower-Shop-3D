using UnityEngine;

public class ChooseVase : MonoBehaviour
{
    public LayerMask layer;
    GeneralManager gm;
    ArrangeManager gameManager;
    Camera mainCam;

    private void Start()
    {
        gm = GeneralManager.Instance;
        gameManager = ArrangeManager.Instance;
        mainCam = Camera.main;
    }

    private void Choose(Vase vase)
    {
        gameManager.ChoseVase(vase.vaseType);
        GetComponent<VasesAnimation>().AnimateChosenVase(vase.transform);
        var mover = GetComponent<VaseMover>();
        mover.movingVase = vase.transform;
        mover.enabled = true;
        enabled = false;
    }

    void Update()
    {
        if (gm.Status == GameStatus.Cut)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    var vase = hit.transform?.GetComponent<Vase>();
                    if (vase)
                    {
                        Choose(vase);
                    }
                }
            }
        }
    }
}
