<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Storeproccrud.aspx.cs" Inherits="SimpleCrudOperation.Storeproccrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table cellpadding="3" cellspacing="4" style="height:60px; width:50%; position:inherit;">
     <tr>
         <td>Name</td>
         <td>
             <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" runat="server" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator>
         </td>
     </tr>
     <tr>
         <td>Age</td>
         <td>
             <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAge" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
         </td>
     </tr>
     <tr>
         <td>Country</td>
         <td>
             <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCountry" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
         </td>
     </tr>
     <tr>
         <td>
             <asp:Button ID="btnSubmit" runat="server" Text="Create" onclick="btnSubmit_Click" ValidationGroup="SubmitGroup"  />

              <asp:Button runat="server" ID="btnUpdate" Text="Update" class="button button4"  ValidationGroup="UpdateGroup"  OnClick="btnUpdate_Click"/>
               <asp:Button runat="server" ID="btnReset" Text="Reset"  class="button button4" OnClick="btnReset_Click"/>
         </td>
     </tr>
 </table>
        </div>

        <div>
            <asp:GridView  ID="GridView1" runat="server" HorizontalAlign="Center"  DataKeyNames="EmpId" AutoGenerateColumns="false"
                OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">
                 <Columns>
                     <asp:BoundField DataField="EmpId" HeaderText="EmpId" ReadOnly="true"/>

                     <asp:TemplateField HeaderText=" Name">
                         <ItemTemplate>
                             <asp:Label  ID="txtName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>

                         </ItemTemplate>
                        
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText=" Age">
                       <ItemTemplate>
                        <asp:Label  ID="txtAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label>
                        </ItemTemplate>
   
                       </asp:TemplateField>
                     <asp:TemplateField HeaderText="Country"> 
                         <ItemTemplate>
                          <asp:Label  ID="txtCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                     
                                
                    <asp:TemplateField HeaderText="Update">
                                     <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" CommandName="Edit" ToolTip="Click here to Edit the record" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="Delete" 
                                                    OnClientClick="return confirm('Are You Sure You want to Delete the Record?');"
                                                    ToolTip="Click here to Delete the record" CausesValidation="false" />
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                 </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
