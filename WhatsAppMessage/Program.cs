using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Conversations.V1.Conversation;
using Twilio.Types;

class Program
{
    static void Main()
    {
        const string accountSid = "YOUR_ACCOUNT_SID";
        const string authToken = "YOUR_AUTH_TOKEN";

        TwilioClient.Init(accountSid, authToken);

        // Specify the WhatsApp group ID and the receiver's phone number
        string groupId = "YOUR_GROUP_ID";
        string receiverNumber = "RECEIVER_PHONE_NUMBER";

        // Retrieve the group participants
        var participants = ParticipantResource.Read(
            pathConversationSid: groupId,
            limit: 20 // Adjust the limit if needed
        );

        // Iterate over the participants and send a message to the receiver
        foreach (var participant in participants)
        {
            // Exclude the receiver from the group message
            if (participant.Address != receiverNumber)
            {
                Twilio.Rest.Api.V2010.Account.MessageResource.Create(
                    from: new PhoneNumber("whatsapp:YOUR_PHONE_NUMBER"), // Your Twilio phone number
                    to: new PhoneNumber("whatsapp:" + participant.Address), // Participant's phone number
                    body: "Hello, this is a group message!"
                );
            }
        }

        Console.WriteLine("Group messages sent successfully.");
    }
}
