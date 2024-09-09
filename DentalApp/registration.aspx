<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="DentalApp.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
                .style1 {
    background-color: #c9d6ff;
    background: linear-gradient(to right, #e2e2e2, #c9d6ff);
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: column;
    height: 100vh;
    
}
               .style2 {
                    width: 100%;
                    height: 100vh;
                    margin: 0;
                    background-color: #c9d6ff;
                    background: linear-gradient(to right, #e2e2e2, #c9d6ff);
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
    margin-left:100px;
}
        .mydiv{
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
        .ddl {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #eee;
            margin: 8px 0;
            padding: 10px 15px;
            font-size: 13px;
            border-radius: 8px;
            outline: none;
            align-self: center;
        }
                input[type="text"], input[type="email"], input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
        }
        
         .mybtn {
            
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

        button[type="submit"]:hover {
            background-color: #3e8e41;
        }

        .container {
            max-width: 500px;
            margin: 40px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 30px;
            box-shadow: 0 5px 15px rgba(0, 0, 0, 0.35);
            
        }

        .header {
            background-color: #333;
            color: #fff;
            padding: 10px;
            text-align: center;
        }

        .header img {
            margin: 10px;
        }

        .content {
            padding: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-control {
            width: 80%;
            padding: 10px;
            margin-bottom: 20px;
            background-color: #eee;
            border: none;
            border-radius: 8px;
        }
        .radioButtonListItem {
            margin-right: 50px; 
            display: inline-block; 
            border: 1px solid #000;
        }
    </style>
</head>
<body style="height: 337px" class="<%= Session["BodyClass"] %>">
    

            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
            <asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Names="Sans Serif Collection" Font-Bold="True" ForeColor="#512DA8" Font-Size="20pt" > Hi friend, welcome at AAUP Dental Web Application.</asp:Label>
                   
                    <div class="mydiv">
                        <form id="form3" runat="server">
                            <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="12px" ForeColor="#512DA8" PostBackUrl="~/Home.aspx">return to home page</asp:LinkButton>
                            <br />
                            <asp:Label ID="txtlbl" runat="server" CssClass="lbl" Font-Names="Sans Serif Collection" Font-Bold="True" ForeColor="#512DA8" Font-Size="12pt" > Please select the role your want to register as:</asp:Label>
                            <br /><br />
                    <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="ddl" Width="361px" >
                        <asp:ListItem>Role</asp:ListItem>
                        <asp:ListItem>Student</asp:ListItem>
                        <asp:ListItem>Instructor</asp:ListItem>
                        <asp:ListItem>Patient</asp:ListItem>

                    </asp:DropDownList>
                            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*" Visible="False" ValidateRequestMode="Enabled"></asp:Label>
                            <br />
                            <br /><br />
                     <asp:Button ID="btn" runat="server" CssClass="button" Text="continue" OnClick="btn_Click" OnClientClick="return checkddl();"/><br /><br />
                            <asp:LinkButton ID="LinkButton" runat="server" Font-Size="12px" OnClick="LinkButton1_Click" ForeColor="#512DA8" >Already have an account? Login here!</asp:LinkButton>
                            <br>
                       
                            <br />
                            <asp:Label ID="emptylbl" runat="server"> <br /></asp:Label>
                            <br>
                            <br></br>
                            <br></br>
                            </br>
                            </br>
                            </form>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <form id="form2" runat="server">
    <div class="container">
        <div class="header">
            
            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/img/logo.jpg" Width="144px" Height="129px" />
            <asp:label ID="rolelbl" runat="server"><h1></h1></asp:label>
        </div>
        <div class="content">
            <div class="form-group">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" PlaceHolder="Full Name" Width="80%"></asp:TextBox>
                <br />
                <asp:RegularExpressionValidator ID="regExpName" runat="server" ControlToValidate="txtName" ErrorMessage="  Please enter your full name" ForeColor="Red" ValidationExpression="^\s*([\S]+\s+){3}[\S]+\s*$"></asp:RegularExpressionValidator>
                <br></br>
                
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" PlaceHolder="Phone" Width="80%"></asp:TextBox>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPhone" ErrorMessage="Please enter a 10-digit phone number." ForeColor="Red" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                <br></br>
                </div>
            <div class="form-group">
       
                <asp:Label ID="datelbl" runat="server" CssClass="form-control" >Birth Date</asp:Label>
                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" TextMode="Date" PlaceHolder="Date" ></asp:TextBox>
            </div>
            <div class="form-group">
                <br>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" PlaceHolder="Email"  Visible="False" Width="80%"></asp:TextBox>
            </div>

            <div class="form-group">
               
                <asp:TextBox ID="stdemail" runat="server" CssClass="form-control"  PlaceHolder="Email"  Visible="False" Enabled="False" Width="80%"></asp:TextBox>
           
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="stdemail" Display="Dynamic" ErrorMessage="Use your univarsity email" ForeColor="Red" ValidationExpression="^\w+([-+.']\w+)*@student\.aaup\.edu$" ValidateRequestMode="Enabled" ></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
      
                <asp:TextBox ID="insemail" runat="server" CssClass="form-control"  PlaceHolder="Email"  Visible="False" Enabled="False" Width="80%"></asp:TextBox>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="insemail" Display="Dynamic" ErrorMessage="Use your univarsity email" ForeColor="Red" ValidationExpression="^\w+([-+.']\w+)*@aaup\.edu$" ValidateRequestMode="Enabled"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" Enabled="False" Visible="False" Width="361px">
                    <asp:ListItem>Acadamic Year</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2" Display="Dynamic" Enabled="False" ErrorMessage="*" ForeColor="Red" InitialValue="Acadamic Year" ValidateRequestMode="Enabled"></asp:RequiredFieldValidator>
                <br></br>
            </div>
            
            <div class="form-group">
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" Enabled="False" Visible="False" Width="361px">
                </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList3" Display="Dynamic" ErrorMessage="*" ForeColor="Red" InitialValue="My Instructor" Enabled="False" ValidateRequestMode="Enabled"></asp:RequiredFieldValidator>
</div>
            <div class="form-group">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" PlaceHolder="Password" TextMode="Password" Width="80%"></asp:TextBox>
                <br></br>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" PlaceHolder="Confirm Password" TextMode="Password" Width="80%"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="password missmatched" ForeColor="Red" ValidateRequestMode="Enabled"></asp:CompareValidator>
                <br></br>
            </div>
            <div class="form-group">
                <asp:Label ID="genderlbl" runat="server" ForeColor="#000099">Gender:</asp:Label><br /><br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="form-control" required>
                    <asp:ListItem>Male</asp:ListItem> 
                    <asp:ListItem>Female</asp:ListItem> 
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rfvRadioButtonList" runat="server" ControlToValidate="RadioButtonList1"
     ErrorMessage="Please select gender." Display="Dynamic" ForeColor="Red" ValidateRequestMode="Enabled"/>
            </div><br />
            <div class="form-group">
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="mybtn" OnClick="btnRegister_Click"/>
            </div>
        </div>
    </div>
</form>
                </asp:View>
            </asp:MultiView>
        
    <script>

    </script>
</body>
</html>
