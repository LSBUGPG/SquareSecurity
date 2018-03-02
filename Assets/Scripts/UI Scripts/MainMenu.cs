using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public AudioSource CameraSwapSound; //Audio - public AudioSource (What you want to name it)

    public void StartGame () {
        Application.LoadLevel(2);
        CameraSwapSound.Play(); //Audio - Name of Audio source.
    }

    public void ExitGame() {
        CameraSwapSound.Play(); //Audio - Name of Audio source.
        Application.Quit();
    }

    public void MenuGame() {
        Application.LoadLevel(1);
        CameraSwapSound.Play(); //Audio - Name of Audio source.
    }

    public void GreenGlassesButton() {
        Application.OpenURL("https://www.google.co.uk/search?rlz=1C1CHBF_en-GBGB703GB703&biw=1680&bih=919&tbm=isch&sa=1&ei=gf4lWtufGMyQgAb-mKvoAQ&q=Green+Glasses&oq=Green+Glasses&gs_l=psy-ab.3..0i67k1j0l9.7032.7032.0.7212.1.1.0.0.0.0.85.85.1.1.0....0...1c.1.64.psy-ab..0.1.82....0.-2Iwmq9M_fE");
        CameraSwapSound.Play(); //Audio - Name of Audio source.
    }

    public void CreditsButton() {
        CameraSwapSound.Play(); //Audio - Name of Audio source.
        Application.LoadLevel(4);
    }
}
