<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Kursova_Aleksandar.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" href="MyStyleSheet.css" type="text/css" />
    <title></title>
</head>
<body>
    <h1><asp:Label ID="LbHello" runat="server"></asp:Label></h1>
    <asp:Image style="width: 100%;" runat="server" ImageURL="~/Images/e-vignette2.png" ></asp:Image>
    <form id="form1" runat="server">
    <div id="vignetteDiv" runat="server">
        <fieldset>
        <legend>Регистрация на нова винетка</legend>
        <asp:Label CssClass="mylabel" ID="LbCarNumber" runat="server" Text="Номер на автомобила: "></asp:Label>
        <asp:TextBox ID="carNumber" class="textbox" runat="server"></asp:TextBox>
        <asp:Label CssClass="mylabel" ID="LbExpirationDate" runat="server" Text="Валидна до: "></asp:Label>
        <asp:TextBox ID="expirationDate" class="textbox" runat="server"></asp:TextBox>
        <asp:Label CssClass="mylabel" ID="LbCategory" runat="server" Text="Категория: "></asp:Label>
        <asp:TextBox ID="Category" class="textbox" runat="server"></asp:TextBox>
        <br />
        <asp:Button CssClass="mybtn" ID="BtnRegister" runat="server" Text="Регистрация" OnClick="BtnRegister_Click" />
        <br/>
        <asp:Label CssClass="mylabel" ID="LbResult" runat="server"></asp:Label>
        </fieldset>
        <br/>
        <hr/>
        <br/>
    </div>
    <div>
        <fieldset>
        <legend>Проверка на винетка по номер на автомобила</legend>
        <asp:Label CssClass="mylabel" ID="LbNumber" runat="server" Text="Номер на автомобила: "></asp:Label>
        <asp:TextBox ID="Number" class="textbox" runat="server"></asp:TextBox>
        <br />
        <asp:Button CssClass="mybtn" ID="BtnSelect" runat="server" Text="Търсене" OnClick="BtnSelect_Click" />
        <asp:Button CssClass="mybtn" ID="BtnShow" runat="server" Text="Показване на всички" OnClick="BtnShow_Click" />  
        <br/>
        <asp:Label CssClass="mylabel" ID="LbResult2" runat="server"></asp:Label>
        </fieldset>
    </div>
    <br/>
    <hr/>
    <br/>
        <asp:DataGrid ID="dataGrid" runat="server" AutoGenerateColumns="false">
                <Columns>  
                    <asp:BoundColumn HeaderText="Id" DataField="Id"> </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Номер на автомобила" DataField="carNumber"> </asp:BoundColumn> 
                    <asp:BoundColumn HeaderText="Валидна до" DataField="expirationDate"> </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Категория" DataField="Category"> </asp:BoundColumn>
                </Columns>
            </asp:DataGrid>
    </form>
</body>
</html>
