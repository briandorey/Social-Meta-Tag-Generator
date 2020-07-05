using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// This simple helper function generates social media meta tags for web pages 
/// for Google, Schema.org, Twitter and Open Graph for Facebook etc using C#.
/// </summary>
public class SocialMeta
{
    public SocialMeta()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Url { get; set; }

    public void MakeSocial()
    {
        StringBuilder sbSharing = new StringBuilder();
        if (Url == null)
        {
            Url = HttpContext.Current.Request.Url.AbsoluteUri;
        }
        Title = LeftString(Title.Trim(), 65);
        Description = LeftString(Description.Trim(), 160);
        sbSharing.Append("<title>" + Title + "</title>" + Environment.NewLine);
        sbSharing.Append("<!-- Search Engine -->" + Environment.NewLine);
        sbSharing.Append("<meta name=\"image\" content=\"" + Image + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta name=\"description\" content=\"" + Description + "\"/>" + Environment.NewLine);
        sbSharing.Append("<link rel=\"canonical\" href=\"" + Url + "\"/>" + Environment.NewLine);

        sbSharing.Append("<!-- Schema.org for Google -->" + Environment.NewLine);
        sbSharing.Append("<meta itemprop=\"name\" content=\"" + Title + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta itemprop=\"description\" content=\"" + Description + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta itemprop=\"image\" content=\"" + Image + "\"/>" + Environment.NewLine);

        sbSharing.Append("<!-- Twitter -->" + Environment.NewLine);
        sbSharing.Append("<meta name=\"twitter:card\" content=\"" + Description + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta name=\"twitter:title\" content=\"" + Title + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta name=\"twitter:description\" content=\"" + Description + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta name=\"twitter:site\" content=\"@\"/>" + Environment.NewLine);
        sbSharing.Append("<meta name=\"twitter:creator\" content=\"@\"/>" + Environment.NewLine);
        sbSharing.Append("<meta name=\"twitter:image:src\" content=\"" + Image + "\"/>" + Environment.NewLine);

        sbSharing.Append("<!-- Open Graph general (Facebook, Pinterest & Google+) -->" + Environment.NewLine);
        sbSharing.Append("<meta property=\"og:title\" content=\"" + Title + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta property=\"og:description\" content=\"" + Description + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta property=\"og:image\" content=\"" + Image + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta property=\"og:url\" content=\"" + Url + "\"/>" + Environment.NewLine);
        sbSharing.Append("<meta property=\"og:site_name\" content=\"\"/>" + Environment.NewLine);
        sbSharing.Append("<meta property=\"og:locale\" content=\"en_GB\"/>" + Environment.NewLine);
        sbSharing.Append("<meta property=\"og:type\" content=\"website\"/>" + Environment.NewLine);
        
        var pageHandler = HttpContext.Current.CurrentHandler;
        if (pageHandler is System.Web.UI.Page)
        {
            Literal litStreamHtml = (Literal)((System.Web.UI.Page)pageHandler).Master.FindControl("LiteralMeta");
            litStreamHtml.Text = sbSharing.ToString();
        }
    }

    private string LeftString(string strParam, int iLen)
    {
        if (iLen > 0 && strParam.Length > iLen)
            return strParam.Substring(0, iLen);
        else
            return strParam;
    }
}