using UnityEngine;
using TMPro;
using System.Collections;
public class TpyeWriterEffect : MonoBehaviour
{
    [SerializeField] private int writingSpeed;
    public Coroutine Run(string texttotype, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(texttotype, textLabel));
    }
    private IEnumerator TypeText(string texttotype, TMP_Text textLabel)
    {
        if (writingSpeed<=0)
        {
            writingSpeed = 1;
        }

        textLabel.text = string.Empty;
        
           
        // idea: to make the word appear in the writing effect by mkae the word appear in each second / or in 1 word in 60 frame
        float t = 0;
        int charIndex = 0;
        while (charIndex < texttotype.Length)
        {
            t+= Time.deltaTime*writingSpeed;
            charIndex = Mathf.FloorToInt(t); // make the t value add up by fame/1sec, when frame = 1, it will write the word down
            charIndex = Mathf.Clamp(charIndex, 0, texttotype.Length); //make sure that charindex never be > the text

            textLabel.text = texttotype.Substring(0,charIndex); // write down
            yield return null;
        }

        textLabel.text = texttotype;

    }
}
