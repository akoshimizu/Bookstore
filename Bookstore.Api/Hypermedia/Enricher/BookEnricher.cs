using System.Text;
using Bookstore.Api.Hypermedia.Constants;
using Bookstore.Api.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Hypermedia.Enricher
{
    public class BookEnricher : ContentResponseEnricher<EditorBookValueObject>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(EditorBookValueObject content, IUrlHelper urlHelper)
        {
            var path = "v1/books";
            string link = GetLink(content.Id, urlHelper, path);
            string linkByName = GetLink(content.Name, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerbs.GET,
                Href = linkByName,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerbs.POST,
                Href = link,
                Rel = RelationType.post,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerbs.PUT,
                Href = link,
                Rel = RelationType.put,
                Type = ResponseTypeFormat.DefaultPut
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerbs.DELETE,
                Href = link,
                Rel = RelationType.delete,
                Type = ResponseTypeFormat.DefaultDelete
            });
            return null;
        }

        private string GetLink(int? id, IUrlHelper urlHelper, string path)
        {
            lock(_lock)
            {
                var url = new {controller = path, id = id};
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            };
        }

        private string GetLink(string? name, IUrlHelper urlHelper, string path)
        {
            lock(_lock)
            {
                var url = new {controller = path, id = name};
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            };
        }
    }
}