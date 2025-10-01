using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;

var serverUrl = "http://localhost:5043";
var apiKey = "your-openai-api-key";

var sharedHandler = new SocketsHttpHandler
{
	PooledConnectionLifetime = TimeSpan.FromMinutes(2),
	PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1)
};
var httpClient = new HttpClient(sharedHandler);
var transport = new HttpClientTransport(new HttpClientTransportOptions
{
	Endpoint = new Uri(serverUrl),
	Name = "Shopping.Server",
}, httpClient);

var mcp = await McpClient.CreateAsync(transport);
var tools = await mcp.ListToolsAsync();

var openaiClient = new OpenAI.Chat.ChatClient("gpt-4o-mini", apiKey)
		.AsIChatClient();

var client = new ChatClientBuilder(openaiClient)
		.UseFunctionInvocation()
		.Build();

Console.WriteLine("Available Tools:");
foreach (var tool in tools)
{
	Console.WriteLine($"{tool.Name} - {tool.Description}");
}
Console.WriteLine();
while (true)
{
	Console.Write("You: ");
	var userInput = Console.ReadLine();
	if (string.IsNullOrWhiteSpace(userInput))
		break;

	await foreach (var message in client.GetStreamingResponseAsync(
		               userInput!, 
		               new ChatOptions { Tools = [.. tools] }))
	{
		Console.Write(message);
	}
	Console.WriteLine();
}

