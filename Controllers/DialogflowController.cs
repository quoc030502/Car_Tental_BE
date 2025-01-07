using Google.Cloud.Dialogflow.V2;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth.OAuth2;
using System;

namespace basic_api.Controllers
{
    [ApiController]
    [Route("api/dialogflow")]
    public class DialogflowController : ControllerBase
    {
        private readonly string _projectId = "carrental-abcd";

        [HttpPost("detect-intent")]
        public async Task<IActionResult> DetectIntent([FromBody] DialogFlowRequest request)
        {
            try
            {
                Console.WriteLine("1");
                if (string.IsNullOrWhiteSpace(request.Message))
                {
                    return BadRequest(new { Error = "Message cannot be empty." });
                }

                var credentials = GoogleCredential.FromFile("./Services/dialogflow.json")
                    .CreateScoped(["https://www.googleapis.com/auth/cloud-platform"]);
                var client = new SessionsClientBuilder { Credential = credentials }.Build();

                var sessionId = Guid.NewGuid().ToString();
                var sessionName = new SessionName(_projectId, sessionId);

                var dialogflowRequest = new DetectIntentRequest
                {
                    SessionAsSessionName = sessionName,
                    QueryInput = new QueryInput
                    {
                        Text = new TextInput
                        {
                            Text = request.Message,
                            LanguageCode = "vi"
                        }
                    }
                };

                var response = await client.DetectIntentAsync(dialogflowRequest);

                return Ok(new
                {
                    ResponseMessage = response.QueryResult.FulfillmentText,
                    Intent = response.QueryResult.Intent.DisplayName
                });
            }
            catch (Grpc.Core.RpcException rpcEx)
            {
                return BadRequest(new { Error = rpcEx.Status.Detail });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }

    public class DialogFlowRequest
    {
        public required string Message { get; set; }
    }
}
