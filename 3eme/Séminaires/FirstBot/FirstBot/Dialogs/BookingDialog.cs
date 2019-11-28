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
    public class BookingDialog : ComponentDialog
    {
        public BookingDialog()
        {
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new ConfirmPrompt(nameof(ConfirmPrompt)));
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                IntroStepAsync,
                DestinationStepAsync,
                OriginStepAsync,
                TravelDateStepAsync,
                ConfirmStepAsync,
                FinalStepAsync
            }));

            InitialDialogId = nameof(WaterfallDialog);
        }


        private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //await stepContext.Context.SendActivityAsync(MessageFactory.Text("Salut!"), cancellationToken);
            return await stepContext.NextAsync();
        }
        private async Task<DialogTurnResult> DestinationStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var promptMessage = MessageFactory.Text("Où souhaitez-vous partir?");
            return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }
        private async Task<DialogTurnResult> OriginStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var bookingDetails = (BookingDetails)stepContext.Options;
            bookingDetails.Destination = (string)stepContext.Result;

            var promptMessage = MessageFactory.Text("D'où partez-vous?");
            return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }
        private async Task<DialogTurnResult> TravelDateStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var bookingDetails = (BookingDetails)stepContext.Options;
            bookingDetails.Origin = (string)stepContext.Result;

            var promptMessage = MessageFactory.Text("Quand souhaitez-vous partir?");
            return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }
        private async Task<DialogTurnResult> ConfirmStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var bookingDetails = (BookingDetails)stepContext.Options;
            bookingDetails.TravelDate = (string)stepContext.Result;

            var promptMessage = MessageFactory.Text($"Veuillez confirmer le vol de { bookingDetails.Origin} vers { bookingDetails.Destination} pour le { bookingDetails.TravelDate}");
            return await stepContext.PromptAsync(nameof(ConfirmPrompt), new PromptOptions { Prompt = promptMessage }, cancellationToken);
        }
        private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        { 

            var bookingDetails = (BookingDetails)stepContext.Options;

            string messageText = "";
            if ((bool)stepContext.Result)
            {
                messageText = "La réservation est faite!";
            }
            else
            {
                messageText = "Réservation annulée!";
            }
            await stepContext.Context.SendActivityAsync(MessageFactory.Text(messageText), cancellationToken);
            return await stepContext.EndDialogAsync(bookingDetails);
        }
    }
}
