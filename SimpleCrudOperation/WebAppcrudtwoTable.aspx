<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebAppcrudtwoTable.aspx.cs" Inherits="SimpleCrudOperation.WebAppcrudtwoTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
            <table>
                  <tr>
                      <td>EmpName: </td>
                      <td>
                          <asp:TextBox ID="txtEmpName" runat="server"></asp:TextBox>
                      </td>
                  </tr>
                <tr>
                    <td>Salary:</td>
                    <td>
                        <asp:TextBox ID="txtSalary"  runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Country Name :</td>
                    <td>
                        <asp:DropDownList ID="ddlCountryName" runat="server" Style=" width:200px;"></asp:DropDownList>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Create" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                
            </table>
        
        <div>

        
      
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="EmpId" AutoGenerateColumns="false"
                HeaderStyle-BorderColor="#0000ff" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit">

                <Columns>
                    <asp:BoundField HeaderText="EmpId" ReadOnly="true" DataField="EmpId" />
                    <asp:TemplateField HeaderText="EmpName">
                        <ItemTemplate>
                            <%# Eval("EmpName") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmpName" runat="server" Text='<%# Bind("EmpName") %>' ></asp:TextBox>
                        </EditItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="Salary">
                        <ItemTemplate>
                            <%# Eval ("Salary") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSalary" runat="server" Text='<%# Bind("Salary") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CountryName">
                        <ItemTemplate>
                               <%# Eval("CountryName") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="ddlCountryName" runat="server" Text='<%# Bind("CountryId") %>'></asp:TextBox>

                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:CommandField  ShowEditButton="true" />
                    <asp:CommandField ShowDeleteButton="true" />
                    
                </Columns>

            </asp:GridView>
     </div>
    </form>
</body>
</html>
