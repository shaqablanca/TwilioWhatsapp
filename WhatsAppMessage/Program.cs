using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Conversations.V1.Conversation;
using Twilio.Types;

class Program
{
    
    static void Main()
    {
        const string accountSid = "ACef4....................594283a91";
        const string authToken = "65c....................df9147a42";

        TwilioClient.Init(accountSid, authToken);
        string groupId = "https://chat.whatsapp.com/HlWuCxKgIxm3N1IRXsKn7F";  // WhatsApp group ID and 
        string receiverNumber = "+905......511";// the receiver's phone number

        // Retrieve the group participants
        var members = ParticipantResource.Read(
            pathConversationSid: groupId
        );

        // Iterate over the participants and send a message
        foreach (var member in members)
        {
            // Exclude the receiver from the group message
            if (member.Identity != receiverNumber)
            {
                Twilio.Rest.Api.V2010.Account.MessageResource.Create(
                    from: new PhoneNumber("whatsapp:+337......13"), // Your Twilio phone number
                    to: new PhoneNumber("whatsapp:" + member.Identity), // Participant's phone number
                    body: "Hello, this is a group message!"
                );
            }

        }


        Console.WriteLine("End of Process. Check the Group Messages and other Receipient");
    }



}
