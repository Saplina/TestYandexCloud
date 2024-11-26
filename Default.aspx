<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestYandexCloud._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
           
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
             <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </section>
            
            <section class="col-md-4" aria-labelledby="librariesTitle">
              
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
               
            </section>
        </div>
    </main>

</asp:Content>
