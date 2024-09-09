<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DentalApp.Welcoming" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    
    <title></title>
    <style>
                
        body{
    background-color: #c9d6ff;
    background: linear-gradient(to right, #e2e2e2, #c9d6ff);
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    height: 100vh;
}
        .TextBoxStyle{
    background-color: #eee;
    border: none;
    margin: 8px 0;
    padding: 10px 15px;
    font-size: 13px;
    border-radius: 8px;
    width: 80%;
    outline: none;
    align-self:center;
}
    
        .button{
    background-color: #512da8;
    color: #fff;
    font-size: 12px;
    padding: 10px 45px;
    border: 1px solid transparent;
    border-radius: 8px;
    font-weight: 600;
    letter-spacing: 0.5px;
    text-transform: uppercase;
    margin-top: 10px;
    cursor: pointer;
    margin-left:125px;
}
        .sign-in{
    left: 20%;
    width: 40%;
    z-index: 5;
    background-color:#fff;
    top: 35%;
    left: 0%;
    display: flex;
    justify-content: center;
    border-radius: 30px;
    box-shadow: 0 5px 15px rgba(0, 0, 0, 0.35);
    position: relative;
    overflow: hidden;
    
}
 .lbl{
     margin-left:125px;
     font-size:40px;
     
 }
 .ddl{
     margin-left:250px;
 }
        </style>

</head>
<body style="height: 337px">
        
            <div class="sign-in" style="height: 550px">
                <form id="form1" runat="server" >

                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="12px" ForeColor="#512DA8"  PostBackUrl="~/Home.aspx" CausesValidation="False" >return to home page</asp:LinkButton>

                    <br />
<asp:DropDownList ID="DropDownList1" runat="server" Width="135px" CssClass="ddl"  >
    <asp:ListItem>Your Role</asp:ListItem>
    <asp:ListItem>Admin</asp:ListItem>
    <asp:ListItem>Student</asp:ListItem>
    <asp:ListItem>Instructor</asp:ListItem>
    <asp:ListItem>Patient</asp:ListItem>

</asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" Display="Dynamic" InitialValue="Your Role" ForeColor="Red"></asp:RequiredFieldValidator>                    
                    <br />
                    <asp:Label ID="txtlbl" runat="server" CssClass="lbl" Font-Names="Sans Serif Collection" Font-Bold="True" ForeColor="#512DA8" > Login</asp:Label>
                    <br />

                    

                <asp:TextBox ID="TextBox1" runat="server" placeholder="Email" CssClass="TextBoxStyle" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidateRequestMode="Enabled"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="Password" CssClass="TextBoxStyle"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidateRequestMode="Enabled"></asp:RequiredFieldValidator>
                <br />
                
                <asp:Button ID="Loginbtn" runat="server" Text="Login"  OnClick="Loginbtn_Click" CssClass="button"/>
                <br /> 
                    <br />

                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="12px" OnClick="LinkButton1_Click" ForeColor="#512DA8" CausesValidation="False" >Do not have an accout yet? register now!</asp:LinkButton>
                    <br />
                    <asp:Label ID="emptylbl" runat="server" > <br /></asp:Label>
                 </form>
            </div>
       
       
   
    

    <script>

        /*function loginbtn() {
            var tx1 = document.getElementById('*/<%= TextBox1.ClientID %>/*');
            var tx2 = document.getElementById('*/<%= TextBox2.ClientID %>/*');
            var dropdown = document.getElementById('*/<%= DropDownList1.ClientID %>/*');
            
            if (dropdown.selectedIndex == 20) {
                alert("Please select Role.");
                return false;
            }
            else if (tx1.value == "" || tx2.value == "") {
                alert("Please enter your email and password");
                return false;
            }
            else if (dropdown.selectedIndex == 1 && (tx1.value != "admin@DentalApp.com" || tx2.value != "admin123")) {
                alert("Wrong email or password, please try again.")
                return false;
            }
            else
                return true;
        }*/
    </script>
    </body>
</html>
