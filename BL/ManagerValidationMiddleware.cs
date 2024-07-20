using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BL
{
    internal class ManagerValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ManagerValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if ((context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase) ||
                 context.Request.Method.Equals("PUT", StringComparison.OrdinalIgnoreCase)) &&
                context.Request.Body != null)
            {
                // Copy the request body to memory so we can read it again
                var requestBodyStream = new MemoryStream();
                await context.Request.Body.CopyToAsync(requestBodyStream);
                requestBodyStream.Seek(0, SeekOrigin.Begin);
                context.Request.Body = requestBodyStream;

                using (var reader = new StreamReader(requestBodyStream, leaveOpen: true))
                {
                    var requestBody = await reader.ReadToEndAsync();
                    requestBodyStream.Seek(0, SeekOrigin.Begin); // Reset the stream position

                    try
                    {
                        using (JsonDocument document = JsonDocument.Parse(requestBody))
                        {
                            if (document.RootElement.TryGetProperty("name", out JsonElement nameElement))
                            {
                                var name = nameElement.GetString();
                                if (!IsValidName(name))
                                {
                                    context.Response.StatusCode = 400;
                                    await context.Response.WriteAsync("Invalid name. Name should contain only letters.");
                                    return;
                                }
                            }


                        }
                    }
                    catch (JsonException ex)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync($"Invalid JSON payload: {ex.Message}");
                        return;
                    }
                }
            }

            // המשך לעיבוד ה-Middleware הבא בצינור
            await _next(context);
        }

        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter);
        }
    }
}
