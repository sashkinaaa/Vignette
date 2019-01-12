<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Kursova_Aleksandar.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" href="MyStyleSheet.css" type="text/css" />
    <title></title>
</head>
<body>
    <h1> Система за регистриране и проверка на винетки </h1> <br/> <br/>
    <asp:Image style="width: 100%;" runat="server" ImageURL="~/Images/e-vignette2.png" ></asp:Image>
    <form id="form1" runat="server">
    <div>
        <fieldset>
        <legend>Вход в системата</legend>
        <asp:Label CssClass="mylabel" ID="LbUsername" runat="server" Text="Потребителско име: "></asp:Label>
        <asp:TextBox ID="Username" class="textbox" runat="server"></asp:TextBox>
        <asp:Label CssClass="mylabel" ID="LbPass" runat="server" Text="Парола: "></asp:Label>
        <asp:TextBox ID="Password" class="textbox" TextMode="Password" runat="server"></asp:TextBox>
        <br/>
        <asp:Button CssClass="mybtn" ID="BtnLogin"  runat="server" Text="Вход!" OnClick="BtnLogin_Click" />
        <br/>
        <asp:Label CssClass="mylabel" ID="LbError" runat="server"></asp:Label>
        </fieldset>    
    </div>
        <br/>
        <hr/>
        <br/>
    <div>
        <fieldset style="background-color:#FF8C00;">
        <legend>Регистриране на потребители</legend>
        <asp:Label CssClass="mylabel" ID="LbRegUsername" runat="server" Text="Потребителско име: "></asp:Label>
        <asp:TextBox  ID="RegUsername" class="textbox" runat="server"></asp:TextBox>
        <asp:Label CssClass="mylabel" ID="LbRegPassword" runat="server" Text="Парола: "></asp:Label>
        <asp:TextBox ID="RegPassword" class="textbox" TextMode="Password" runat="server"></asp:TextBox>
        <br/>
        <br/>
        <asp:Label CssClass="mylabel" ID="Label1" runat="server" Text="Текст от изображението: "></asp:Label>
        <asp:textbox ID="txtCaptcha" class="textbox" runat="server"></asp:textbox>
        <br/>
        <botdetect:webformssimplecaptcha id="ExampleCaptcha" runat="server" />
        <br/>
        <asp:Button CssClass="mybtn" ID="BtnRegister" runat="server" Text="Регистрация" OnClick="BtnRegister_Click" />
        <br/>
        <asp:Label CssClass="mylabel" ID="LbResult" runat="server"></asp:Label>
        </fieldset>    
    </div>
    </form>
</body>
</html>
