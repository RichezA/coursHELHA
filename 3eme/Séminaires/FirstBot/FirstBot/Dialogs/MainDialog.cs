using FirstBot.Helpers;
using FirstBot.Models;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FirstBot.Dialogs
{
    public class MainDialog : ComponentDialog
    {
        public MainDialog()
        {
            AddDialog(new BookingDialog());
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
            IntroStepAsync,
            UserChoiceStepAsync,
            FinalStepAsync,

            }));
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken token)
        {
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("Salut!"), token);
            return await stepContext.NextAsync();
        }

        private async Task<DialogTurnResult> UserChoiceStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var goodByeIntent = new[] { "AUREVOIR", "BYE", "MERCI" };
            string answer = "";
            String receivedInput = stepContext.Context.Activity.Text;

            if (StringHelper.CleanString(receivedInput) == "BONJOUR") answer = "Salut !";
            else if (StringHelper.CleanString(receivedInput).Contains("RESERVE")) return await stepContext.BeginDialogAsync(nameof(BookingDialog), new UserBookingDetails(), cancellationToken);
            else if (StringHelper.CleanString(receivedInput).Contains("IDENTI")) return await stepContext.BeginDialogAsync(nameof(UserDialog), new UserDetails(), cancellationToken);
            else if (goodByeIntent.Any(x => StringHelper.CleanString(receivedInput).Contains(x))) answer = "A bientôt !";
            else answer = "Je n'ai pas compris";

            await stepContext.Context.SendActivityAsync(MessageFactory.Text(answer), cancellationToken);
            return await stepContext.NextAsync();
        }

        private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken token)
        {
            var bookingDetails = (BookingDetails)stepContext.Result;
            var messageTxt = $"Nous avons valider le vol de { bookingDetails.Origin} vers { bookingDetails.Destination} pour le { bookingDetails.TravelDate}";

            await stepContext.Context.SendActivityAsync(MessageFactory.Text(messageTxt), token);
            return await stepContext.EndDialogAsync();
        }

    }
}
