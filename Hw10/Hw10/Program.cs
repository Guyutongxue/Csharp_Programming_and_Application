// HTML 自 5 起不再是 XML，所以不能用 XML 分析库！

using AngleSharp;
using AngleSharp.Dom;

var urls = new Queue<string>();
var client = new HttpClient();
var downloaded = new HashSet<string>();

urls.Enqueue("https://hao.360.com");
IBrowsingContext context = BrowsingContext.New();

while (urls.Count > 0)
{
    var url = urls.Dequeue();
    if (downloaded.Contains(url)) continue;
    var res = await client.GetAsync(url);
    if (!(res.Content.Headers.ContentType?.MediaType?.StartsWith("text/html") ?? false))
    {
        continue;
    }
    var document = await context.OpenAsync(async req => req.Content(await res.Content.ReadAsStringAsync()));
    Console.WriteLine($"Downloaded {url}.");

    var links = document.QuerySelectorAll("a");
    foreach (var l in links)
    {
        if (l.Attributes["href"] is IAttr href)
        {
            var value = href.Value;
            if (value.StartsWith("http:") || value.StartsWith("https:"))
            {
                Console.WriteLine($"Found {value}.");
                urls.Enqueue(value);
            }
        }
    }
    downloaded.Add(url);
    Console.WriteLine($"{downloaded.Count} page downloaded, {urls.Count} page in queue. Continue?");
    Console.ReadKey();
}

