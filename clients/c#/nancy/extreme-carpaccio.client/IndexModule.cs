
using System;
using Nancy;
using Nancy.ModelBinding;

namespace xCarpaccio.client
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Post["/order"] = _ =>
            {
                var order = this.Bind<Order>();
                var bill = HandleOrder(order);
                if (bill == null)
                {
                    return new {};
                }

                return bill;
            };

            Post["/feedback"] = _ =>
            {
                var feedback = this.Bind<Feedback>();
                HandleFeedback(feedback);

                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }

        private Bill HandleOrder(Order order)
        {
            // return null if you do not what to return a total
            return null;
        }

        private void HandleFeedback(Feedback feedback)
        {
            Console.WriteLine($"Type: {feedback.type}: {feedback.content}");
        }        
    }
}