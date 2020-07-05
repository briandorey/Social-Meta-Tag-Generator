# Social Meta Tag Generator


This simple helper function generates social media meta tags for web pages for Google, Schema.org, Twitter and Open Graph for Facebook etc using C#.
This demo uses asp.net master pages and you need to include this tag in the HEAD section of the page.

Edit lines 47 and 48 to add your Twitter ID.

Edit line 56 to add your business or website name.

    <title visible="false" runat="server"><%-- hack to turn the auto title off --%></title>

This line disables the normal html title tag, then add:

    <asp:Literal ID="LiteralMeta" runat="server"></asp:Literal>

In the page load function you add the new Social Meta code with the following:


    protected void Page_Load(Object Src, EventArgs E)
    {
        SocialMeta sm = new SocialMeta();
        sm.Title = "Page Title";
        sm.Description = "Your meta description";
        sm.Image = ""; 
        sm.Url = "";  
        sm.MakeSocial();
    }

The class uses the following:

Create an instance of the SocialMeta object
    SocialMeta sm = new SocialMeta();

Set the page title:
    sm.Title = "Page Title";

Set the Meta Description tags
    sm.Description = "Your meta description";

Set the page image
    sm.Image = "";

Set the page canonical url, this is optional and the code will use the HttpContext.Current.Request.Url.AbsoluteUri if not supplied.
    sm.Url = "";  

Now we create the tags and assign to the literal in the master page head section.
    sm.MakeSocial();

If you wanted to return a string rather than use the Masterpage functionality, change 
    public void MakeSocial()
to
    public string MakeSocial()

Next remove the following lines
    var pageHandler = HttpContext.Current.CurrentHandler;
            if (pageHandler is System.Web.UI.Page)
            {
                Literal litStreamHtml = (Literal)((System.Web.UI.Page)pageHandler).Master.FindControl("LiteralMeta");
                litStreamHtml.Text = sbSharing.ToString();
        }

Replace with: 
    return sbSharing.ToString();
