using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Conversations.V1.Conversation;
using Twilio.Types;

class Program
{
    static void Main()
    {
        const string accountSid = "AccountSidFromTwilio";
        const string authToken = "AccountAuthTokenFromTwilio";

        TwilioClient.Init(accountSid, authToken);

        
        string groupId = "WhatsAppGroupId";  // WhatsApp group ID and 
        string receiverNumber = "ReceiverNumberWhoIsOutOfGroup";// the receiver's phone number

        // Retrieve the group participants
        var participants = ParticipantResource.Read(
            pathConversationSid: groupId,
            limit: 6 
        );

        // Iterate over the participants and send a message
        foreach (var participant in participants)
        {
            // Exclude the receiver from the group message
            if (participant.Address != receiverNumber)
            {
                Twilio.Rest.Api.V2010.Account.MessageResource.Create(
                    from: new PhoneNumber("whatsapp:" + participant.Address), // Your Twilio phone number
                    to: new PhoneNumber("whatsapp:" + participant.Address), // Participant's phone number
                    body: "Hello, this is a group message!"
                );
            }

        }


        Console.WriteLine("End of Process. Check the Group Messages and other Receipient");
    }



}
