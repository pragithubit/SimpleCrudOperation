
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCruPage.aspx.cs" Inherits="SimpleCrudOperation.WebFormCruPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Input Form -->
            <table cellpadding="3" cellspacing="4" style="height:60px; width:50%; position:inherit;">
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Age</td>
                    <td>
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Country</td>
                    <td>
                        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Create" OnClick="btnSubmit_Click"  />

                        
                    </td>
                </tr>
            </table>
            <br />
            
            <!-- GridView to Display Data -->
            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false" HeaderStyle-ForeColor="blue" DataKeyNames="EmpId" OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" >
                <Columns>
                     <asp:BoundField DataField="EmpId" HeaderText="EmpId" ReadOnly="True" />
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <%# Eval("Name") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Age">
            <ItemTemplate>
                <%# Eval("Age") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtAge" runat="server" Text='<%# Bind("Age") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Country">
            <ItemTemplate>
                <%# Eval("Country") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCountry" runat="server" Text='<%# Bind("Country") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>


</html>
