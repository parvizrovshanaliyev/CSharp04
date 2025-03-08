using System;
using System.Linq;

namespace ArrayRealExamples
{
    /// <summary>
    /// Represents a chatbot response with a question and an answer.
    /// </summary>
    public class ChatbotResponse
    {
        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        public string Answer { get; set; }
    }

    /// <summary>
    /// Manages chatbot responses.
    /// </summary>
    public class Chatbot
    {

        /// <summary>
        /// Manages the chatbot by matching user questions to predefined responses.
        /// </summary>
        public static void ManageChatbot()
        {
            // Array of predefined chatbot responses
            ChatbotResponse[] responses = GetPredefinedResponses();

            // User's question
            Console.WriteLine("Ask me a question:");
            string userQuestion = Console.ReadLine();

            // Find the matched response
            ChatbotResponse matchedResponse = FindMatchedResponse(responses, userQuestion);

            // Output the matched response or a default message if no match is found
            if (matchedResponse != null)
            {
            Console.WriteLine($"Answer: {matchedResponse.Answer}");
            }
            else
            {
            Console.WriteLine("Sorry, I don't understand the question.");
            }
        }

        /// <summary>
        /// Gets the predefined chatbot responses.
        /// </summary>
        /// <returns>An array of predefined <see cref="ChatbotResponse"/> objects.</returns>
        private static ChatbotResponse[] GetPredefinedResponses()
        {
            return new ChatbotResponse[]
            {
            new ChatbotResponse { Question = "What is your name?", Answer = "I am AI assistant." },
            new ChatbotResponse { Question = "How are you?", Answer = "I am fine, thank you." },
            new ChatbotResponse { Question = "What can you do?", Answer = "I can assist you with coding." },
            new ChatbotResponse { Question = "Tell me a joke.", Answer = "Why do programmers prefer dark mode? Because light attracts bugs!" },
            new ChatbotResponse { Question = "What is the meaning of life?", Answer = "The meaning of life is to give life a meaning." },
            new ChatbotResponse { Question = "What is your favorite programming language?", Answer = "I don't have preferences, but I can help with many languages." }
            };
        }

        /// <summary>
        /// Finds the matched response for the given user question.
        /// </summary>
        /// <param name="responses">An array of <see cref="ChatbotResponse"/> objects.</param>
        /// <param name="userQuestion">The user's question.</param>
        /// <returns>The matched <see cref="ChatbotResponse"/> if found; otherwise, null.</returns>
        private static ChatbotResponse FindMatchedResponse(ChatbotResponse[] responses, string userQuestion)
        {
            foreach (var response in responses)
            {
            if (response.Question.Equals(userQuestion, StringComparison.OrdinalIgnoreCase))
            {
                return response;
            }
            }
            return null;
        }
    }
}
