using System.Xml;
using Application.Common.Helpers;

namespace WebApi.Contracts.Services;

public class SiteMapService : ISiteMapService
{
    public void UpdateSiteMap(string urlString, string operation,string freq,string priorityString)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/sitemap.xml"));
        if (operation != "add")
        {
            XmlElement xmlElement = xmlDoc.DocumentElement;
            if (xmlElement.ChildNodes != null)
            {
                foreach (XmlElement myElement in xmlDoc.DocumentElement)
                {
                    if (myElement.ChildNodes[0].InnerText == urlString)
                    {
                        if (operation != "delete")
                            myElement.ChildNodes[1].InnerText = DateTime.Now.ToString("yyyy-MM-dd");
                        else
                            myElement.ParentNode.RemoveChild(myElement);
                        break;
                    }
                }
            }
        }
        else
        {
            string ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XmlNode url = xmlDoc.CreateNode(XmlNodeType.Element, "url", ns);
            XmlNode loc = xmlDoc.CreateNode(XmlNodeType.Element, "loc", ns);
            XmlNode lastmod = xmlDoc.CreateNode(XmlNodeType.Element, "lastmod", ns);
            XmlNode changefreq = xmlDoc.CreateNode(XmlNodeType.Element, "changefreq", ns);
            XmlNode priority = xmlDoc.CreateNode(XmlNodeType.Element, "priority", ns);
            loc.InnerText = urlString;
            lastmod.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            changefreq.InnerText = freq;
            priority.InnerText = priorityString;
            url.AppendChild(loc);
            url.AppendChild(lastmod);
            url.AppendChild(changefreq);
            url.AppendChild(priority);
            xmlDoc.DocumentElement.AppendChild(url);
        }
        xmlDoc.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/sitemap.xml"));
    }
}