using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using UnityEngine.Events;

public class ChatGPT : MonoBehaviour
{
    public OnResponseEvent OnResponse;

    [System.Serializable]
    public class OnResponseEvent: UnityEvent<string> { }

    // Start is called before the first frame update

    private OpenAIApi openAI= new OpenAIApi("apikey");
    private List<ChatMessage> messages= new List<ChatMessage>();

    public async void AskChatGPT(string newText){
        ChatMessage newMessage= new ChatMessage();

        newMessage.Content= newText;
        newMessage.Role= "user";

        messages.Add(newMessage);

        CreateChatCompletionRequest request= new CreateChatCompletionRequest();
        request.Messages= messages;
        request.Model= "gpt-3.5-turbo";

        var response= await openAI.CreateChatCompletion(request);

        if(response.Choices!= null&& response.Choices.Count> 0){
            var chatResponse= response.Choices[0].Message;
            messages.Add(chatResponse);

            Debug.Log(chatResponse.Content);

            OnResponse.Invoke(chatResponse.Content);

        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
