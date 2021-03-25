

using AngleSharp;
using AngleSharp.Dom;
using AutoMapper;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wa_mvc_itstep_hometask_News_Site.Models.Helpers;
using wa_mvc_itstep_hometask_News_Site.Models.ViewModels;

namespace wa_mvc_itstep_hometask_News_Site.Services.Parsing
{
    public class EvilInfoParsing
    {
        public async Task<OneNewsVM> GetOneNews(OneNews oneNews, IMapper mapper)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(oneNews.Url);

            string source = await httpResponseMessage.Content.ReadAsStringAsync();

            IConfiguration config = Configuration.Default;

            IBrowsingContext context = BrowsingContext.New(config);

            IDocument document = await context.OpenAsync(req => req.Content(source));

            IElement[] textItems = document.All.Where(m => (m.LocalName == "p" && m.ClassList.Contains("box-paragraph__text"))
            || (m.LocalName == "h2" && m.ClassList.Contains("box-paragraph__subtitle"))
            || (m.LocalName == "b" && m.ClassList.Contains("box-paragraph__text"))).ToArray();

            OneNewsVM oneNewsViewModel = mapper.Map<OneNewsVM>(oneNews);

            foreach (IElement item in textItems)
            {
                HtmlElement htmlElement = new HtmlElement() { Name = item.LocalName, Text = item.Text() };

                oneNewsViewModel.HtmlElements.Add(htmlElement);
            }

            return oneNewsViewModel;
        }
    }
}
