// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FirstBot.Dialogs;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;

namespace FirstBot.Bots
{
    public class AirlineBot : ActivityHandler
    {
        protected readonly Dialog Dialog;
        protected readonly BotState ConversationState;
        protected readonly BotState UserState;

        public AirlineBot(ConversationState conversationState, UserState userState, MainDialog dialog)
        {
            this.ConversationState = conversationState;
            this.UserState = userState;
            this.Dialog = dialog;
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.OnTurnAsync(turnContext, cancellationToken);

            await ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            await UserState.SaveChangesAsync(turnContext, false, cancellationToken);
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            #region step1
            //Random rnd = new Random();
            //String reply = $"H{new String('o', rnd.Next(1, 4))}d{new String('o', rnd.Next(1, 3))}r!";

            //await turnContext.SendActivityAsync(CreateActivityWithTextAndSpeak(reply), cancellationToken);
            #endregion
            #region step2
            //switch (turnContext.Activity.Text)
            //{
            //    case "Bonjour":
            //        answer = "Yop";
            //        break;
            //    case "Reserver":
            //        answer = "Alz";
            //        break;
            //    case "Au revoir":
            //        answer = "Tchouss";
            //        break;
            //    default:
            //        answer = "J'ai pas compris";
            //        break;
            //}
            #endregion
            await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>("DialogState"), cancellationToken);
        }
    }
}
