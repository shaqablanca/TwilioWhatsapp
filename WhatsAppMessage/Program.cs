using System;
using Twilio;
using Twilio.Rest.Conversations.V1.Conversation;
using Twilio.TwiML.Messaging;
using Twilio.Types;

class Program
{
    
    static void Main()
    {
        string accountSid = "ACef4....................594283a91";
        string authToken = "65c....................df9147a42";

        TwilioClient.Init(accountSid, authToken);
        string groupId = "https://chat.whatsapp.com/HlWuCxKg..........Kn7F";  // WhatsApp group ID and 
        string OuterReceiver = "+905......511";// the receiver's phone number

        // Retrieve the group participants
        var messages = MessageResource.Read(
            pathConversationSid: groupId
        );

         
        // Iterate over the messages and send them  all individually to the OuterReceiver
        foreach (var message in messages)
        {
            Twilio.Rest.Api.V2010.Account.MessageResource.Create(
                from: new PhoneNumber("whatsapp:+337......13"),       // Your Twilio phone number
                to: new PhoneNumber("whatsapp:" + OuterReceiver),   // Receiver's phone number
                body: message.Body
            );
        }
       
	        Console.WriteLine("End of Process. Check the Group Messages and other Receipient");
    }


        
}




