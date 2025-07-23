using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class InkHandler : MonoBehaviour
{
    void Awake()
    {
        // Remove the default message
       RemoveChildren();
    }

    public void Begin()
    {
        RemoveChildren();
        StartStory();
        
    }

    // Creates a new Story object with the compiled story which we can then play!
    public void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        OnDialogueStart.Invoke();
       // if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }
    public void RefreshView()
    {
        // Remove all the UI on screen
      RemoveChildren();

        // Read all the content until we can't continue any more
        //this kinda works in that it will search for knot names or otherwise print only unknotted content
        //unknotted content will always print FIRST
        //have a default string + idle text to go to when not directing knot
        if (story.canContinue)
            {
            storyBegin = true;
            Debug.Log("can story begin? "+storyBegin);

            // Continue gets the next line of the story
            currentText = story.Continue();

                // This removes any white space from the text.
                currentText = currentText.Trim();
            // Display the text on screen!
            CreateContentView(currentText);

        }
        else 
        { 
            RunKnot(knotName);
            storyBegin = true;
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
            {
                for (int i = 0; i < story.currentChoices.Count; i++)
                {
                    Choice choice = story.currentChoices[i];
                    Button button = CreateChoiceView(choice.text.Trim());
                    // Tell the button what to do when we press it
                    button.onClick.AddListener(delegate
                    {
                        OnClickChoiceButton(choice);
                    });
                }
            }
            // If we've read all the content and there's no choices, the story is finished!
            else
            {
            //Button choice = CreateChoiceView("End of story.\nRestart?");
            //choice.onClick.AddListener(delegate
            //{
            //    StartStory();
            //});

            RemoveChildren();
            storyBegin = false;
            Debug.Log("can story begin? " + storyBegin);
            //clear out dialogue boxes
            OnDialogueEnd.Invoke();
        }

    }

    //add to the handler a way to direct to ink knots in Unity Scripts
    public void RunKnot(string knotName)
    {
        story.ChoosePathString(knotName);
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    // Creates a textbox showing the the line of text       //connect all strings into one game object instead of cloning multiple game objects!
    void CreateContentView(string text)
    {
        //testing this with tags

        List<string> tags = story.currentTags;

        if (tags.Count > 0)
        {
            if (tags.Contains("q"))
            {
                textBoxQ.text = text;
                textBoxClay.text = "";
            }
            else if(tags.Contains("clay")){
                textBoxClay.text = text;
                textBoxQ.text = "";//blank strings so they dont interrupt each other
            }
            if (tags.Contains("NPC"))
            {
                textBoxNPC.text = text;
                textBoxQ.text = "";
                textBoxClay.text = "";
            }
            CheckTags();
        }
        else
        {
            textBoxQ.text = text; //assume tagless text is q
        }

    }

   

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        //Button choice = buttonPrefab;
        choice.transform.SetParent(canvas.transform);

        // Gets the text from the button prefab
        //Text choiceText = choice.GetComponentInChildren<Text>();  //for unity ui
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();    //for tmp
        choiceText.text = text;

        // Make the button expand to fit the text
        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;
        //ISSUE: NEEDS THIS TO print many choices... but prints dialog weirD
        return choice;
    }

    public void ClearText()
    {
        textBoxQ.text = "";
        textBoxClay.text = "";
        textBoxNPC.text = "";

    }

    public void RemoveChildren()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
        }
    }

    #region Tags
    //checks tags of current line of dialogue for events
    void CheckTags()
    {
        //runs through all current tags
        foreach (string tag in story.currentTags)
        {

            //this method allows anyone to edit what happens when a tag is called in the inspector
            //runs through each tag in the tag list
            foreach (Tag tagCheck in Tags)
            {
                //checks if the tag contains a certain marker from the tag list
                if (tag.Contains(tagCheck.marker))
                {
                    //calls whatever method(s) occur when this tag is called and passes the tag data through
                    tagCheck.TagFunctions.Invoke(GetTagData(tag));
                    //stops the loop
                    break;
                }
            }
        }
    }

    //takes data from the marked tag and returns it as a value
    string GetTagData(string tag)
    {
        //removes the marking from the string in the tag
        string tagData = tag.Remove(0, 1);

        if (!string.IsNullOrEmpty(tagData))
            return tagData;

        else
        {
            return (null);
        }
    }
    #endregion

    //function for testing events
    public void DebugMessage(string message)
    {
        Debug.Log(message);
    }
    
    public GameManager gm;
    public QuestManager qm;

    [SerializeField]
    public TextAsset inkJSONAsset = null;

    public Story story;
    public bool storyBegin;
    public string currentText;
    public string knotName;

    public TMP_Text textBoxQ;
    public TMP_Text textBoxClay;
    public TMP_Text textBoxNPC = null;


    [SerializeField]
    private Canvas canvas = null;

    // UI Prefabs
   // [SerializeField]
    //private Text textPrefab = null;
   // private TMP_Text textPrefab = null;
    [SerializeField]
    private Button buttonPrefab = null;

    [Header("Events")]
    public UnityEvent OnDialogueStart;
    public UnityEvent OnLineEnd;
    public UnityEvent OnDialogueEnd;

    

    [Header("Tag List")]
    public Tag[] Tags;

    [System.Serializable]
    public struct Tag
    {
        public string marker;
        public TagFunctions TagFunctions;
    }
    
    //This class is only here so that an event that takes a string value parameter shows up in the inspector
    [System.Serializable]
    public class TagFunctions : UnityEvent<string>
    {
    }
}

